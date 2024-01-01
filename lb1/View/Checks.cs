using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Пространство имён View.
/// </summary>
namespace View
{
    /// <summary>
    /// Класс для выполнения проверок.
    /// </summary>
    public static class Checks
    {
        /// <summary>
        /// Проверки на числа, точки и запятые.
        /// </summary>
        /// <param name="e"></param>
        public static void CheckInput(KeyPressEventArgs e)
        {
            const int backSpace = 8;

            char number = e.KeyChar;
            if ((e.KeyChar < '0' || e.KeyChar > '9')
                && number != backSpace
                && number != ','
                && number != '.')
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Метод замены точки на запятую и проверки:
        /// является ли значение числовым?
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Проверенное значение.</returns>
        /// <exception cref="Exception">Исключение 
        /// на нечисловой ввод.</exception>
        public static double CheckDouble(string number)
        {
            // Заменяем точку на запятую
            number = number.Replace('.', ',');

            // Пытаемся преобразовать строку в число типа double
            if (!double.TryParse(number, out double checkedNum))
            {
                // Если преобразование не удалось, вызываем исключение
                throw new Exception("введено нечисловое значение!");
            }

            return checkedNum;
        }
    }
}
