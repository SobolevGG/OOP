using System.ComponentModel;
using System;
using System.Data;
using System.Windows.Forms;
using System.Xml.Serialization;
using Model;

/// <summary>
/// Пространство имён View.
/// </summary>
namespace View
{
    /// <summary>
    /// Класс для отображения стартового окна.
    /// </summary>
    public partial class Calculator : Form
    {
        /// <summary>
        /// Инициализация формы Calculator.
        /// </summary>
        public Calculator()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(830, 410);
            BackColor = Color.White;
            MaximizeBox = false;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        /// <summary>
        /// Список зарплат
        /// </summary>
        private BindingList<TrainingCalc> _trainingList = new();

        /// <summary>
        /// Лист отфильтрованных фигур
        /// </summary>
        private BindingList<TrainingCalc> _listWagesFilter = new();


        /// <summary>
        /// Для файлов 
        /// </summary>
        private readonly XmlSerializer _serializer =
            new XmlSerializer(typeof(BindingList<TrainingCalc>));

        /// <summary>
        /// Загрузка формы 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            _trainingList = new BindingList<TrainingCalc>();
            CreateTable(_trainingList, dataGridViewSpace);
        }

        /// <summary>
        /// Добавление новой фигуры.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var addTrainingForm = new CreateTrainingForm();
        
            addTrainingForm.AddingTraining += (sender, trainingEventArgs) =>
            {
                _trainingList.Add(((TrainingEventArgs)trainingEventArgs).TrainingValue);
            };
            addTrainingForm.ShowDialog();
        }


        /// <summary>
        /// Создание таблицы DataGrid.
        /// </summary>
        /// <param name="wages"></param>
        /// <param name="dataGridView"></param>
        public static void CreateTable(BindingList<TrainingCalc> wages,
              DataGridView dataGridView)
        {
            dataGridView.RowHeadersVisible = false;
            var source = new BindingSource(wages, null);
            dataGridView.DataSource = source;

            dataGridView.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dataGridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.DefaultCellStyle.WrapMode =
                DataGridViewTriState.True;
            dataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// Удаление позиций
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewSpace.SelectedCells.Count != 0)
            {
                foreach (DataGridViewRow row in dataGridViewSpace.SelectedRows)
                {
                    _trainingList.Remove(row.DataBoundItem as TrainingCalc);

                    _listWagesFilter.Remove(row.DataBoundItem as TrainingCalc);
                }
            }
        }

        /// <summary>
        /// Очистка списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonReset_Click(object sender, EventArgs e)
        {
            _trainingList.Clear();
            _listWagesFilter.Clear();
        }

        /// <summary>
        /// Функция случайной зарплаты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // private void ButtonRandom_Click(object sender, EventArgs e)
        // {
        //     _trainingList.Add(RandomWages.GetRandomWages());
        // }


        /// <summary>
        /// Кнопка для открытия фильтра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // private void ButtonSearch_Click(object sender, EventArgs e)
        // {
        //     var newFilterWages = new FilterWages(_trainingList);
        //     newFilterWages.Show();
        //     newFilterWages.WagesFiltered += (sender, trainingEventArgs) =>
        //     {
        //         dataGridViewSpace.DataSource =
        //         ((WageListEventArgs)trainingEventArgs).WageListValue;
        //         _listWagesFilter = ((WageListEventArgs)trainingEventArgs).WageListValue;
        // 
        //     };
        // }

        /// <summary>
        /// Сброс найтроек фильтра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCleanFilter_Click(object sender, EventArgs e)
        {
            CreateTable(_trainingList, dataGridViewSpace);
        }


        /// <summary>
        /// Сохранение списка в файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_trainingList.Count == 0)
            {
                MessageBox.Show("Отсутствуют данные для сохранения.",
                    "Данные не сохранены",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Файлы (*.zp)|*.zp|Все файлы (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var path = saveFileDialog.FileName.ToString();
                using (FileStream file = File.Create(path))
                {
                    _serializer.Serialize(file, _trainingList);
                }
                MessageBox.Show("Файл успешно сохранён.",
                    "Сохранение завершено",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        /// <summary>
        /// Открытие файла со списком
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Файлы (*.zp)|*.zp|Все файлы (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            var path = openFileDialog.FileName.ToString();
            try
            {
                using (var file = new StreamReader(path))
                {
                    _trainingList = (BindingList<TrainingCalc>)
                        _serializer.Deserialize(file);
                }

                dataGridViewSpace.DataSource = _trainingList;
                dataGridViewSpace.CurrentCell = null;
                MessageBox.Show("Файл успешно загружен.",
                    "Загрузка завершена",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось загрузить файл.\n" +
                    "Файл повреждён или не соответствует формату.",
                    "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
