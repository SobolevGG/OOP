using System.ComponentModel;
using System;
using System.Data;
using System.Windows.Forms;
using System.Xml.Serialization;
using Model;

/// <summary>
/// ������������ ��� View.
/// </summary>
namespace View
{
    /// <summary>
    /// ����� ��� ����������� ���������� ����.
    /// </summary>
    public partial class Calculator : Form
    {
        /// <summary>
        /// ������������� ����� Calculator.
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
        /// ������ �������
        /// </summary>
        private BindingList<TrainingCalc> _trainingList = new();

        /// <summary>
        /// ���� ��������������� �����
        /// </summary>
        private BindingList<TrainingCalc> _listWagesFilter = new();


        /// <summary>
        /// ��� ������ 
        /// </summary>
        private readonly XmlSerializer _serializer =
            new XmlSerializer(typeof(BindingList<TrainingCalc>));

        /// <summary>
        /// �������� ����� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            _trainingList = new BindingList<TrainingCalc>();
            CreateTable(_trainingList, dataGridViewSpace);
        }

        /// <summary>
        /// ���������� ����� ������.
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
        /// �������� ������� DataGrid.
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
                    _trainingList.Remove(row.DataBoundItem as TrainingCalc);

                    _listWagesFilter.Remove(row.DataBoundItem as TrainingCalc);
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
            _listWagesFilter.Clear();
        }

        /// <summary>
        /// ������� ��������� ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // private void ButtonRandom_Click(object sender, EventArgs e)
        // {
        //     _trainingList.Add(RandomWages.GetRandomWages());
        // }


        /// <summary>
        /// ������ ��� �������� �������
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
        /// ����� �������� �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCleanFilter_Click(object sender, EventArgs e)
        {
            CreateTable(_trainingList, dataGridViewSpace);
        }


        /// <summary>
        /// ���������� ������ � ����
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
                Filter = "����� (*.zp)|*.zp|��� ����� (*.*)|*.*"
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
        /// �������� ����� �� �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "����� (*.zp)|*.zp|��� ����� (*.*)|*.*"
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
                MessageBox.Show("���� ������� ��������.",
                    "�������� ���������",
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
    }
}
