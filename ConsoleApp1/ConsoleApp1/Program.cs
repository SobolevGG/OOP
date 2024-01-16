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



        // Создаем экземпляр XmlFileManager для UserConstraints
        var userConstraintsFileManager = new XmlFileManager<UserConstraints>();

        // Загрузка файла ограничений пользователя
        UserConstraints userConstraints = userConstraintsFileManager.Load("userConstraints.xml");

        // Вывод ограничений пользователя в консоль
        Display.DisplayUserConstraints(userConstraints);


        // CreateNewListAndAddForm("Qi * (96.7 - (Math.Pow(Math.Abs(Qi - 494), 1.78) / Math.Pow(22.5, 2) + Math.Pow(Math.Abs(head - 91), 1.5) / Math.Pow(4, 2)))", "NewFormula");

        // AddInListNewForm("Qi * (96.7 - (Math.Pow(Math.Abs(Qi - 494), 1.78) / Math.Pow(22.5, 2) + Math.Pow(Math.Abs(head - 91), 1.5) / Math.Pow(4, 2)))", "NewFormula321");

        // Пример удаления формулы с индексом 2
        RemoveFormByNum(powerFormulaFileManager.Load("formulas.xml"), 14);

    }

    /// <summary>
    /// Создание нового документа и ввод новой формулы.
    /// </summary>
    public static void CreateNewListAndAddForm(string formulaExpression, string nameFormula)
    {
        string newFormulaExpression = formulaExpression;

        var powerFormulaFileManager = new XmlFileManager<List<PowerFormula>>();

        // Создание нового списка формул
        List<PowerFormula> powerFormulas = new List<PowerFormula>();

        // Добавление новой формулы в список
        PowerFormula newFormula = new PowerFormula
        {
            Name = nameFormula, // Вы можете выбрать любое уникальное имя
            FormulaExpression = newFormulaExpression
        };

        powerFormulas.Add(newFormula);

        // Сохранение списка формул в XML-файл
        powerFormulaFileManager.Save("newFormulas.xml", powerFormulas);
    }

    /// <summary>
    /// Ввод новой формулы в список.
    /// </summary>
    public static void AddInListNewForm(string newFormulaExpression, string nameNewFormula)
    {
        // Создаем экземпляр XmlFileManager для List<PowerFormula>
        var powerFormulaFileManager = new XmlFileManager<List<PowerFormula>>();

        // Загрузка файла формул
        List<PowerFormula> powerFormulas = powerFormulaFileManager.Load("formulas.xml");

        // Добавление новой формулы в список
        PowerFormula newFormula = new PowerFormula
        {
            Name = nameNewFormula, // Вы можете выбрать любое уникальное имя
            FormulaExpression = newFormulaExpression
        };

        powerFormulas.Add(newFormula);

        // Сохранение обновленного списка формул в XML-файл
        powerFormulaFileManager.Save("formulas.xml", powerFormulas);
    }

    /// <summary>
    /// Метод удаления формулы из списка и последующего сохранения в XML-документ.
    /// </summary>
    /// <param name="powerFormulas">Список формул.</param>
    /// <param name="index">Номер формулы.</param>
    public static void RemoveFormByNum(List<PowerFormula> powerFormulas, int index)
    {
        if (powerFormulas != null && index >= 0 && index < powerFormulas.Count)
        {
            powerFormulas.RemoveAt(index);

            // Сохранение обновленного списка формул в XML-файл
            var powerFormulaFileManager = new XmlFileManager<List<PowerFormula>>();
            powerFormulaFileManager.Save("formulas.xml", powerFormulas);
        }
        else
        {
            Console.WriteLine("Invalid index or formulas list is null.");
        }
    }

}
