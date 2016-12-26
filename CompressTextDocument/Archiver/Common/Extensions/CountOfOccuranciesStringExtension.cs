namespace CompressTextDocument.Archiver.Common.Extensions
{
    public static class CountOfOccuranciesStringExtension
    {
        // шукаємо кількість збігів певного слова в тексті
        public static int CountOfOccurancies(this string match, string filter)
        {
            // спочатку кількість збігів 0
            int count = 0;
            
            
            for (int i = 0; i < match.Length; i++)
            {
                // якщо перша літера фільтру співпадає з і-ю літерою тексту
                if (match[i] == filter[0])
                {
                    // шукаємо чи слово співпадає повністю
                    for (int j = 0; j < filter.Length; j++)
                    {
                        //  якщо ні - виходимо
                        if (i+j== match.Length || match[i + j] != filter[j])
                        {
                            break;
                        }
                        // якщо слово повністю співпадає
                        if (j == filter.Length - 1)
                        {
                            // збільшуємо кількість співпадінь
                            count++;
                            // стартуємо з індексу, на якому останнє співпадіння завершилось
                            if (i + j < match.Length)
                            {
                                i += j;
                            }
                            else
                            {
                                i = match.Length;
                            }
                        }
                    }
                }
            }

            return count;
        }
    }
}
