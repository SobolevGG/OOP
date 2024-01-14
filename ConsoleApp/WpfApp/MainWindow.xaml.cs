using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Serialization;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Optimization;
using MathNet.Numerics.Optimization.ObjectiveFunctions;
using MathNet.Numerics.Optimization.TrustRegion;

namespace HydroGeneratorOptimization
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<PowerFormula> formulas;

        public MainWindow()
        {
            InitializeComponent();
            formulas = new ObservableCollection<PowerFormula>(LoadFormulas());
            formulaComboBox.ItemsSource = formulas;
            initialFlowRatesItemsControl.ItemsSource = Enumerable.Range(1, 12).Select(i => new { DisplayName = $"Гидрогенератор {i}", Value = 0.0 });
        }

        private List<PowerFormula> LoadFormulas()
        {
            List<PowerFormula> loadedFormulas;

            try
            {
                using (var streamReader = new StreamReader("formulas.xml"))
                {
                    var serializer = new XmlSerializer(typeof(List<PowerFormula>));
                    loadedFormulas = (List<PowerFormula>)serializer.Deserialize(streamReader);
                }
            }
            catch
            {
                loadedFormulas = new List<PowerFormula>();
            }

            return loadedFormulas;
        }

        private void SaveFormulas()
        {
            try
            {
                using (var streamWriter = new StreamWriter("formulas.xml"))
                {
                    var serializer = new XmlSerializer(typeof(List<PowerFormula>));
                    serializer.Serialize(streamWriter, formulas.ToList());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving formulas: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddFormula_Click(object sender, RoutedEventArgs e)
        {
            var newFormulaWindow = new NewFormulaWindow();
            if (newFormulaWindow.ShowDialog() == true)
            {
                formulas.Add(new PowerFormula { Name = newFormulaWindow.FormulaName, Formula = newFormulaWindow.FormulaExpression });
                SaveFormulas();
            }
        }

        private void RunOptimization_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double minFlowRate = Convert.ToDouble(minFlowRateTextBox.Text);
                double maxFlowRate = Convert.ToDouble(maxFlowRateTextBox.Text);
                double minHead = Convert.ToDouble(minHeadTextBox.Text);
                double maxHead = Convert.ToDouble(maxHeadTextBox.Text);

                double[] initialFlowRates = initialFlowRatesItemsControl.Items.OfType<dynamic>().Select(item => Convert.ToDouble(item.Value)).ToArray();

                int selectedFormulaIndex = formulaComboBox.SelectedIndex;

                if (selectedFormulaIndex < 0 || selectedFormulaIndex >= formulas.Count)
                {
                    MessageBox.Show("Выберите формулу мощности.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                PowerFormula selectedFormula = formulas[selectedFormulaIndex];

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

                MessageBox.Show($"Оптимальный напор: {optimalHead} м\nМаксимальная мощность: {Math.Round(optimalPower / 1e6, 3)} МВт", "Результат оптимизации", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выполнении оптимизации: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private double CalculatePower(double[] flowRates, double head, string formula)
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

        private double EvaluateFormula(double Qi, double head, string formula)
        {
            switch (formula)
            {
                case "Formula1":
                    return Qi * (96.7 - (
                        Math.Pow(Math.Abs(Qi - 490), 1.78) / Math.Pow(22.5, 2) +
                        Math.Pow(Math.Abs(head - 93), 1.5) / Math.Pow(4, 2)
                    ));

                default:
                    throw new ArgumentException("Invalid power formula specified.");
            }
        }
    }
}
