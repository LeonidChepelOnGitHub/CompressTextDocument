using CompressTextDocument.Archiver.Common.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CompressTextDocument.Archiver
{


    public class Arhiver : IArhiver
    {
        private const int _minWordSize = 4;

        public string ReplaceStartSequenceString { get; set; }
        public char ReplaceRepeatedLetterSymbol { get; set; }
        public event Action<object, ProgressEventArgs> OnProgressChanged;

        public Arhiver()
        {
            ReplaceStartSequenceString = "¶";
            ReplaceRepeatedLetterSymbol = (char)6;
        }

        // Головна функція стискання
        public void Compress(ArhiverInputOptions options)
        {
            string textToCompress;
            // зчитуємо дані, що потребують стиснення
            using (var lines = File.OpenText(options.File))
            {
                textToCompress = lines.ReadToEnd();
            }
            // якщо це встановлено в опціях, стискаємо повтори символів
            if (options.CompressRepeating)
            {
                textToCompress = textToCompress.CompressSymbols(ReplaceRepeatedLetterSymbol);
            }
            // отримуємо словник з частих повторів
            var dictionary = getDataCanCompress(options, textToCompress);
            var metadata = "";
            var compressedData = textToCompress;
            // необхідно шифрувати словник якимось чином
            for (int i = 0; i < dictionary.Length; i++)
            {
                var events = new ProgressEventArgs(50 + 50 * i / dictionary.Length);
                OnProgressChanged(this, events);
                // для шифрування додаємо розділювач - ReplaceStartSequenceString
                string replacement = ReplaceStartSequenceString + i.ToString();
                // наш словник - це метадані
                metadata += replacement + dictionary[i];
                // замінюємо кожний збір значенням зі словника
                compressedData = compressedData.Replace(dictionary[i], replacement);
            }
            // остаточний файл - це метадані разом із стиснутим текстом, щоб можна було все відновити
            var finalCompressedData = metadata
                                    + ReplaceStartSequenceString
                                    + ReplaceStartSequenceString
                                    + compressedData;

            // якщо відлагодження увімкнено
            if (options.DebugMode)
            {
                // створення директорії відлагодження
                if (!Directory.Exists(options.Destination + "\\common"))
                {
                    Directory.CreateDirectory(options.Destination + "\\common");
                }
                // логуємо в common окремий файл результату
                SaveToFile(textToCompress, options.Destination + "\\common\\" + options.File.Split('\\').Last() + ".tarcR");
                // зберігаємо окремо словник
                SaveToFile(metadata, options.Destination + "\\common\\" + options.File.Split('\\').Last() + ".tarcD");
                // зберігаємо окремо стиснутий текст
                SaveToFile(compressedData, options.Destination + "\\common\\" + options.File.Split('\\').Last() + ".tarcC");
            }
           
            // зберігаємо остаточний файл
            SaveToFile(finalCompressedData, options.Destination + '\\' + options.File.Split('\\').Last() + ".tarc");
            var e = new ProgressEventArgs(100);
            OnProgressChanged(this, e);
        }




        // Функція, що шукає дані, які можна стиснути
        private string[] getDataCanCompress(ArhiverInputOptions options, string allText)
        {

            //  Створюємо словник з ключом - текстом, що шифрується
            //  Другий аргумент - кількість повторів
            var dict = new Dictionary<string, int>();

            // indexData - конкретний індекс в тексті, звідки відраховується слово
            // wordSize - розмір(довжина) слова
            int indexData = 0, wordSize = options.FromMinToMax ? _minWordSize : options.MaxWordSize;
            do
            {
                // якщо довжина всього тексту, що залишився менше мінімальної довжини слова, припиняємо роботу
                if (indexData >= allText.Length - _minWordSize)
                {
                    break;
                }

                // в залежності від стратегії стиску - підбираємо від меншого слова до більшого чи навпаки
                if (options.FromMinToMax)
                {
                    if (wordSize + indexData >= allText.Length || wordSize == options.MaxWordSize)
                    {
                        wordSize = _minWordSize;
                        indexData++;
                    }
                }
                else
                {
                    if (wordSize == _minWordSize)
                    {
                        wordSize = options.MaxWordSize;
                        indexData++;
                    }
                    while (wordSize + indexData >= allText.Length)
                    {
                        wordSize--;
                    }
                    if (wordSize < _minWordSize)
                    {
                        break;
                    }
                }

                // виділяємо слово
                var word = allText.Substring(indexData, wordSize);
                // підраховуємо кілкість збігів в тексті
                var count = allText.CountOfOccurancies(word);
                // є сенс додавати слово, тільки якщо кількість збігів більше 1
                if (count > 4)
                {
                    // перевіряємо чи таке слово вже існує
                    if (!dict.Keys.Contains(word))
                    {
                        // якщо ні, додаємов словник
                        dict.Add(word, count);
                        // при перевищенні словника
                        if (dict.Count > options.DictionarySize)
                        {
                            // шукаємо слово, яке має найменшу кількість повторів
                            var min = dict.First();
                            foreach (var keyVal in dict)
                            {
                                if (min.Value > keyVal.Value)
                                {
                                    min = keyVal;
                                }
                            }
                            // видаляємо його
                            dict.Remove(min.Key);
                        }
                    }
                }
                // в залежності від стратегії збільшуємо або зменшуємо довжину слова
                wordSize = options.FromMinToMax ? wordSize + 1 : wordSize - 1;



                var e = new ProgressEventArgs(50 * indexData / (allText.Length - _minWordSize));
                OnProgressChanged(this, e);

            } while (true);
            return dict.Keys.ToArray();
        }




        // розархівування стиснутого архіву
        public void UnCompress(ArhiverOutputOptions options)
        {
            // отримуємо стиснутий файл зі словником
            var file_with_metadata = ReadFromFile(options.File);
            // відділяємо словник
            var splitBy = ReplaceStartSequenceString + ReplaceStartSequenceString;
            var index = file_with_metadata.IndexOf(splitBy);
            var metadata = file_with_metadata.Substring(0, index).Split(ReplaceStartSequenceString[0]).Where(m => m != "");
            // отримуємо масив необхідних замін
            var replace_array = metadata.Select(m => ReplaceStartSequenceString + readUntilNum(m)).ToArray();
            // отримуємо масив значень, якими можна замінити значення попереднього масиву
            var replace_values = metadata.Select(m => m.Substring(readUntilNum(m).Length)).ToArray();
            // відділяємо стиснуті дані
            var data = file_with_metadata.Substring(index + splitBy.Length);
            // послідовно робимо заміни
            for (int i = 0; i < replace_array.Length; i++)
            {
                data = data.Replace(replace_array[i], replace_values[i]);
                var e = new ProgressEventArgs(100 * i / replace_array.Length);
                OnProgressChanged(this, e);
            }
            // якщо файл був додатково стиснений на повтори символів, вони розкодуються, якщо ні - буде так як є
            data = data.DecompressSymbols(ReplaceRepeatedLetterSymbol);
            // зберігаємо новий розархівований файл
            SaveToFile(data, options.Destination + '\\' + options.File.Split('\\').Last() + ".txt");
            OnProgressChanged(this, new ProgressEventArgs(100));
        }

        // функція отримання текстового запису числа 
        private string readUntilNum(string data)
        {
            // поки існують цифри, формується число
            var ret = "";
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= '0' && data[i] <= '9')
                {
                    ret += data[i];
                }
                else
                {
                    break;
                }
            }
            return ret;
        }

        public static void SaveToFile(string data, string filename)
        {
            try
            {
                using (var file = File.CreateText(filename))
                {
                    file.Write(data);
                }

            }
            catch (IOException)
            {
            }
        }

        public static string ReadFromFile(string filename)
        {
            string data = null;
            try
            {

                using (var file = File.OpenText(filename))
                {
                    data = file.ReadToEnd();

                }
            }
            catch (IOException)
            {
            }
            return data; ;
        }
    }
}
