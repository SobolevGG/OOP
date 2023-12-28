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

namespace View
{
    /// <summary>
    /// Добавление оклада
    /// </summary>
    public partial class SwimCalcUserControl : UserControl, ITrainingCalc
    {
        /// <summary>
        /// Добавление оклада
        /// </summary>
        public SwimCalcUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ввод чисел
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            Checks.CheckInput(e);
        }

        /// <summary>
        /// Метод добавления зарплаты
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