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
    /// Создание своей тренировки - плавание.
    /// </summary>
    public partial class SwimCalcUserControl : UserControl, ITrainingCalc
    {
        /// <summary>
        /// Появление полей для плавание.
        /// </summary>
        public SwimCalcUserControl()
        {
            InitializeComponent();

            // Инициализация ComboBox с вариантами стилей плавания
            comboBoxStyle.Items.AddRange(Enum.GetNames(typeof(Style)));

            // Установка начального выбора
            comboBoxStyle.SelectedIndex = 0;
        }

        /// <summary>
        /// Ручной ввод параметров.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            Checks.CheckInput(e);
        }

        /// <summary>
        /// Метод добавления тренировки.
        /// </summary>
        /// <returns></returns>
        public Model.TrainingCalc AddingCalc()
        {
            var swimCalc = new SwimCalc();

            swimCalc.Weight = Checks.CheckNumber(textBoxSalary.Text);
            swimCalc.Distance = Checks.CheckNumber(textBoxDaysInMonth.Text);

            // Получение выбранного стиля из ComboBox
            if (Enum.TryParse(comboBoxStyle.SelectedItem.ToString(), out Style selectedStyle))
            {
                swimCalc.Style = selectedStyle;
            }
            else
            {
                // Обработка ошибки, если не удалось преобразовать выбранный стиль
                MessageBox.Show("Ошибка при получении выбранного стиля плавания.",
                                "Ошибка!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

            return swimCalc;
        }
    }
}