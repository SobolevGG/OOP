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
        /// Появление полей для плавание.
        /// </summary>
        public RunCalcUserControl()
        {
            InitializeComponent();
            // Инициализация ComboBox с вариантами интенсивности
            comboBoxIntensity.Items.AddRange(Enum.GetNames(typeof(Intensity)));
            comboBoxIntensity.SelectedIndex = 0; // Установка начального выбора
        }

        /// <summary>
        /// Ручной ввод параметров.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelWorkingHours_KeyPress(object sender, 
            KeyPressEventArgs e)
        {
            Checks.CheckInput(e);
        }

        /// <summary>
        /// Метод добавления тренировки.
        /// </summary>
        /// <returns></returns>
        public Model.TrainingCalc AddingCalc()
        {
            var runCalc = new RunCalc();

            runCalc.Weight = Checks.CheckNumber(textBoxRate.Text);
            runCalc.Distance = Checks.CheckNumber(textBoxWorkingHours.Text);

            // Получение выбранной
            // интенсивности из ComboBox
            if (Enum.TryParse(comboBoxIntensity.SelectedItem.ToString(), 
                out Intensity selectedIntensity))
            {
                runCalc.Intensity = selectedIntensity;
            }
            else
            {
                // Обработка ошибки, если не удалось
                // преобразовать выбранную интенсивность
                MessageBox.Show("Ошибка при получении " +
                    "выбранной интенсивности.",
                                "Ошибка!", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
            }

            return runCalc;
        }
    }
}