using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace View
{
    public partial class AddTrainingForm : Form
    {
        /// <summary>
        /// Делегат для добавления заработной платы.
        /// </summary>
        public EventHandler<EventArgs> AddingTrainings;

        /// <summary>
        /// Переменная для словаря UserControl
        /// </summary>
        private readonly Dictionary<string, UserControl>
            _comboBoxToUserControl;

        /// <summary>
        /// Метка UserControl.
        /// </summary>
        private UserControl _userControl;

        public AddTrainingForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            Size = new Size(300, 271);
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            buttonOk.Enabled = false;
            comboTrainingSelection.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            string[] typeTraining = { "Жим штанги",
                                      "Плавание", 
                                      "Бег" };
            
            comboTrainingSelection.Items.AddRange(new string[] {
            typeTraining[0], typeTraining[1], typeTraining[2]});

            _comboBoxToUserControl = new Dictionary<string, 
                UserControl>()
            {
                {typeTraining[0], pressCalcWageRateUserControl },
                {typeTraining[1], swimCalcUserControl },
                {typeTraining[2], runCalcUserControl },
            };
        }

        /// <summary>
        /// Выбор тренировки в комбобоксе.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxSalarySelection(object sender, EventArgs e)
        {
            string wageType = comboTrainingSelection.SelectedItem.ToString();
            foreach (var (wageValue, userControlTmp) in _comboBoxToUserControl)
            {
                userControlTmp.Visible = false;
                if (wageType == wageValue)
                {
                    userControlTmp.Visible = true;
                    buttonOk.Enabled = true;
                    this._userControl = userControlTmp;
                }
            }
        }
        
        /// <summary>
        /// Кнопка ОК.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOk(object sender, EventArgs e)
        {
            try
            {
                var wagesControlName = 
                    comboTrainingSelection.SelectedItem.ToString();
                var wagesControl = _comboBoxToUserControl[wagesControlName];
                var wageEventArgs =
                    new TrainingEventArgs(((ITrainingCalc)wagesControl).AddingCalc());
                AddingTrainings?.Invoke(this, wageEventArgs);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Обратите внимание: {ex.Message}",
                   "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Кнопка закрыть.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClose(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Загрузка формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalaryLoad(object sender, EventArgs e)
        {
            swimCalcUserControl.Visible = false;
            runCalcUserControl.Visible = false;
            pressCalcWageRateUserControl.Visible = false;
        }

        private void payrollMethod_Enter(object sender, EventArgs e)
        {

        }

        private void wageRateUserControl1_Load(object sender, EventArgs e)
        {

        }

        private void accrualParameters_Enter(object sender, EventArgs e)
        {

        }
    }
}
