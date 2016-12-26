namespace CompressTextDocument.Archiver.Common.Extensions
{
    public static class GetUniqueSymbolsExtension
    {
        // заміна повторів символу на короткий вираз
        // наприклад, є слово аааааааааа - воно замінюється на а10, що означає 10 повторів а
        public static string CompressSymbols(this string source, char delim)
        {
            // беремо початковий символ
            char symbol = source[0];
            // поки він один, тобто кількість повторів 1
            int repeatTime = 1;
            // поки в результаті нічого немає
            string result = "";
            // позиція першого символу слова, що складається з повторів символу
            int lastI = 0;

            for (int i = 1; i < source.Length; i++)
            {
                // якщо є повтор в наступному символі
                if (source[i] == symbol)
                {
                    repeatTime++;
                }
                else  // якщо ні
                {
                    // щоб стиснення було ефективне, необхідна мінімальна кількість повторів 5, оскільки мінімальний запис займає 4 символи
                    if (repeatTime >= 5)
                    {
                        // записуємо символ старту заміни
                        result += delim;
                        // записуємо символ, який буде повторюватись
                        result += symbol;
                        // записуємо число повторів
                        result += repeatTime.ToString();
                        // записуємо символ кінця заміни
                        result += delim;
                    }
                    else // якщо стиснення буде неефективним, записуємо слово як є
                    {
                        result += source.Substring(lastI, i - lastI);
                    }
                    // в кінці кожного слова, необхідно "онулити" індекси
                    lastI = i;
                    symbol = source[i];
                    repeatTime = 1;
                }
            }
            // при виході з циклу можна ще залишатись в слові, тому блок повторюємо
            if (repeatTime >= 5)
            {
                result += delim;
                result += symbol;
                result += repeatTime.ToString();
                result += delim;
            }

            return result;
        }

        // розкодовування повторів символу
        public static string DecompressSymbols(this string source, char delim)
        {
            char symbol = delim;
            int repeatTime = 0;
            string result = "";

            for (int i = 0; i < source.Length; i++)
            {
                // якщо зустрічається розділювальний знак
                if (source[i] == delim)
                {
                        //зчитуємо наступний символ як повторюючийся
                        i++;
                        symbol = source[i];
                        // перетворюємо кількість повторів із текстового вигляду в число
                        string repeatTimeString = "";
                        while(source[i] != delim)
                        {
                            repeatTimeString += source[i];
                            i++;
                        }
                        repeatTime = int.Parse(repeatTimeString);
                        // повторюємо символ задану кількість разів у розкодованому тексті
                        for (int j = 0; j < repeatTime; j++)
                        {
                            result += symbol;
                        }
                    
                }else
                {
                    // якщо немає розділювального знаку - просто пишемо те, що є
                    result += source[i];
                }
            }

            return result;
        }

    }
}
