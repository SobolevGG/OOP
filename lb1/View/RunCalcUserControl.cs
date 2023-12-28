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
            InitializeComboBox();
        }

        /// <summary>
        /// Метод установки значения по умолчанию - плавание.
        /// </summary>
        private void InitializeComboBox()
        {
            comboBoxIntensity.DataSource 
                = GetRussianIntensityList();

            // Установка начального выбора
            comboBoxIntensity.SelectedIndex 
                = 0;
            comboBoxIntensity.DisplayMember 
                = "Name";
            comboBoxIntensity.ValueMember 
                = "Value";
        }

        /// <summary>
        /// Метод получения всех значений перечисления.
        /// </summary>
        /// <returns>Список с интенсивностями на русском языке.</returns>
        private BindingList<ComboBoxItem> GetRussianIntensityList()
        {
            var intensityValues = Enum.GetValues(typeof(Intensity));
            var intensityList = new BindingList<ComboBoxItem>();

            foreach (Intensity intensity in intensityValues)
            {
                intensityList.Add(new ComboBoxItem
                {
                    Name = GetRussianIntensityName(intensity),
                    Value = intensity
                });
            }

            return intensityList;
        }

        /// <summary>
        /// Метод получения наименования 
        /// интенсивностей по описанию.
        /// </summary>
        /// <param name="intensity">Интенсивность.</param>
        /// <returns>Русское название.</returns>
        private string GetRussianIntensityName(Intensity intensity)
        {
            var fieldInfo = intensity.GetType()
                .GetField(intensity.ToString());
            var descriptionAttribute 
                = (DescriptionAttribute)Attribute
                .GetCustomAttribute(fieldInfo, 
                typeof(DescriptionAttribute));
            return descriptionAttribute?.Description
                   ?? intensity.ToString();
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
                Checks.CheckNumber(textBoxRate.Text);
            runCalc.Distance = 
                Checks.CheckNumber(textBoxWorkingHours.Text);

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
