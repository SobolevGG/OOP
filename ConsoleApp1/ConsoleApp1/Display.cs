﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static Model.Formulas;

namespace Model
{
    public class Display
    {
        // Дополнительный метод для вывода формул в консоль
        public static void DisplayFormulas(List<PowerFormula> formulas)
        {
            Console.WriteLine("Содержимое файла формул:");

            foreach (var formula in formulas)
            {
                Console.WriteLine($"Имя: {formula.Name}");
                Console.WriteLine($"Выражение: {formula.FormulaExpression}");
            }
        }

        // Дополнительный метод для вывода расходов воды для гидрогенераторов
        public static void DisplayGeneratorFlows(List<GeneratorFlow> generatorFlows)
        {
            if (generatorFlows != null)
            {
                Console.WriteLine("Расходы воды для каждого гидрогенератора:");
                foreach (var generatorFlow in generatorFlows)
                {
                    Console.WriteLine($"Гидрогенератор {generatorFlow.Name}: {generatorFlow.WaterFlow} куб. м/с");
                }
            }
            else
            {
                Console.WriteLine("Ошибка: Не удалось загрузить данные о расходах воды.");
            }
        }

        public static void InputUserContains(UserConstraints userConstraints)
        {
            Console.Write("Введите минимальное значение расхода (куб. м/с): ");
            userConstraints.MinFlowRate = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите максимальное значение расхода (куб. м/с): ");
            userConstraints.MaxFlowRate = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите минимальное значение напора (м): ");
            userConstraints.MinHead = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите максимальное значение напора (м): ");
            userConstraints.MaxHead = Convert.ToDouble(Console.ReadLine());
        }

        public static void DisplayUserConstraints(UserConstraints userConstraints)
        {
            if (userConstraints != null)
            {
                Console.WriteLine("Ограничения пользователя:");
                Console.WriteLine($"Минимальный расход: {userConstraints.MinFlowRate}");
                Console.WriteLine($"Максимальный расход: {userConstraints.MaxFlowRate}");
                Console.WriteLine($"Минимальный напор: {userConstraints.MinHead}");
                Console.WriteLine($"Максимальный напор: {userConstraints.MaxHead}");
            }
            else
            {
                Console.WriteLine("Не удалось загрузить ограничения пользователя.");
            }
        }
    }
}
