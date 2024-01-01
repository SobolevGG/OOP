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

            // Инициализация бокса с вариантами стилей плавания
            comboBoxStyle.DataSource = TrainingCalcForm.GetRuEnumList<Model.Style>();

            // Установка начального выбора
            comboBoxStyle.SelectedIndex = 0;
            comboBoxStyle.DisplayMember = "Name";
            comboBoxStyle.ValueMember = "Value";
        }

        /// <summary>
        /// Ручной ввод параметров.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelSwim_KeyPress(object sender, 
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
            var swimCalc = new SwimCalc();

            swimCalc.Weight = 
                Checks.CheckNumber(textBoxWeight.Text);
            swimCalc.Distance = 
                Checks.CheckNumber(textBoxDistance.Text);

            // Получение выбранного стиля из ComboBox
            if (comboBoxStyle.SelectedItem 
                is ComboBoxItem selectedStyleItem)
            {
                swimCalc.Style = (Style)selectedStyleItem.Value;
            }
            else
            {
                // Если не удалось преобразовать выбранный стиль
                MessageBox.Show("Ошибка при получении " +
                    "выбранного стиля плавания.",
                                "Ошибка!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

            return swimCalc;
        }

        /// <summary>
        /// Вложенный класс для русского языка.
        /// </summary>
        public class ComboBoxItem
        {
            public string Name { get; set; }
            public object Value { get; set; }
        }
    }
}