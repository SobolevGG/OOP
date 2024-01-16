using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using HydroGeneratorOptimization;
using static HydroGeneratorOptimization.Formulas;

public class Program
{
    public static void Main()
    {
#if !DEBUG

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





        // Создаем экземпляр XmlFileManager для GeneratorFlows
        var generatorFlowsFileManager = new XmlFileManager<GeneratorFlows>();

        // Загрузка файла расходов для каждого гидрогенератора
        GeneratorFlows generatorFlows = generatorFlowsFileManager.Load("generatorFlows.xml");

        // Предполагается, что есть 12 гидрогенераторов
        double[] initialFlowRates = GeneratorFlow.CheckWaterFlows(generatorFlows, 12);
        double initialHead = 90.0;






        PowerCalculation.CalculatePower("formulas.xml", initialFlowRates, initialHead);
#endif

        

    }

    
}
