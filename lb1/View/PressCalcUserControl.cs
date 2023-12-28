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
        /// <returns></returns>
        public Model.TrainingCalc AddingCalc()
        {
            var pressCalc = new PressCalc();
            pressCalc.Weight =
                Checks.CheckNumber(textBoxWeight.Text);
            pressCalc.Repetitions =
                Checks.CheckNumber(textBoxRepetitions.Text);
            return pressCalc;
        }
    }
}