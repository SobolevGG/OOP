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
                throw new ArgumentException("Формула не найдена для указанного генератора.");
            }
        }


        public static OptimizationResult Optimize(double initialHead, double minFlowRate, double maxFlowRate)
        {
            var initialGuess = MathNet.Numerics.LinearAlgebra.Vector<double>.Build.DenseOfArray(new double[] { (minFlowRate + maxFlowRate) / 2.0 });

            Func<MathNet.Numerics.LinearAlgebra.Vector<double>, double> objectiveFunction = point =>
            {
                double flowRate = point[0];
                double power = flowRate * (96.7 - (Math.Pow(Math.Abs(flowRate - 494), 1.78) / Math.Pow(22.5, 2) + Math.Pow(Math.Abs(initialHead - 91), 1.5) / Math.Pow(4, 2)));
                return -power; // Минимизация мощности
            };

            var optimizer = new BfgsBMinimizer(1e-6, 1e-6, 1e-6, 50000);

            var lowerBound = MathNet.Numerics.LinearAlgebra.Vector<double>.Build.DenseOfArray(new double[] { minFlowRate });
            var upperBound = MathNet.Numerics.LinearAlgebra.Vector<double>.Build.DenseOfArray(new double[] { maxFlowRate });

            var objectiveWithGradient = ObjectiveFunction.Gradient(objectiveFunction, point =>
            {
                double flowRate = point[0];
                double gradientFlowRate = (96.7 - (Math.Pow(Math.Abs(flowRate - 494), 1.78) / Math.Pow(22.5, 2) + Math.Pow(Math.Abs(initialHead - 91), 1.5) / Math.Pow(4, 2))) - flowRate *
                    (1.78 * Math.Pow(Math.Abs(flowRate - 494), 0.78) / Math.Pow(22.5, 2) + 1.5 * Math.Pow(Math.Abs(initialHead - 91), 0.5) / Math.Pow(4, 2));
                return MathNet.Numerics.LinearAlgebra.Vector<double>.Build.DenseOfArray(new double[] { gradientFlowRate });
            });

            var result = optimizer.FindMinimum(objectiveWithGradient, lowerBound, upperBound, initialGuess);

            return new OptimizationResult
            {
                OptimalFlowRate = result.MinimizingPoint[0],
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
                Console.WriteLine($"Ошибка сохранения формул: {ex.Message}");
            }
        }

        public class OptimizationResult
        {
            public double OptimalFlowRate { get; set; }
            public double MaxPower { get; set; }
        }
    }
}
