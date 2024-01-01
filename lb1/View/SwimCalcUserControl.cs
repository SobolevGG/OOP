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
            comboBoxStyle.DataSource = GetRuStyleList();

            // Установка начального выбора
            comboBoxStyle.SelectedIndex = 0;
            comboBoxStyle.DisplayMember = "Name";
            comboBoxStyle.ValueMember = "Value";
        }

        /// <summary>
        /// Метод получения значений перечисления стилей 
        /// плавания на русском языке.
        /// </summary>
        /// <returns>Список с русскими названиями 
        /// стилей плавания.</returns>
        private BindingList<ComboBoxItem> GetRuStyleList()
        {
            var styleValues = Enum.GetValues(typeof(Style));
            var styleList = new BindingList<ComboBoxItem>();

            foreach (Style style in styleValues)
            {
                styleList.Add(new ComboBoxItem
                {
                    Name = GetRuEnumDescrip(style),
                    Value = style
                });
            }

            return styleList;
        }

        /// <summary>
        /// Метод получения русского наименования 
        /// перечисления по описанию.
        /// </summary>
        /// <param name="enumValue">Значение перечисления.</param>
        /// <returns>Русское название перечисления.</returns>
        public static string GetRuEnumDescrip(Enum enumValue)
        {
            var fieldInfo = enumValue.GetType()
                .GetField(enumValue.ToString());
            var description = (DescriptionAttribute)Attribute
                .GetCustomAttribute(fieldInfo, 
                typeof(DescriptionAttribute));

            if (description != null 
                && !string.IsNullOrEmpty(description.Description))
            {
                return description.Description;
            }
            else
            {
                return enumValue.ToString();
            }
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
        private class ComboBoxItem
        {
            public string Name { get; set; }
            public object Value { get; set; }
        }
    }
}