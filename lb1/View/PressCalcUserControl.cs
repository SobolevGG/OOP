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
    /// Ручной ввод тренировки - жим штанги.
    /// </summary>
    public partial class PressCalcUserControl : UserControl, ITrainingCalc
    {
        /// <summary>
        /// Добавление тренировки.
        /// </summary>
        public PressCalcUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Вввод значений.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelHourlyWageRate_KeyPress(object sender,
            KeyPressEventArgs e)
        {
            Checks.CheckInput(e);
        }

        /// <summary>
        /// Метод добавления тренировки - жим штанги.
        /// </summary>
        /// <returns>Тренировка - жим штанги.</returns>
        /// <exception cref="Exception">Исключение
        /// на нецелочисленный ввод.</exception>
        public Model.TrainingCalc AddingCalc()
        {
            var pressCalc = new PressCalc();
            pressCalc.Weight =
                Checks.CheckDouble(textBoxWeight.Text);

            // Пытаемся преобразовать строку в int
            if (!int.TryParse(textBoxRepetitions.Text,
                out int checkedInt))
            {
                // Если преобразование не удалось, вызываем исключение
                throw new Exception("значение должно быть " +
                    "целочисленным и положительным!");
            };

            pressCalc.Repetitions = checkedInt;
            return pressCalc;
        }
    }
}