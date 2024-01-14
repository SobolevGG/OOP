using HydroGeneratorOptimization;
using MathNet.Numerics.Optimization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Optimization;
using MathNet.Numerics.Optimization.ObjectiveFunctions;
using MathNet.Numerics.Optimization.TrustRegion;

namespace HydroGeneratorOptimization
{
    public class HydroGeneratorOptimization
    {
        [Serializable]
        public class PowerFormula
        {
            public string Name { get; set; }
            public string Formula { get; set; }
        }

        public const double g = 9.81;

        public static double CalculatePower(double[] flowRates, double head, string formula)
        {
            const double rho = 1000.0;
            double sum = 0.0;

            foreach (var Qi in flowRates)
            {
                sum += EvaluateFormula(Qi, head, formula);
            }

            double power = 0.01 * head * g * rho * sum;
            return power;
        }

        public static double EvaluateFormula(double Qi, double head, string formula)
        {
            switch (formula)
            {
                case "FormulaForAll":
                    return Qi * (96.7 - (
                        Math.Pow(Math.Abs(Qi - 490), 1.78) / Math.Pow(22.5, 2) +
                        Math.Pow(Math.Abs(head - 93), 1.5) / Math.Pow(4, 2)
                    ));

                // Add more formulas as needed
                // case "Formula2":
                //    return ...;

                default:
                    throw new ArgumentException("Invalid power formula specified.");
            }
        }

        public static OptimizationResult Optimize(double[] initialFlowRates, double initialHead, double minHead, double maxHead, string selectedFormula)
        {
            var initialGuess = MathNet.Numerics.LinearAlgebra.Vector<double>.Build.DenseOfArray(new double[] { initialHead });

            Func<MathNet.Numerics.LinearAlgebra.Vector<double>, double> objectiveFunction = point =>
            {
                double head = point[0];
                double power = -CalculatePower(initialFlowRates, head, selectedFormula);
                return power;
            };

            var optimizer = new BfgsBMinimizer(1e-6, 1e-6, 1e-6, 50000);

            var lowerBound = MathNet.Numerics.LinearAlgebra.Vector<double>.Build.DenseOfArray(new double[] { minHead });
            var upperBound = MathNet.Numerics.LinearAlgebra.Vector<double>.Build.DenseOfArray(new double[] { maxHead });

            var objectiveWithGradient = ObjectiveFunction.Gradient(objectiveFunction, point =>
            {
                double head = point[0];
                double sum = 0.0;

                foreach (var Qi in initialFlowRates)
                {
                    sum += EvaluateFormula(Qi, head, selectedFormula);
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
