﻿using Model;
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
                = GetRuIntensityList();

            // Установка выбора по умолчанию
            comboBoxIntensity.SelectedIndex = 0;
            comboBoxIntensity.DisplayMember = "Name";
            comboBoxIntensity.ValueMember = "Value";
        }

        /// <summary>
        /// Метод получения всех значений перечисления.
        /// </summary>
        /// <returns>Список с интенсивностями на русском языке.</returns>
        private BindingList<ComboBoxItem> GetRuIntensityList()
        {
            var intensityValues = Enum.GetValues(typeof(Intensity));
            var intensityRuList = new BindingList<ComboBoxItem>();

            foreach (Intensity intensity in intensityValues)
            {
                intensityRuList.Add(new ComboBoxItem
                {
                    Name = TrainingCalc.GetRuEnumDescrip(intensity),
                    Value = intensity
                });
            }

            return intensityRuList;
        }

        /// <summary>
        /// Обработчик события.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelKeyPress(object sender,
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
                Checks.CheckDouble(textBoxWeight.Text);
            runCalc.Distance =
                Checks.CheckDouble(textBoxDistance.Text);

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