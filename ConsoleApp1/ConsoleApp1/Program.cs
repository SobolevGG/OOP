﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
// using Extreme.Mathematics;
using Model;
using static Model.Calculation;
using MathNet.Numerics.Optimization;
using System;
using MathNet.Numerics;
using MathNet.Numerics.Optimization.ObjectiveFunctions;
using System;
using Extreme.Mathematics.Calculus.OrdinaryDifferentialEquations;
using System;
using System.Collections.Generic;
using System;
using System.Linq;
using Extreme.Mathematics.Optimization;
using System;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using System;
using System;
using Meta.Numerics;
using Meta.Numerics.Matrices;
using Meta.Numerics.Functions;
using Meta.Numerics.Analysis;
using Npgsql;


namespace Model
{
    public class Program
    {
        public static void Main()
        {
            // Загрузка формул и настройка параметров
            var powerFormulas = Calculation.LoadFormulas();
            double initialHead = /* Ваш начальный напор */93;
            double minFlowRate = /* Ваш минимальный расход воды */ 0;
            double maxFlowRate = /* Ваш максимальный расход воды */ 615;

            // Вызов метода Optimize
            var result = Calculation.Optimize(initialHead, minFlowRate, maxFlowRate);

            // Вывод результатов
            Console.WriteLine($"Оптимальный расход воды: {result.OptimalFlowRate}");
            Console.WriteLine($"Максимальная мощность: {result.MaxPower}");




#if false
            // Создаем экземпляр XmlFileManager для GeneratorFlows
            var generatorFlowsFileManager = new XmlFileManager<GeneratorFlows>();

            // Загрузка файла расходов для каждого гидрогенератора
            GeneratorFlows generatorFlows = generatorFlowsFileManager.Load("generatorFlows.xml");

            // Вывод расходов в консоль
            // Display.DisplayGeneratorFlows(generatorFlows?.Flows);        

            // Создаем экземпляр XmlFileManager для List<PowerFormula>
            var powerFormulaFileManager = new XmlFileManager<List<PowerFormula>>();

            // Загрузка файла формул
            List<PowerFormula> powerFormulas = powerFormulaFileManager.Load("formulas.xml");

            // Вывод формул в консоль
            Display.DisplayFormulas(powerFormulas);



            // Создаем экземпляр XmlFileManager для UserConstraints
            var userConstraintsFileManager = new XmlFileManager<UserConstraints>();

            // Загрузка файла ограничений пользователя
            UserConstraints userConstraints = userConstraintsFileManager.Load("userConstraints.xml");

            // Вывод ограничений пользователя в консоль
            Display.DisplayUserConstraints(userConstraints);


            // CreateNewListAndAddForm("Qi * (96.7 - (Math.Pow(Math.Abs(Qi - 494), 1.78) / Math.Pow(22.5, 2) + Math.Pow(Math.Abs(head - 91), 1.5) / Math.Pow(4, 2)))", "NewFormula");

            // AddInListNewForm("Qi * (96.7 - (Math.Pow(Math.Abs(Qi - 494), 1.78) / Math.Pow(22.5, 2) + Math.Pow(Math.Abs(head - 91), 1.5) / Math.Pow(4, 2)))", "NewFormula321");

            // Пример удаления формулы с индексом 14
            // ListFormulas.RemoveFormByNum(powerFormulaFileManager.Load("formulas.xml"), 14);



#endif

            // Создаем экземпляр XmlFileManager для GeneratorFlows
            var generatorFlowsFileManager = new XmlFileManager<GeneratorFlows>();

            // Загрузка файла расходов для каждого гидрогенератора
            GeneratorFlows generatorFlows = generatorFlowsFileManager.Load("generatorFlows.xml");

            // Предполагается, что есть 12 гидрогенераторов
            double[] initialFlowRates = GeneratorFlow.CheckWaterFlows(generatorFlows, 12);
            //double initialHead = 90.0;


            Dictionary<double, double> _roughZoneSB = new Dictionary<double, double>
        {
            { 79, 200 },
            { 93, 250 }
        };
            MaxLoadRoughZone.InterpolatePower(100, _roughZoneSB);


            PowerCalculation.CalculatePower("formulas.xml", initialFlowRates, initialHead);




        }
    }
}
