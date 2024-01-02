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

/// <summary>
/// Пространство имён View.
/// </summary>
namespace View
{
    /// <summary>
    /// Создание своей тренировки.
    /// </summary>
    public partial class AddTrainingForm : Form
    {
        /// <summary>
        /// Делегат для добавления тренировки.
        /// </summary>
        public EventHandler<EventArgs> AddingTrainings;

        /// <summary>
        /// Переменная для словаря UserControl.
        /// </summary>
        private readonly Dictionary<string, UserControl>
            _comboBoxToUserControl;

        /// <summary>
        /// Метка UserControl.
        /// </summary>
        private UserControl _userControl;

        /// <summary>
        /// Метод создания тренировки.
        /// </summary>
        public AddTrainingForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            Size = new Size(296, 292);
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
                {typeTraining[0], pressCalcUserControl },
                {typeTraining[1], swimCalcUserControl },
                {typeTraining[2], runCalcUserControl },
            };
        }

        /// <summary>
        /// Выбор тренировки в комбобоксе.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxTrainingSelection(object sender, EventArgs e)
        {
            string trainingType = comboTrainingSelection.SelectedItem.ToString();
            foreach (var (trainingValue, userControlTmp) in _comboBoxToUserControl)
            {
                userControlTmp.Visible = false;
                if (trainingType == trainingValue)
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
                var trainingsControlName = 
                    comboTrainingSelection.SelectedItem.ToString();
                var trainingsControl = _comboBoxToUserControl[trainingsControlName];
                var trainingEventArgs =
                    new TrainingEventArgs(((ITrainingCalc)trainingsControl).AddingCalc());
                AddingTrainings?.Invoke(this, trainingEventArgs);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Обратите внимание: {ex.Message}",
                   "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Кнопка "Отмена".
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
        private void TrainingLoad(object sender, EventArgs e)
        {
            swimCalcUserControl.Visible = false;
            runCalcUserControl.Visible = false;
            pressCalcUserControl.Visible = false;

            // Установка выбора по умолчанию на "Бег"
            comboTrainingSelection.SelectedIndex = 2;
            ComboBoxTrainingSelection(this, EventArgs.Empty);
        }
    }
}
