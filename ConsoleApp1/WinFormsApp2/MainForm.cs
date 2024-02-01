using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using System.Xml.Serialization;
using static WinFormsApp2.MainForm;

namespace WinFormsApp2
{
    public partial class MainForm : Form
    {
        private bool isEditingEnabled = false;

        public MainForm()
        {
            InitializeComponent();



            // �������� �������� ����� ��� �������� �����
            FillData();

            // ��������� TextBox-� ��� powerDRtableLayoutPanel
            AddPowerDRTextBoxesToTableLayoutPanel(powerDRtableLayoutPanel);
        }

        // ����� ��� �������� ������
        [Serializable]
        public class DataItem
        {
            public string GA { get; set; }
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
            gaColumn.Width = 44; // ������������� ������ ��� ������� "��"
            gaColumn.ReadOnly = true;

            DataGridViewTextBoxColumn loadColumn = new DataGridViewTextBoxColumn();
            loadColumn.HeaderText = "��������, ���";
            loadColumn.Width = 70; // ������������� ������ ��� ������� "��������"

            DataGridViewTextBoxColumn zoneColumn = new DataGridViewTextBoxColumn();
            zoneColumn.HeaderText = "����";
            zoneColumn.Width = 40; // ������������� ������ ��� ������� "���� ������"

            // ������� ��������� ��� ������� "������"
            DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
            statusColumn.HeaderText = "������";
            statusColumn.Items.AddRange("� ������", "�������");
            statusColumn.Width = 80; // ������������� ������ ��� ������� "������"

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

        private void FillData()
        {
            // ������� �������
            CreateDataGridView();

            // ��������� ������� �������
            TestFillData();
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

            // ��������� TextBox-� � TableLayoutPanel
            AddTextBoxesToTableLayoutPanel(tableLayoutPanel);

            // ��������� TableLayoutPanel � calcGroupBox
            calcGroupBox.Controls.Add(tableLayoutPanel);
        }

        private void AddTextBoxesToTableLayoutPanel(TableLayoutPanel tableLayoutPanel)
        {
            // ������� TextBox-�
            TextBox textBox1 = new TextBox();
            textBox1.Dock = DockStyle.Fill;
            textBox1.Text = "����";
            textBox1.ReadOnly = true;
            // ������������� ��������� �������
            textBox1.Enter += TextBox_Enter;
            // ������� �����
            textBox1.BorderStyle = BorderStyle.None; 

            TextBox textBox2 = new TextBox();
            textBox2.Dock = DockStyle.Fill;

            TextBox textBox3 = new TextBox();
            textBox3.Dock = DockStyle.Fill;
            textBox3.Text = "��";
            textBox3.ReadOnly = true;
            textBox3.Enter += TextBox_Enter;
            // ������� �����
            textBox3.BorderStyle = BorderStyle.None;

            TextBox textBox4 = new TextBox();
            textBox4.Dock = DockStyle.Fill;
            

            // ��������� TextBox-� � ������ TableLayoutPanel
            tableLayoutPanel.Controls.Add(textBox1, 0, 0);
            tableLayoutPanel.Controls.Add(textBox2, 1, 0);
            tableLayoutPanel.Controls.Add(textBox3, 0, 1);
            tableLayoutPanel.Controls.Add(textBox4, 1, 1);
        }

        private void AddPowerDRTextBoxesToTableLayoutPanel(TableLayoutPanel tableLayoutPanel)
        {
            // ������� TextBox-�
            TextBox textBox1 = new TextBox();
            textBox1.Dock = DockStyle.Fill;
            textBox1.Text = "��� 220 ��";
            textBox1.ReadOnly = true;
            textBox1.Enter += TextBox_Enter;
            // ������� �����
            textBox1.BorderStyle = BorderStyle.None;

            TextBox textBox2 = new TextBox();
            textBox2.Dock = DockStyle.Fill;
            // ��������� ����� (�� ���������)
            textBox2.BorderStyle = BorderStyle.FixedSingle;

            TextBox textBox3 = new TextBox();
            textBox3.Dock = DockStyle.Fill;
            
            textBox3.Text = "��� 500 ��";
            textBox3.ReadOnly = true;
            textBox3.Enter += TextBox_Enter;
            // ������� �����
            textBox3.BorderStyle = BorderStyle.None;

            TextBox textBox4 = new TextBox();
            textBox4.Dock = DockStyle.Fill;
            // ��������� ����� (�� ���������)
            textBox4.BorderStyle = BorderStyle.FixedSingle;

            // ��������� TextBox-� � ������ TableLayoutPanel
            tableLayoutPanel.Controls.Add(textBox1, 0, 0);
            tableLayoutPanel.Controls.Add(textBox2, 1, 0);
            tableLayoutPanel.Controls.Add(textBox3, 0, 1);
            tableLayoutPanel.Controls.Add(textBox4, 1, 1);
        }



        private void TextBox_Enter(object sender, EventArgs e)
        {
            // ��� ��������� TextBox ������������� ����� �� ������ �������
            ActiveControl = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // ������� ������ ��� �������� ������
            List<DataItem> dataItems = new List<DataItem>();

            // �������� �� ������ ������ � DataGridView
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // ������� ������ DataItem �� ������ ������ � ������
                DataItem item = new DataItem
                {
                    GA = row.Cells[0].Value?.ToString(), // ������ 0 ������������� ������� �������
                    Load = Convert.ToInt32(row.Cells[1].Value), // ������ 1 ������������� ������� �������
                    Zone = Convert.ToInt32(row.Cells[2].Value), // ������ 2 ������������� �������� �������
                    Status = row.Cells[3].Value?.ToString() // ������ 3 ������������� ���������� �������
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

        // ����� ������
        private void editingMode_Click(object sender, EventArgs e)
        {

        }

        private void editingModeButton_Click(object sender, EventArgs e)
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
        private void openDoc_Click(object sender, EventArgs e)
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
    }
}