﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq.Dynamic.Core;
    using System.Linq.Expressions;
    using System.Xml.Serialization;
    using Model;
    using static Model.Calculation;

    public class PowerCalculation
    {
        public static void CalculatePower(string formulasFilePath, double[] flowRates, double head)
        {
            List<Calculation.PowerFormula> powerFormulas = LoadFormulas(formulasFilePath);

            if (powerFormulas.Count == 0)
            {
                // Если в документе отсутствуют формулы, производим расчёт по указанной формуле
                double power = DefaultPowerCalculation(flowRates, head);
                Console.WriteLine($"Мощность рассчитывается по формуле по умолчанию: {power}");
            }
            else
            {
                // Производим расчёт мощности ГЭС с учётом формул
                double power = CalculatePower(flowRates, head, powerFormulas);
                Console.WriteLine($"Мощность рассчитывается по пользовательским формулам: {power}");
            }
        }

        public static double DefaultPowerCalculation(double[] flowRates, double head)
        {
            return CalculatePower(flowRates, head, new List<Calculation.PowerFormula>());
        }

        public static List<Calculation.PowerFormula> LoadFormulas(string formulasFilePath)
        {
            List<Calculation.PowerFormula> formulas;

            try
            {
                using (var streamReader = new StreamReader(formulasFilePath))
                {
                    var serializer = new XmlSerializer(typeof(List<Calculation.PowerFormula>));
                    formulas = (List<Calculation.PowerFormula>)serializer.Deserialize(streamReader);

                    foreach (var formula in formulas)
                    {
                        formula.Formula = BuildFormulaDelegate(formula.FormulaExpression);
                    }
                }
            }
            catch
            {
                formulas = new List<Calculation.PowerFormula>();
            }

            return formulas;
        }

        public static Func<double, double, double> BuildFormulaDelegate(string formulaExpression)
        {
            var QiParam = Expression.Parameter(typeof(double), "Qi");
            var headParam = Expression.Parameter(typeof(double), "head");

            var formulaLambda = DynamicExpressionParser.ParseLambda(
                new[] { QiParam, headParam },
                null,
                formulaExpression
            );

            return (Func<double, double, double>)formulaLambda.Compile();
        }

        public static double CalculatePower(double[] flowRates, double head, List<PowerFormula> formulas)
        {
            const double rho = 1000.0;
            double sum = 0.0;

            for (int i = 0; i < flowRates.Length; i++)
            {
                double Qi = flowRates[i];

                var formula = formulas.FirstOrDefault(f => f.Name == $"HU{i + 1}");

                if (formula == null)
                {
                    formula = formulas.FirstOrDefault(f => f.Name == "Default");
                }

                if (formula != null)
                {
                    sum += formula.Formula(Qi, head);
                }
            }

            double power = 0.01 * head * g * rho * sum;
            return power;
        }

    }
}
