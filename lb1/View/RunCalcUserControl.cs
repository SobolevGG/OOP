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
    /// Добавление тарифной ставки
    /// </summary>
    public partial class RunCalcUserControl : UserControl, ITrainingCalc
    {
        /// <summary>
        /// Добавлвение тарифной ставки
        /// </summary>
        public RunCalcUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ввод чисел
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelWorkingHours_KeyPress(object sender, 
            KeyPressEventArgs e)
        {
            Checks.CheckInput(e);
        }

        /// <summary>
        /// Метод добавления зарплаты
        /// </summary>
        /// <returns></returns>
        public Model.TrainingCalc AddingCalc()
        {
            var runCalc = new RunCalc();

            runCalc.Weight = Checks.CheckNumber(textBoxRate.Text);
            runCalc.Distance = 
                Checks.CheckNumber(textBoxWorkingHours.Text);
            // runCalc.Intensity =
                Checks.CheckNumber(textBoxWorkingHours.Text);
            return runCalc;
        }
    }
}