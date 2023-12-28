﻿using System;
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
    public partial class CreateTrainingForm : Form
    {
        public CreateTrainingForm()
        {
            InitializeComponent();
            BackColor = Color.SeaGreen;
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            Size = new Size(400, 400);
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            buttonOk.Enabled = false;
            comboSalarySelection.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            string[] typeWages = { "Почасовая оплата", "Оплата по окладу",
                "Оплата по ставке" };

            comboSalarySelection.Items.AddRange(new string[] {
            typeWages[0], typeWages[1], typeWages[2]});

            // _comboBoxToUserControl = new Dictionary<string, UserControl>()
            // {
            //     {typeWages[0], hourlyWageRateUserControl1 },
            //     {typeWages[1], salaryUserControl1 },
            //     {typeWages[2], wageRateUserControl1 },
            // };
        }

        /// <summary>
        /// Делегат для добавления заработной платы.
        /// </summary>
        public EventHandler<EventArgs> AddingTraining;

        /// <summary>
        /// Переменная для словаря UserControl
        /// </summary>
        private readonly Dictionary<string, UserControl>
            _comboBoxToUserControl;

        /// <summary>
        /// Метка UserControl
        /// </summary>
        private UserControl _userControl;

        /// <summary>
        /// Действие при выборе слова из выпадающего списка
        /// Задает выбранный элемент в поле со списко ComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxSalarySelection(object sender, EventArgs e)
        {
            string trainingType = comboSalarySelection.SelectedItem.ToString();
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
        /// Кнопка ОК
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // vate void ButtonOk(object sender, EventArgs e)
        // 
        //  try
        //  {
        //      var trainingControlName =
        //          comboSalarySelection.SelectedItem.ToString();
        //      var trainingControl = _comboBoxToUserControl[trainingControlName];
        //      var trainingEventArgs =
        //          new TrainingEventArgs(((CreateTraining)trainingControl).AddingTraining());
        //      AddingTraining?.Invoke(this, trainingEventArgs);
        //      DialogResult = DialogResult.OK;
        //  }
        //  catch (ArgumentException ex)
        //  {
        //      MessageBox.Show(ex.Message);
        //  }
        //  catch
        //  {
        //      MessageBox.Show("Введено некорректное значение!\n" +
        //         "Введите одно положительное целое или десятичное число" +
        //         " в каждое текстовое поле.",
        //         "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //  }
        // 

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
        /// Загрузка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // private void SalaryLoad(object sender, EventArgs e)
        // {
        //     salaryUserControl1.Visible = false;
        //     wageRateUserControl1.Visible = false;
        //     hourlyWageRateUserControl1.Visible = false;
        // }

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
