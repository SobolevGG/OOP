using HydroGeneratorOptimization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private BindingSource bindingSource;
        private DataTable dataTable;

        public MainForm()
        {
            InitializeComponent();

            // ������������� DataTable � BindingSource
            dataTable = new DataTable();
            dataTable.Columns.Add("GeneratorName", typeof(string));
            dataTable.Columns.Add("WaterFlow", typeof(double));

            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            // �������� ������ � DataGridView
            dataGridView.DataSource = bindingSource;

            // ���������� ������ "��������� �������"
            Button loadFlowsButton = new Button
            {
                Text = "��������� �������",
                Location = new System.Drawing.Point(10, 10)
            };

            loadFlowsButton.Click += LoadFlowsButton_Click;
            Controls.Add(loadFlowsButton);
        }

        private void LoadFlowsButton_Click(object sender, EventArgs e)
        {
            LoadDataToGrid();
        }

        private void LoadDataToGrid()
        {
            // ����������� OpenFileDialog ��� ������ ����� � ���������
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "XML Files|*.xml",
                Title = "�������� ���� � ���������"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;

                // �������� ������ �� ���������� �����
                GeneratorFlows generatorFlows = LoadGeneratorFlowsFromFile(selectedFilePath);
                if (generatorFlows != null)
                {
                    // ������� ������� ����� ����������� ����� ������
                    dataTable.Rows.Clear();

                    // �������� ������ � �������������� � DataTable
                    foreach (var generatorFlow in generatorFlows.Flows)
                    {
                        dataTable.Rows.Add(generatorFlow.Name, generatorFlow.WaterFlow);
                    }

                    // ���������� �������� ������
                    bindingSource.ResetBindings(false);
                }
                else
                {
                    MessageBox.Show("������ �������� ������ � ��������������");
                }
            }

            // ���������� �������� ������
            bindingSource.ResetBindings(false);

            // ��������� ������ ����� ��� ������� ����������� ������
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // �������������� ��������� �������� ��������
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // ���������� ��������������� ��������� �������� ��������
            dataGridView.AllowUserToResizeColumns = false;

            // ������������ ���������� �������� �� ������
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private GeneratorFlows LoadGeneratorFlowsFromFile(string filePath)
        {
            try
            {
                XmlFileManager<GeneratorFlows> generatorFlowsFileManager = new XmlFileManager<GeneratorFlows>();
                return generatorFlowsFileManager.Load(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading generator flows: {ex.Message}");
                return null;
            }
        }

        // ���������� ��� �������� �����
        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        // ������� �� ��������� ������� ����
        private void saveWaterFlow_Click(object sender, EventArgs e)
        {
        }

        // ������� �� ������� ������� ����
        private void openWaterFlow_Click(object sender, EventArgs e)
        {
            // �������� ������ ��� �������� �����
            LoadDataToGrid();
        }
    }
}
