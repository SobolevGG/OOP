using Npgsql;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using System.Xml.Serialization;
using static View.MainForm;

namespace View
{
    public partial class MainForm : Form
    {
        private bool isEditingEnabled = false;

        public MainForm()
        {
            InitializeComponent();

            
            // ������� �������
            CreateDataGridView();

            // �������� �������� ����� ��� �������� �����
            TestFillData();
        }

        // ����� ��� �������� ������
        [Serializable]
        public class DataItem
        {
            public string GU { get; set; }
            public int Load { get; set; }
            public int Zone { get; set; }
            public string Status { get; set; }
        }

        // ����� ��� �������� �������
        private void CreateDataGridView()
        {
            // ������� �������
            DataGridViewTextBoxColumn gaColumn = new DataGridViewTextBoxColumn();
            gaColumn.HeaderText = "��";
            // ������������� ������ ��� ������� "��"
            gaColumn.Width = 44;
            gaColumn.ReadOnly = true;

            DataGridViewTextBoxColumn loadColumn = new DataGridViewTextBoxColumn();
            loadColumn.HeaderText = "��������, ���";
            loadColumn.Width = 70;

            DataGridViewTextBoxColumn zoneColumn = new DataGridViewTextBoxColumn();
            zoneColumn.HeaderText = "����";
            zoneColumn.Width = 40;

            // ������� ��������� ��� ������� "������"
            DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
            statusColumn.HeaderText = "������";
            statusColumn.Items.AddRange("� ������", "�������");
            statusColumn.Width = 80;

            // ������� �������� ������� �� ����� ������, ���� �� �� ����������
            loadColumn.HeaderCell.Style.WrapMode = DataGridViewTriState.True;

            // ������������� ������������ �� ������ ��� ����� � ���������� ��������
            DataGridViewCellStyle centerAlignmentStyle = new DataGridViewCellStyle();
            centerAlignmentStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gaColumn.DefaultCellStyle = centerAlignmentStyle;
            gaColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            loadColumn.DefaultCellStyle = centerAlignmentStyle;
            loadColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            zoneColumn.DefaultCellStyle = centerAlignmentStyle;
            zoneColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            statusColumn.DefaultCellStyle = centerAlignmentStyle;
            statusColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // ��������� ������� �� DataGridView
            dataGridView.Columns.Add(gaColumn);
            dataGridView.Columns.Add(loadColumn);
            dataGridView.Columns.Add(zoneColumn);
            dataGridView.Columns.Add(statusColumn);

            // ������������� DataGridView �� ������� tabPage1
            tabPage1.Controls.Add(dataGridView);

            // ������������� ������� �������
            dataGridView.Width = 237;
            dataGridView.Height = 340;

            // ������ ��������� �������
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AllowUserToResizeColumns = false;

            // ������ ���������� ����� �����
            dataGridView.AllowUserToAddRows = false;

            // ��� ���� ������� ��������� ����������
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        // ����� ��� �������� ������
        private void TestFillData()
        {
            // ���������� �������� ������ � ��������� �������
            Random random = new Random();
            for (int i = 1; i <= 12; i++)
            {
                // �������� ��������� �������� ��������
                int[] �������� = random.Next(2) == 0 ? new[] { 0, 150 } : new[] { 320, 500 };

                // ���������� ��������� ������ ������ ���������� ���������
                int ������ = random.Next(��������[0], ��������[1] + 1);

                // ��������� ���� ������
                int ���� = ������ >= 320 ? 3 : (������ <= 150 ? 1 : 2);

                // ��������� ������ � ��������� �������
                dataGridView.Rows.Add($"{i}", ������, ����, "� ������");
            }
        }


        // ����� ��� ������������ ������ � XML
        private void SerializeToXml(List<DataItem> data, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<DataItem>));

            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(fs, data);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // ������������� �������� ReadOnly ��� ���� ����� � true
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.ReadOnly = true;
                }
            }

            // ������������� ������ �������� �� ���������
            exportDBButton.Enabled = false;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            // ������� ������ ��� �������� ������
            List<DataItem> dataItems = new List<DataItem>();

            // �������� �� ������ ������ � DataGridView
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // ������� ������ DataItem �� ������ ������ � ������
                DataItem item = new DataItem
                {
                    GU = row.Cells[0].Value?.ToString(),
                    Load = Convert.ToInt32(row.Cells[1].Value),
                    Zone = Convert.ToInt32(row.Cells[2].Value),
                    Status = row.Cells[3].Value?.ToString()
                };

                // ��������� ������ � ������
                dataItems.Add(item);
            }

            // �������������� SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog.Title = "Save XML File";
            saveFileDialog.ShowDialog();

            // ���� ������������ ������ ����
            if (saveFileDialog.FileName != "")
            {
                // ��������� ������ � ��������� ����
                SerializeToXml(dataItems, saveFileDialog.FileName);
            }
        }

        private void EditingModeButton_Click(object sender, EventArgs e)
        {
            // ����������� ����� ��������������
            isEditingEnabled = !isEditingEnabled;

            // ������������� �������� ReadOnly ��� ���� �����, ����� ������� �������, � ����������� �� ������ ��������������
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex != 0) // ���������, ��� ��� �� ������ �������
                    {
                        cell.ReadOnly = !isEditingEnabled;
                    }
                }
            }

            // ������ ������ ������ saveParamsHU ��������� ��� ����������� � ����������� �� ������ ��������������
            saveParamsHU.Enabled = isEditingEnabled;

            // ������ ����� ������ � ����������� �� ������ ��������������
            if (isEditingEnabled)
            {
                editingModeButton.Text = "��������� (������� ����� ������)";
            }
            else
            {
                editingModeButton.Text = "����� ������";
            }
        }

        /// <summary>
        /// �������� ����������� ������������.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenGuide_Click(object sender, EventArgs e)
        {
            // ��������� ���� � ����� "����������� ������������.pdf" � ���������� ����������
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "����������� ������������.pdf");

            try
            {
                if (File.Exists(filePath))
                {
                    // �������� ��������� ������� ��� �������� �����
                    Process.Start(new ProcessStartInfo
                    {
                        // ��������� ��� ����� ��� �������
                        FileName = filePath,
                        // ���������� �������� ������������ ������� ��� �������� �����
                        UseShellExecute = true
                    });
                }

                else
                {
                    MessageBox.Show("���� '����������� ������������.pdf' �� ������ � ����������: ..\\bin\\Debug\\net8.0-windows.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"��������� ������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenParamsHU_Click(object sender, EventArgs e)
        {
            // ������� ������ OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // ������������� ������ ��� ������ ������ ������� XML
            openFileDialog.Filter = "XML files (*.xml)|*.xml";

            // ������������� ��������� ����������� ����
            openFileDialog.Title = "�������� ���� XML";

            // ������������� �������� ShowHelp � false, ����� ������ ����� "All Files"
            openFileDialog.ShowHelp = false;

            // ���������� ���������� ���� � ���������, ��� �� ������ ����
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // �������� ���� � ���������� �����
                string selectedFilePath = openFileDialog.FileName;

                // ��� ��� ��� ��������� ���������� �����
                // ��������, �������� ������ �� ����� ��� ����������� ���� � �����
                MessageBox.Show($"������ ���� XML: {selectedFilePath}", "����� �����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AuthorizationButton_Click(object sender, EventArgs e)
        {
            // ������� ���������� ���� ��� �����������
            Authorization authorizationForm = new Authorization();
            DialogResult result = authorizationForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                // �������������� ������ ����� �������� �����������
                exportDBButton.Enabled = true;
            }
        }

        private void CurrentCharacteristicsToolStripMenu_Click(object sender, EventArgs e)
        {
            var connector = new PostgresConnector("localhost", "HPPs", "postgres", $"{Model.PostgresQueries.PasswordDB}");

            try
            {
                NpgsqlDataReader reader = Model.PostgresQueries.SelectCharacteristics(connector);

                if (reader != null)
                {
                    DataTable dataTable = new DataTable("GeneratorCharacteristicHistory");
                    dataTable.Load(reader);

                    // �������� XML-����� � ������ � ���� ������
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "XML files (*.xml)|*.xml",
                        Title = "��������� ������ � XML"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;
                        dataTable.WriteXml(filePath);

                        MessageBox.Show("������ ������� ��������� � XML ����.", "���������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ������ ������ �� ���� ������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // �������� ����������
                connector.CloseConnection();
            }
        }

        private void ProtocolToolStripMenu_Click(object sender, EventArgs e)
        {
            var connector = new PostgresConnector("localhost", "HPPs", "postgres", $"{Model.PostgresQueries.PasswordDB}");

            try
            {
                NpgsqlDataReader reader = Model.PostgresQueries.SelectProtocol(connector);

                if (reader != null)
                {
                    DataTable dataTable = new DataTable("GeneratorCharacteristicHistory");
                    dataTable.Load(reader);

                    // �������� XML-����� � ������ � ���� ������
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "XML files (*.xml)|*.xml",
                        Title = "��������� ������ � XML"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;
                        dataTable.WriteXml(filePath);

                        MessageBox.Show("������ ������� ��������� � XML ����.", "���������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ������ ������ �� ���� ������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // �������� ����������
                connector.CloseConnection();
            }
        }

        private void ExportDBButton_Click(object sender, EventArgs e)
        {
            // �������� ����������� ������
            if (!exportDBButton.Enabled)
            {
                MessageBox.Show("����������� �� ���������. ������� ���������� ������.",
                    "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ����� ������ ������ ��� �������/���������� ������
            try
            {
                Model.PostgresQueries.InsertOrUpdateHydroGenerator(10, "�������������� 10", "Qi * (96.7 - (Math.Pow(Math.Abs(Qi - 490), 1.78) / Math.Pow(22.5, 2) + Math.Pow(Math.Abs(head - 93), 1.5) / Math.Pow(4, 2)))");
                MessageBox.Show("������ ������� ���������/���������.", "���������", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ���������� �������: {ex.Message}",
                    "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}