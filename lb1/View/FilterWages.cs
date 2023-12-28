using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace View
{
    /// <summary>
    /// Класс, описывающий форму для фильтрации
    /// </summary>
    public partial class FilterWages : Form
    {
        /// <summary>
        /// Лист зарплат
        /// </summary>
        private readonly BindingList<Model.TrainingCalc> _listWages;

        /// <summary>
        /// Лист отфильтрованных зарплат
        /// </summary>
        private BindingList<Model.TrainingCalc> _listTrainingFilter;

        /// <summary>
        /// Обработчик события
        /// </summary>
        public EventHandler<EventArgs> WagesFiltered;

        /// <summary>
        /// Зарплата
        /// </summary>
        private double _training;

        /// <summary>
        /// Форма для фильтрации
        /// </summary>
        /// <param name="wages">заработная плата</param>
        public FilterWages(BindingList<Model.TrainingCalc> wages)
        {
            InitializeComponent();
            BackColor = Color.SeaGreen;
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            _listWages = wages;
            textBoxWage.Enabled = false;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        /// <summary>
        /// Ввод необходимой суммы зарплаты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxWage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(textBoxWage.Text != "")
                {
                    _training = Checks.CheckNumber(textBoxWage.Text);
                }
            }
            catch
            {
                MessageBox.Show("Введено некорректное число", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Контроль ввода значений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       private void TextBoxWage_KeyPress(object sender, KeyPressEventArgs e)
        {
            Checks.CheckInput(e);
        }

        /// <summary>
        /// Активация поля ввода зарплаты для поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxInput_CheckedChanged(object sender, EventArgs e)
        {
            
            if(checkBoxInput.Checked)
            {
                textBoxWage.Enabled = true;
            }
        }

        /// <summary>
        /// Кнопка поиска по созданному фильтру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            _listTrainingFilter = new BindingList<Model.TrainingCalc>();

            int count = 0;
            if (!checkBoxHourlyWageRate.Checked
                && !checkBoxWageRate.Checked
                && !checkBoxSalary.Checked
                && !checkBoxInput.Checked)
            {
                MessageBox.Show("Критерии для поиска не введены!",
                    "Внимание", MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                return;
            }

            foreach (Model.TrainingCalc figure in _listWages)
            {

                switch (figure)
                {
                    case PressCalc when checkBoxHourlyWageRate.Checked:
                    case RunCalc when checkBoxWageRate.Checked:
                    case SwimCalc when checkBoxSalary.Checked:
                        {
                            if (checkBoxInput.Checked)
                            {
                                if (figure.CalculateCalories == _training)
                                {
                                    count++;
                                    _listTrainingFilter.Add(figure);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                count++;
                                _listTrainingFilter.Add(figure);
                                break;
                            }
                        }
                }

                if (!checkBoxHourlyWageRate.Checked
                    && !checkBoxWageRate.Checked
                    && !checkBoxSalary.Checked)
                {
                    if (checkBoxInput.Checked && figure.CalculateCalories == _training)
                    {
                        count++;
                        _listTrainingFilter.Add(figure);
                    }
                }
            }

            WageListEventArgs eventArgs;

            if (count > 0)
            {
                eventArgs = new WageListEventArgs(_listTrainingFilter);
            }
            else
            {
                MessageBox.Show("Зарплат с такими параметрами не " +
                    "существует", "Введите другие параметры", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                eventArgs = new WageListEventArgs(_listTrainingFilter);
                return;
            }

            WagesFiltered?.Invoke(this, eventArgs);
            Close();
        }
    }
}
