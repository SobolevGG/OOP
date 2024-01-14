using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Optimization;
using MathNet.Numerics.Optimization.ObjectiveFunctions;
using MathNet.Numerics.Optimization.TrustRegion;
using HydroGeneratorOptimization;
using static HydroGeneratorOptimization.HydroGeneratorOptimization;


class HydroGenerator
{
    static void Main()
    {
        List<PowerFormula> formulas = LoadFormulas();

        if (formulas.Count == 0)
        {
            // Add default formulas if the list is empty
            formulas.Add(new PowerFormula { Name = "FormulaForAll", Formula = "FormulaForAll" });
            // Add more default formulas as needed
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

        Console.Write("Введите минимальное значение расхода (куб. м/с): ");
        double minFlowRate = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите максимальное значение расхода (куб. м/с): ");
        double maxFlowRate = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите минимальное значение напора (м): ");
        double minHead = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите максимальное значение напора (м): ");
        double maxHead = Convert.ToDouble(Console.ReadLine());

        double[] initialFlowRates = new double[12];

        for (int i = 0; i < initialFlowRates.Length; i++)
        {
            Console.Write($"Введите расход для гидрогенератора {i + 1}: ");
            initialFlowRates[i] = Convert.ToDouble(Console.ReadLine());
        }

        double initialHead = (minHead + maxHead) / 2.0;

        var initialGuess = Vector<double>.Build.DenseOfArray(new double[] { initialHead });

        Func<Vector<double>, double> objectiveFunction = point =>
        {
            double head = point[0];
            double power = -CalculatePower(initialFlowRates, head, selectedFormula.Formula);
            return power;
        };

        var optimizer = new BfgsBMinimizer(1e-6, 1e-6, 1e-6, 50000);

        var lowerBound = Vector<double>.Build.DenseOfArray(new double[] { minHead });
        var upperBound = Vector<double>.Build.DenseOfArray(new double[] { maxHead });

        var objectiveWithGradient = ObjectiveFunction.Gradient(objectiveFunction, point =>
        {
            double head = point[0];
            double sum = 0.0;

            foreach (var Qi in initialFlowRates)
            {
                sum += EvaluateFormula(Qi, head, selectedFormula.Formula);
            }

            double gradientHead = -0.01 * g * (96.7 - sum) * Math.Pow(Math.Abs(head - 93), 0.5) / Math.Pow(4, 2);
            return Vector<double>.Build.DenseOfArray(new double[] { gradientHead });
        });

        var result = optimizer.FindMinimum(objectiveWithGradient, lowerBound, upperBound, initialGuess);

        double optimalHead = result.MinimizingPoint[0];
        double optimalPower = -result.FunctionInfoAtMinimum.Value;

        Console.WriteLine($"Оптимальный напор: {optimalHead} м");
        Console.WriteLine($"Максимальная мощность: {Math.Round(optimalPower / 1e6, 3)} МВт");
    }
}