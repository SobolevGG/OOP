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

            swimCalc.Weight = 
                Checks.CheckNumber(textBoxSalary.Text);
            swimCalc.Distance = 
                Checks.CheckNumber(textBoxDaysInMonth.Text);
            // swimCalc.Style = 
                Checks.CheckNumber(textBoxWorkingDays.Text);

            return swimCalc;
        }
    }
}