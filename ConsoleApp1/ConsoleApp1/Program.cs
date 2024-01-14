using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using HydroGeneratorOptimization;
using static HydroGeneratorOptimization.Formulas;

class Program
{
    static void Main()
    {
        // Создаем экземпляры XmlFileManager для UserConstraints и GeneratorFlows
        var userConstraintsFileManager = new XmlFileManager<UserConstraints>();
        var generatorFlowsFileManager = new XmlFileManager<GeneratorFlows>();

        while (true)
        {
            // Инициализация переменной userConstraints
            UserConstraints userConstraints = new UserConstraints();

            // Опции выбора загрузки
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Загрузить ограничения пользователя из файла");
            Console.WriteLine("2. Ввести новые ограничения пользователя");
            Console.WriteLine("3. Загрузить файл расходов для каждого гидрогенератора");
            Console.WriteLine("4. Ввести новые расходы воды для каждого гидрогенератора и сохранить в файл");
            Console.WriteLine("5. Загрузить расходы воды для каждого гидрогенератора из файла");
            Console.WriteLine("6. Продолжить с текущими ограничениями и расходами (если они существуют)");

            int choice;
            do
            {
                Console.Write("Введите номер выбранной опции: ");
            } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6);

            // Загрузка ограничений пользователя
            if (choice == 1)
            {
                userConstraints = userConstraintsFileManager.Load("userConstraints.xml");
                if (userConstraints == null)
                {
                    Console.WriteLine("Файл ограничений пользователя не найден. Созданы новые ограничения.");
                    userConstraints = new UserConstraints();
                }
            }
            else if (choice == 2)
            {
                Console.Write("Введите минимальное значение расхода (куб. м/с): ");
                userConstraints.MinFlowRate = Convert.ToDouble(Console.ReadLine());

                Console.Write("Введите максимальное значение расхода (куб. м/с): ");
                userConstraints.MaxFlowRate = Convert.ToDouble(Console.ReadLine());

                Console.Write("Введите минимальное значение напора (м): ");
                userConstraints.MinHead = Convert.ToDouble(Console.ReadLine());

                Console.Write("Введите максимальное значение напора (м): ");
                userConstraints.MaxHead = Convert.ToDouble(Console.ReadLine());

                // Сохранение новых ограничений пользователя
                userConstraintsFileManager.Save("userConstraints.xml", userConstraints);
                Console.WriteLine("Ограничения пользователя сохранены в файле.");
            }

            // Загрузка файла расходов для каждого гидрогенератора
            GeneratorFlows generatorFlows;
            if (choice == 3 || choice == 5 || choice == 6)
            {
                generatorFlows = generatorFlowsFileManager.Load("generatorFlows.xml");
                if (generatorFlows == null)
                {
                    Console.WriteLine("Файл расходов для каждого гидрогенератора не найден. Создан новый файл.");
                    generatorFlows = new GeneratorFlows { Flows = new List<double>() };
                    generatorFlowsFileManager.Save("generatorFlows.xml", generatorFlows);
                }
            }
            else
            {
                // Создание нового файла с расходами для каждого гидрогенератора
                generatorFlows = new GeneratorFlows { Flows = new List<double>() };
                generatorFlowsFileManager.Save("generatorFlows.xml", generatorFlows);
                Console.WriteLine("Создан новый файл расходов для каждого гидрогенератора.");
            }

            // Проверка наличия достаточного количества расходов для каждого гидрогенератора
            while (generatorFlows.Flows.Count < 12)
            {
                generatorFlows.Flows.Add(0.0);
            }

            // Ввод или загрузка расходов воды для каждого гидрогенератора
            if (choice == 4)
            {
                for (int i = 0; i < generatorFlows.Flows.Count; i++)
                {
                    Console.Write($"Введите расход воды для гидрогенератора {i + 1}: ");
                    generatorFlows.Flows[i] = Convert.ToDouble(Console.ReadLine());
                }

                // Сохранение новых расходов в файл
                generatorFlowsFileManager.Save("generatorFlows.xml", generatorFlows);
                Console.WriteLine("Расходы воды сохранены в файле.");
            }
            else if (choice == 5)
            {
                generatorFlows = generatorFlowsFileManager.Load("generatorFlows.xml");
                if (generatorFlows == null)
                {
                    Console.WriteLine("Файл расходов для каждого гидрогенератора не найден. Создан новый файл.");
                    generatorFlows = new GeneratorFlows { Flows = new List<double>() };
                    generatorFlowsFileManager.Save("generatorFlows.xml", generatorFlows);
                }
            }

            // Загрузка формул расчета мощности для каждого гидрогенератора
            List<PowerFormula> formulas = Formulas.LoadFormulas();
            if (formulas.Count == 0)
            {
                // Добавление формулы FormulaForAll, если список пуст
                formulas.Add(new PowerFormula { Name = "FormulaForAll", Formula = "FormulaForAll" });
            }

            Console.WriteLine("Выберите формулу мощности:");

            for (int i = 0; i < formulas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {formulas[i].Name}");
            }

            int selectedFormulaIndex;

            do
            {
                Console.Write("Введите номер выбранной формулы: ");
            } while (!int.TryParse(Console.ReadLine(), out selectedFormulaIndex) || selectedFormulaIndex < 1 || selectedFormulaIndex > formulas.Count);

            PowerFormula selectedFormula = formulas[selectedFormulaIndex - 1];

            Console.WriteLine($"Выбрана формула мощности: {selectedFormula.Name}");

            double[] initialFlowRates = generatorFlows.Flows.ToArray();

            double initialHead = (userConstraints.MinHead + userConstraints.MaxHead) / 2.0;

            // Загрузка формул расчета мощности для каждого гидрогенератора
            List<GeneratorFormula> generatorFormulas = Formulas.LoadGeneratorFormulas();

            var initialGuess = MathNet.Numerics.LinearAlgebra.Vector<double>.Build.DenseOfArray(new double[] { initialHead });

            Console.WriteLine("Формулы для каждого гидрогенератора:");

            for (int i = 0; i < initialFlowRates.Length; i++)
            {
                string formulaName = Formulas.GetGeneratorFormula(generatorFormulas, i + 1);
                Console.WriteLine($"Генератор {i + 1}: {formulaName}");
            }

            OptimizationResult result = Formulas.Optimize(initialFlowRates, initialHead, userConstraints.MinHead, userConstraints.MaxHead, generatorFormulas);

            double optimalHead = result.OptimalHead;
            double optimalPower = result.MaxPower;

            Console.WriteLine($"Оптимальный напор: {optimalHead} м");
            Console.WriteLine($"Максимальная мощность: {Math.Round(optimalPower / 1e6, 3)} МВт");

            // Переход на новый цикл или завершение программы
            Console.WriteLine("Хотите выполнить еще одно действие? (да/нет): ");
            string continueChoice = Console.ReadLine().ToLower();
            if (continueChoice != "да")
            {
                break; // Завершение бесконечного цикла
            }
        }
    }
}
