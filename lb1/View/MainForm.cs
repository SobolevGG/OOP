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
    public partial class MainForm : Form
    {
        /// <summary>
        /// ������������� �����
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            BackColor = Color.SeaGreen;
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            Size = new Size(830, 410);
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        /// <summary>
        /// ������ �������
        /// </summary>
        private BindingList<Model.TrainingCalc> _wageList = new();

        /// <summary>
        /// ���� ��������������� �����
        /// </summary>
        private BindingList<Model.TrainingCalc> _listWagesFilter = new();


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
            _wageList = new BindingList<Model.TrainingCalc>();
            CreateTable(_wageList, dataGridViewSpace);
        }

        /// <summary>
        /// ���������� ����� ������.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var addWageForm = new AddWageForm();

            addWageForm.AddingWages += (sender, wageEventArgs) =>
            {
                _wageList.Add(((WageEventArgs)wageEventArgs).WageValue);
            };
            addWageForm.ShowDialog();
        }


        /// <summary>
        /// �������� ������� DataGrid.
        /// </summary>
        /// <param name="wages"></param>
        /// <param name="dataGridView"></param>
        public static void CreateTable(BindingList<Model.TrainingCalc> wages,
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
                    _wageList.Remove(row.DataBoundItem as Model.TrainingCalc);

                    _listWagesFilter.Remove(row.DataBoundItem as Model.TrainingCalc);
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
            _wageList.Clear();
            _listWagesFilter.Clear();
        }

        /// <summary>
        /// ������� ��������� ��������� ����������.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRandom_Click(object sender, EventArgs e)
        {
            // ��������� ��������� ����������
            _wageList.Add(Model.RandomTrainingCalc.GetRandomTrainingCalc());
        }

        
        /// <summary>
        /// ������ ��� �������� �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            var newFilterWages = new FilterWages(_wageList);
            newFilterWages.Show();
            newFilterWages.WagesFiltered += (sender, wageEventArgs) =>
            {
                dataGridViewSpace.DataSource =
                ((WageListEventArgs)wageEventArgs).WageListValue;
                _listWagesFilter = ((WageListEventArgs)wageEventArgs).WageListValue;

            };
        }

        /// <summary>
        /// ����� �������� �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCleanFilter_Click(object sender, EventArgs e)
        {
            CreateTable(_wageList, dataGridViewSpace);
        }

         
        /// <summary>
        /// ���������� ������ � ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_wageList.Count == 0)
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
                    _serializer.Serialize(file, _wageList);
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
                    _wageList = (BindingList<Model.TrainingCalc>)
                        _serializer.Deserialize(file);
                }

                dataGridViewSpace.DataSource = _wageList;
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