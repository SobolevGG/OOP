using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Пространство имён View.
/// </summary>
namespace View
{
    /// <summary>
    /// Создание своей тренировки - бег.
    /// </summary>
    public partial class RunCalcUserControl : UserControl, ITrainingCalc
    {
        /// <summary>
        /// Появление полей для бега.
        /// </summary>
        public RunCalcUserControl()
        {
            InitializeComponent();
            InitializeComboBox();
        }

        /// <summary>
        /// Метод инициализации и установки значения 
        /// по умолчанию - бег.
        /// </summary>
        private void InitializeComboBox()
        {
            comboBoxIntensity.DataSource
                = TrainingCalcForm.GetRuEnumList<Model.Intensity>();

            // Установка выбора по умолчанию
            comboBoxIntensity.SelectedIndex = 0;
            comboBoxIntensity.DisplayMember = "Name";
            comboBoxIntensity.ValueMember = "Value";
        }

        /// <summary>
        /// Обработчик события.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_KeyPress(object sender,
            KeyPressEventArgs e)
        {
            Checks.CheckInput(e);
        }

        /// <summary>
        /// Метод проверки данных.
        /// </summary>
        /// <returns>Рассчитанная тренировка.</returns>
        public Model.TrainingCalc AddingCalc()
        {
            var runCalc = new RunCalc();

            runCalc.Weight =
                Checks.CheckNumber(textBoxWeight.Text);
            runCalc.Distance =
                Checks.CheckNumber(textBoxDistance.Text);

            // Получение выбранной интенсивности из ComboBox
            if (comboBoxIntensity.SelectedItem is
                ComboBoxItem selectedIntensityItem)
            {
                runCalc.Intensity =
                    (Intensity)selectedIntensityItem.Value;
            }
            else
            {
                MessageBox.Show("Ошибка при получении " +
                    "выбранной интенсивности.",
                    "Ошибка!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return runCalc;
        }

        /// <summary>
        /// Вложенный класс для русского языка.
        /// </summary>
        private class ComboBoxItem
        {
            public string Name { get; set; }
            public object Value { get; set; }
        }
    }
}