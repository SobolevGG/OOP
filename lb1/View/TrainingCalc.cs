using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Xml.Serialization;
using Model;
namespace View
{
    /// <summary>
    /// ����� ��� �������� ������� ����� ������������ 
    /// </summary>
    public partial class TrainingCalc : Form
    {
        /// <summary>
        /// ������������� �����
        /// </summary>
        public TrainingCalc()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            Size = new Size(615, 477);
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        /// <summary>
        /// ������ �������
        /// </summary>
        private BindingList<Model.TrainingCalc> _trainingList = new();

        /// <summary>
        /// ���� ��������������� �����
        /// </summary>
        private BindingList<Model.TrainingCalc> _listTrainingsFilter = new();

        /// <summary>
        /// ��� ������ 
        /// </summary>
        private readonly XmlSerializer _serializer =
            new XmlSerializer(typeof(BindingList<Model.TrainingCalc>));

        /// <summary>
        /// �������� ����� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            _trainingList = new BindingList<Model.TrainingCalc>();
            CreateTable(_trainingList, dataGridViewSpace);
        }

        /// <summary>
        /// ���������� ����� ������.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var addTrainingForm = new AddTrainingForm();

            addTrainingForm.AddingTrainings += (sender, trainingEventArgs) =>
            {
                _trainingList.Add(((TrainingEventArgs)trainingEventArgs).Value);
            };
            addTrainingForm.ShowDialog();
        }

        /// <summary>
        /// �������� ������� DataGrid.
        /// </summary>
        /// <param name="trainings"></param>
        /// <param name="dataGridView"></param>
        public static void CreateTable(BindingList<Model.TrainingCalc> trainings,
              DataGridView dataGridView)
        {
            dataGridView.RowHeadersVisible = false;
            var source = new BindingSource(trainings, null);
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
            dataGridView.Columns.Remove("CalculateCalories");
            dataGridView.Columns.Remove("Weight");
        }

        /// <summary>
        /// �������� �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewSpace.SelectedCells.Count != 0)
            {
                foreach (DataGridViewRow row in dataGridViewSpace.SelectedRows)
                {
                    _trainingList.Remove(row.DataBoundItem as Model.TrainingCalc);

                    _listTrainingsFilter.Remove(row.DataBoundItem as Model.TrainingCalc);
                }
            }
        }

        /// <summary>
        /// ������� ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonReset_Click(object sender, EventArgs e)
        {
            _trainingList.Clear();
            _listTrainingsFilter.Clear();
        }

        /// <summary>
        /// ������� ��������� ��������� ����������.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRandom_Click(object sender, EventArgs e)
        {
            // ��������� ��������� ����������
            _trainingList.Add(Model.RandomTrainingCalc.GetRandomTrainingCalc());
        }

        /// <summary>
        /// ������ ��� �������� �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            var newFilterTrainings = new FilterTraining(_trainingList);
            newFilterTrainings.Show();
            newFilterTrainings.TrainingsFiltered += (sender, trainingEventArgs) =>
            {
                dataGridViewSpace.DataSource =
                ((TrainingListEventArgs)trainingEventArgs).TrainingListValue;
                _listTrainingsFilter = ((TrainingListEventArgs)trainingEventArgs).TrainingListValue;
                dataGridViewSpace.Columns.Remove("CalculateCalories");
                dataGridViewSpace.Columns.Remove("Weight");
            };
        }

        /// <summary>
        /// ����� �������.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCleanFilter_Click(object sender, EventArgs e)
        {
            CreateTable(_trainingList, dataGridViewSpace);
        }

        /// <summary>
        /// ���������� ���������� � ����.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_trainingList.Count == 0)
            {
                MessageBox.Show("����������� ������ ��� ����������.",
                    "������ �� ���������",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "����� (*.train)|*.train|��� ����� (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var path = saveFileDialog.FileName.ToString();
                using (FileStream file = File.Create(path))
                {
                    _serializer.Serialize(file, _trainingList);
                }
                MessageBox.Show("���� ������� �������.",
                    "���������� ���������",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// �������� ����� ����������.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "����� (*.train)|*.train|��� ����� (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            var path = openFileDialog.FileName.ToString();
            try
            {
                using (var file = new StreamReader(path))
                {
                    _trainingList = (BindingList<Model.TrainingCalc>)
                        _serializer.Deserialize(file);
                }

                dataGridViewSpace.DataSource = _trainingList;
                dataGridViewSpace.CurrentCell = null;
                MessageBox.Show("���� c ������������ ������� ��������.",
                    "�������� ���������!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("�� ������� ��������� ����.\n" +
                    "���� �������� ��� �� ������������� �������.",
                    "������",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox�alculator_Enter(object sender, EventArgs e)
        {

        }
    }
}