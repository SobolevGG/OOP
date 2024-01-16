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
        // Создаем экземпляр XmlFileManager для GeneratorFlows
        var generatorFlowsFileManager = new XmlFileManager<GeneratorFlows>();

        // Загрузка файла расходов для каждого гидрогенератора
        GeneratorFlows generatorFlows = generatorFlowsFileManager.Load("generatorFlows.xml");

        // Вывод расходов в консоль
        Display.DisplayGeneratorFlows(generatorFlows?.Flows);




        // Создаем экземпляр XmlFileManager для List<PowerFormula>
        var powerFormulaFileManager = new XmlFileManager<List<PowerFormula>>();

        // Загрузка файла формул
        List<PowerFormula> powerFormulas = powerFormulaFileManager.Load("formulas.xml");

        // Вывод формул в консоль
        Display.DisplayFormulas(powerFormulas);
    }
}
