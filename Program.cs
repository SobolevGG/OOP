using System.Text;
// ???
// Делаем что-то новое в коде 2.0
// Делаем что-то из VS
namespace Count
{
    /// <summary>
    /// Сколько букв осталось на своих местах после переворота строки.
    /// </summary>
    public class CountClass
    {
        private static void Main()
        {
            // Исходный текст в строке
            string text1 = "Война - это великое дело государства. (с) Сунь-Цзы";
            Console.WriteLine($"\n\tНа своих же местах " +
                $"осталось {Count(text1, ReverseStr(text1))} букв.");
        }

        /// <summary>
        /// Реверс строки.
        /// </summary>
        /// <param name="text1">Строка с текстом.</param>
        private static string ReverseStr(string text1)
        {
            StringBuilder text2 = new(text1.Length);
            for (int i = text1.Length; i != 0; i--)
            {
                text2 = text2.Append(text1[i - 1]);
            }

            Console.WriteLine("\n\tПеревёрнутый текст: " + text2);
            return text2.ToString();
        }

        /// <summary>
        /// Сравнение двух строк на совпадение мест букв.
        /// </summary>
        /// <param name="text2">Строка с перевётнутым текстом.</param>
        private static int Count(string text1, string text2)
        {
            // Счётчик для букв
            int count = 0;
            for (int i = 0; i < text1.Length; i++)
            {
                if (text1[i] == text2[i])
                {
                    count += 1;
                }
            }

            return count;
        }
    }
}
