using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Xml.Serialization;
using HydroGeneratorOptimization;
using MathNet.Numerics.Optimization;

namespace HydroGeneratorOptimization
{
    public class Formulas
    {
        [Serializable]
        public class PowerFormula
        {
            public string Name { get; set; }
            public string FormulaExpression { get; set; }

            [XmlIgnore]
            public Func<double, double, double> Formula { get; set; }
        }

        public const double g = 9.81;

        

        public static PowerFormula GetGeneratorFormula(List<PowerFormula> formulas, int generatorNumber)
        {
            var formula = formulas.FirstOrDefault(f => f.Name == $"HU{generatorNumber}");
            return formula ?? formulas.FirstOrDefault(f => f.Name == "Default");
        }

        public static double EvaluateFormula(double Qi, double head, PowerFormula formula)
        {
            if (formula != null && formula.Formula != null)
            {
                return formula.Formula(Qi, head);
            }
            else
            {
                throw new ArgumentException("Formula not found for the specified generator.");
            }
        }


        public static OptimizationResult Optimize(double[] initialFlowRates, double initialHead, double minHead, double maxHead, List<PowerFormula> powerFormulas)
        {
            var initialGuess = MathNet.Numerics.LinearAlgebra.Vector<double>.Build.DenseOfArray(new double[] { initialHead });

            Func<MathNet.Numerics.LinearAlgebra.Vector<double>, double> objectiveFunction = point =>
            {
                double head = point[0];
                double power = -PowerCalculation.CalculatePower(initialFlowRates, head, powerFormulas);
                return power;
            };

            var optimizer = new BfgsBMinimizer(1e-6, 1e-6, 1e-6, 50000);

            var lowerBound = MathNet.Numerics.LinearAlgebra.Vector<double>.Build.DenseOfArray(new double[] { minHead });
            var upperBound = MathNet.Numerics.LinearAlgebra.Vector<double>.Build.DenseOfArray(new double[] { maxHead });

            var objectiveWithGradient = ObjectiveFunction.Gradient(objectiveFunction, point =>
            {
                double head = point[0];
                double sum = 0.0;

                for (int i = 0; i < initialFlowRates.Length; i++)
                {
                    double Qi = initialFlowRates[i];
                    // Выбирается формула согласно списку, если ее нет, то по умолчанию
                    var formula = GetGeneratorFormula(powerFormulas, i + 1);
                    sum += EvaluateFormula(Qi, head, formula);
                }

                double gradientHead = -0.01 * g * (96.7 - sum) * Math.Pow(Math.Abs(head - 93), 0.5) / Math.Pow(4, 2);
                return MathNet.Numerics.LinearAlgebra.Vector<double>.Build.DenseOfArray(new double[] { gradientHead });
            });

            var result = optimizer.FindMinimum(objectiveWithGradient, lowerBound, upperBound, initialGuess);

            return new OptimizationResult
            {
                OptimalHead = result.MinimizingPoint[0],
                MaxPower = -result.FunctionInfoAtMinimum.Value
            };
        }

        public static List<PowerFormula> LoadFormulas()
        {
            List<PowerFormula> formulas;

            try
            {
                using (var streamReader = new StreamReader("formulas.xml"))
                {
                    var serializer = new XmlSerializer(typeof(List<PowerFormula>));
                    formulas = (List<PowerFormula>)serializer.Deserialize(streamReader);

                    foreach (var formula in formulas)
                    {
                        formula.Formula = PowerCalculation.BuildFormulaDelegate(formula.FormulaExpression);
                    }
                }
            }
            catch
            {
                formulas = new List<PowerFormula>();
            }

            return formulas;
        }

        public static void SaveFormulas(List<PowerFormula> formulas)
        {
            try
            {
                using (var streamWriter = new StreamWriter("formulas.xml"))
                {
                    var serializer = new XmlSerializer(typeof(List<PowerFormula>));
                    serializer.Serialize(streamWriter, formulas);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving formulas: {ex.Message}");
            }
        }

        public class OptimizationResult
        {
            public double OptimalHead { get; set; }
            public double MaxPower { get; set; }
        }
    }
}
