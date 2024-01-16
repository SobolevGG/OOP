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

        // Инициализация переменной userConstraints
        UserConstraints userConstraints = new UserConstraints();



        // Загрузка ограничений пользователя
        userConstraints = userConstraintsFileManager.Load("userConstraints.xml");
        if (userConstraints == null)
        {
            Console.WriteLine("Файл ограничений пользователя не найден. Созданы новые ограничения.");
            userConstraints = new UserConstraints();
        }

        // Ввод новых ограничений
        // InputUserContains(userConstraints);
        // 
        // Сохранение новых ограничений пользователя
        // userConstraintsFileManager.Save("userConstraints.xml", userConstraints);
        // Console.WriteLine("Ограничения пользователя сохранены в файле.");

        // Загрузка файла расходов для каждого гидрогенератора
        GeneratorFlows generatorFlows;
        generatorFlows = generatorFlowsFileManager.Load("generatorFlows.xml");
        if (generatorFlows == null)
        {
            Console.WriteLine("Файл расходов для каждого гидрогенератора не найден. Создан новый файл.");
            generatorFlows = new GeneratorFlows { Flows = new List<double>() };
            generatorFlowsFileManager.Save("generatorFlows.xml", generatorFlows);
        }

        // Создание нового файла с расходами для каждого гидрогенератора
        // generatorFlows = new GeneratorFlows { Flows = new List<double>() };
        // generatorFlowsFileManager.Save("generatorFlows.xml", generatorFlows);
        // Console.WriteLine("Создан новый файл расходов для каждого гидрогенератора.");

        // Проверка наличия достаточного количества расходов для каждого гидрогенератора
        while (generatorFlows.Flows.Count < 12)
        {
            generatorFlows.Flows.Add(0.0);
        }

        // Вывод расходов воды для каждого гидрогенератора
        DisplayGeneratorFlows(generatorFlows);

        // Загрузка формул расчета мощности для каждого гидрогенератора
        List<PowerFormula> formulas = Formulas.LoadFormulas();

        // Сохранение обновленного списка формул в файл
        // Formulas.SaveFormulas(formulas);

        // Начальные точки
        double[] initialFlowRates = generatorFlows.Flows.ToArray();
        double initialHead = (userConstraints.MinHead + userConstraints.MaxHead) / 2.0;


        OptimizationResult result = Formulas.Optimize(initialFlowRates, initialHead, userConstraints.MinHead, userConstraints.MaxHead, formulas);

        double optimalHead = result.OptimalHead;
        double optimalPower = result.MaxPower;

        Console.WriteLine($"Оптимальный напор: {optimalHead} м");
        Console.WriteLine($"Максимальная мощность: {Math.Round(optimalPower / 1e6, 3)} МВт");
    }


    // Дополнительный метод для вывода расходов воды для гидрогенераторов
    private static void DisplayGeneratorFlows(GeneratorFlows generatorFlows)
    {
        Console.WriteLine("Расходы воды для каждого гидрогенератора:");
        for (int i = 0; i < generatorFlows.Flows.Count; i++)
        {
            Console.WriteLine($"Гидрогенератор {i + 1}: {generatorFlows.Flows[i]} куб. м/с");
        }
    }

    private static void InputUserContains(UserConstraints userConstraints)
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
}
