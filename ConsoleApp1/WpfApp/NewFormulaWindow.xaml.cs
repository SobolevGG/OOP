using System;
using System.Windows;

namespace HydroGeneratorOptimization
{
    public partial class NewFormulaWindow : Window
    {
        public string FormulaName { get; private set; }
        public string FormulaExpression { get; private set; }

        public NewFormulaWindow()
        {
            InitializeComponent();
        }

        private void AddFormula_Click(object sender, RoutedEventArgs e)
        {
            FormulaName = formulaNameTextBox.Text;
            FormulaExpression = formulaExpressionTextBox.Text;

            if (string.IsNullOrWhiteSpace(FormulaName) || string.IsNullOrWhiteSpace(FormulaExpression))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DialogResult = true;
            }
        }
    }
}
