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

/// <summary>
/// Пространство имён View.
/// </summary>
namespace View
{
    /// <summary>
    /// Класс, описывающий форму для фильтрации.
    /// </summary>
    public partial class FilterTrainingForm : Form
    {
        /// <summary>
        /// Лист тренировок.
        /// </summary>
        private readonly BindingList<Model.TrainingCalc> _listTrainings;

        /// <summary>
        /// Лист отфильтрованных тренировок.
        /// </summary>
        private BindingList<Model.TrainingCalc> _listTrainingFilter;

        /// <summary>
        /// Обработчик события.
        /// </summary>
        public EventHandler<EventArgs> TrainingsFiltered;

        /// <summary>
        /// Поле для ввода величины калорий для поиска.
        /// </summary>
        private double _training;

        /// <summary>
        /// Форма для фильтрации.
        /// </summary>
        /// <param name="trainings">Тренировки.</param>
        public FilterTrainingForm(BindingList<Model.TrainingCalc> trainings)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            _listTrainings = trainings;
            textBoxTraining.Enabled = false;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        /// <summary>
        /// Ручной ввод.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxTraining_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(textBoxTraining.Text != "")
                {
                    _training = Checks.CheckDouble(textBoxTraining.Text);
                }
            }
            catch
            {
                MessageBox.Show("Введено некорректное число!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Контроль ввода значений.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       private void TextBoxTraining_KeyPress(object sender, KeyPressEventArgs e)
        {
            Checks.CheckInput(e);
        }

        /// <summary>
        /// Активация поля ввода калорий.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxInput_CheckedChanged(object sender, EventArgs e)
        {
            
            if(checkBoxInput.Checked)
            {
                textBoxTraining.Enabled = true;
            }
        }

        /// <summary>
        /// Кнопка поиска по фильтру.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            _listTrainingFilter = new BindingList<Model.TrainingCalc>();

            int count = 0;
            if (!checkBoxPressCalc.Checked
                && !checkBoxRunCalc.Checked
                && !checkBoxSwimCalc.Checked
                && !checkBoxInput.Checked)
            {
                MessageBox.Show("Параметры фильтрации не указаны!",
                    "Внимание!", MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                return;
            }

            foreach (Model.TrainingCalc training in _listTrainings)
            {

                switch (training)
                {
                    case PressCalc when checkBoxPressCalc.Checked:
                    case RunCalc when checkBoxRunCalc.Checked:
                    case SwimCalc when checkBoxSwimCalc.Checked:
                        {
                            if (checkBoxInput.Checked)
                            {
                                if (training.RoundCalories == _training)
                                {
                                    count++;
                                    _listTrainingFilter.Add(training);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                count++;
                                _listTrainingFilter.Add(training);
                                break;
                            }
                        }
                }

                if (!checkBoxPressCalc.Checked
                    && !checkBoxRunCalc.Checked
                    && !checkBoxSwimCalc.Checked)
                {
                    if (checkBoxInput.Checked 
                        && training.RoundCalories == _training)
                    {
                        count++;
                        _listTrainingFilter.Add(training);
                    }
                }
            }

            TrainingListEventArgs eventArgs;

            if (count > 0)
            {
                eventArgs = 
                    new TrainingListEventArgs(_listTrainingFilter);
            }
            else
            {
                MessageBox.Show("Тренировки с указанными " +
                    "параметрами фильтрации отсутствуют!",
                    "Тренировки не найдены!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                eventArgs = 
                    new TrainingListEventArgs(_listTrainingFilter);
                return;
            }

            TrainingsFiltered?.Invoke(this, eventArgs);
            Close();
        }
    }
}