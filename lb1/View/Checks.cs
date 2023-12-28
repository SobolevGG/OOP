﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    /// <summary>
    /// Класс для выполнения проверок
    /// </summary>
    public static class Checks
    {
        /// <summary>
        /// Проверки на числа, точки и запятые
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
        /// Преобразование числа в double
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int CheckNumber(string number)
        {
            number = number.Replace('.', ',');
            return int.Parse(number);
        }
    }
}
