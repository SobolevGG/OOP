using Npgsql;
using System.Data;
using System.Diagnostics;
using System.Xml.Serialization;
using CredentialManagement;
using Model;
using System.Windows.Forms;
using static Npgsql.Replication.PgOutput.Messages.RelationMessage;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Extreme.Statistics;
using System.Text;

namespace View
{
    public partial class MainForm : Form
    {
        // ��������� ������ ��� ������ � ������� � ������������ �������� � �����
        private MaxLoadRoughZone maxLoadRoughZone;
        
        // ���� ��� ������������ ����������� ��������������
        private bool isEditingEnabled = false;
        
        // ����� ��� �����������
        private Authorization authorizationForm;

        // ���������� ��� ��������� �������� � DataGridView
        private DataGridViewTextBoxColumn zoneColumn;
        private DataGridViewTextBoxColumn loadColumn;
        private DataGridViewComboBoxColumn statusColumn;

        public MainForm()
        {
            InitializeComponent();

            // ������� �������
            ParametersHUGridView();
            RestrictionsHUGridView();


            // ������� ������ MaxLoadRoughZone
            // ����� ����������� ��������� �����
            maxLoadRoughZone = new MaxLoadRoughZone(93);
            // ������� restrictionsHUGridView
            restrictionsHUGridView.Rows.Clear();
            // ��������� ������� �������
            FillDataRestrictions();


            // �������� �������� ����� ��� �������� �����
            TestFillData();
        }

        // ����� ��� ��������� ����� ��� ��������
        private void MainForm_Load(object sender, EventArgs e)
        {
            // ������������� �������� ReadOnly ��� ���� ����� � true
            foreach (DataGridViewRow row in parametersHUGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.ReadOnly = true;
                }
            }

            // ������������� ������ �������� �� ���������
            exportDBButton.Enabled = false;
        }

        // ����� ��� ���������� ������ � ���������� ������� RestrictionsHUGridView
        private void UpdateRestrictionsData()
        {
            // ���������, ��� �������� � URTextBox � LRTextBox ����� ������������� � �����
            if (double.TryParse(URTextBox.Text, out double upperReservoirLevel) &&
                double.TryParse(LRTextBox.Text, out double lowerReservoirLevel))
            {
                // ��������� �����
                double waterHead = upperReservoirLevel - lowerReservoirLevel;

                // ��������� �������� � maxLoadRoughZone
                maxLoadRoughZone = new MaxLoadRoughZone(waterHead);

                // ������� restrictionsHUGridView
                restrictionsHUGridView.Rows.Clear();

                // ��������� ������� �������
                FillDataRestrictions();
            }
        }

        // �������, ������������� ��� ������� ������ calcHeadButton
        private void CalcHeadButton_Click(object sender, EventArgs e)
        {
            // �������� ������� ������ � URTextBox
            if (string.IsNullOrWhiteSpace(URTextBox.Text))
            {
                MessageBox.Show("������� �������� �������� �����.",
                                    "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // �������� ������� ������ � LRTextBox
            else if (string.IsNullOrWhiteSpace(LRTextBox.Text))
            {
                MessageBox.Show("������� �������� ������� �����.",
                                    "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // �������� ����������� �������������� ������ � URTextBox � double
                if (!double.TryParse(URTextBox.Text, out double upperReservoirLevel))
                {
                    MessageBox.Show("���������� ������������� �������� �������� ����� � �����.",
                                    "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // �������� ����������� �������������� ������ � LRTextBox � double
                else if (!double.TryParse(LRTextBox.Text, out double lowerReservoirLevel))
                {
                    MessageBox.Show("���������� ������������� �������� ������� ����� � �����.",
                                    "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // �������� �� ���������� �������� �������� �����
                else if (upperReservoirLevel < maxLoadRoughZone.MinUpperReservoirLevel ||
                         upperReservoirLevel > maxLoadRoughZone.MaxUpperReservoirLevel)
                {
                    MessageBox.Show($"�������� ������ �������� ����� ������ ���� \n� ��������� " +
                        $"�� {maxLoadRoughZone.MinUpperReservoirLevel} " +
                        $"�� {maxLoadRoughZone.MaxUpperReservoirLevel} �.",
                                    "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // �������� �� ���������� �������� ������� �����
                else if (lowerReservoirLevel < maxLoadRoughZone.MinLowerReservoirLevel ||
                         lowerReservoirLevel > maxLoadRoughZone.MaxLowerReservoirLevel)
                {
                    MessageBox.Show($"�������� ������ ������� ����� ������ ���� \n� ��������� " +
                        $"�� {maxLoadRoughZone.MinLowerReservoirLevel} " +
                        $"�� {maxLoadRoughZone.MaxLowerReservoirLevel} �.",
                                    "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // �������� �� ���������� �������� ������
                else if ((upperReservoirLevel - lowerReservoirLevel) < maxLoadRoughZone.MinWaterHead ||
                    (upperReservoirLevel - lowerReservoirLevel) > maxLoadRoughZone.MaxWaterHead)
                {
                    MessageBox.Show($"�������� ������ ������ ���� � ��������� " +
                        $"�� {maxLoadRoughZone.MinWaterHead} \n" +
                        $"�� {maxLoadRoughZone.MaxWaterHead} �. " +
                        $"�����, �������� �������� ��������� �������, " +
                        $"���������� {upperReservoirLevel - lowerReservoirLevel} �, " +
                        $"��� ����������� �������� ���������� ������ �����������.",
                                    "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // ���� ��� �������� �������� �������, ��������� ������
                    UpdateRestrictionsData();
                }
            }
        }

        // ����� ��� ���������� ������� RestrictionsHUGridView ��������� �������
        private void FillDataRestrictions()
        {
            for (int i = 1; i <= 12; i++)
            {
                // �������� �������� RoughZoneFB, RoughZoneSB, MaxPower
                double roughZoneFB = maxLoadRoughZone.RoughZoneFB;
                double roughZoneSB = maxLoadRoughZone.RoughZoneSB;
                double maxPower = maxLoadRoughZone.MaxPower;

                // ��������� �������� ��� ����������� � DataGridView
                roughZoneFB = Math.Round(roughZoneFB, 2);
                roughZoneSB = Math.Round(roughZoneSB, 2);
                maxPower = Math.Round(maxPower, 2);

                // ��������� �������� � restrictionsHUGridView
                restrictionsHUGridView.Rows.Add($"{i}", roughZoneFB, roughZoneSB, maxPower);
            }
        }
    
        // ����� ��� �������� ������� ParametersHU
        private void ParametersHUGridView()
        {
            // ������� �������
            DataGridViewTextBoxColumn HUColumn = new DataGridViewTextBoxColumn();
            HUColumn.HeaderText = "�� ";
            // ������������� ������ ��� ������� "��"
            HUColumn.Width = 44;
            HUColumn.ReadOnly = true;

            loadColumn = new DataGridViewTextBoxColumn();
            loadColumn.HeaderText = "��������, ���";
            loadColumn.Width = 70;

            zoneColumn = new DataGridViewTextBoxColumn();
            zoneColumn.HeaderText = "����";
            zoneColumn.Width = 40;

            // ������� ��������� ��� ������� "������"
            statusColumn = new DataGridViewComboBoxColumn();
            statusColumn.HeaderText = "������";
            statusColumn.Items.AddRange("� ������", "�������");
            statusColumn.Width = 80;

            // ������� �������� ������� �� ����� ������, ���� �� �� ����������
            loadColumn.HeaderCell.Style.WrapMode = DataGridViewTriState.True;

            // ������������� ������������ �� ������ ��� ����� � ���������� ��������
            DataGridViewCellStyle centerAlignmentStyle = new DataGridViewCellStyle();
            centerAlignmentStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            HUColumn.DefaultCellStyle = centerAlignmentStyle;
            HUColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            loadColumn.DefaultCellStyle = centerAlignmentStyle;
            loadColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            zoneColumn.DefaultCellStyle = centerAlignmentStyle;
            zoneColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            statusColumn.DefaultCellStyle = centerAlignmentStyle;
            statusColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // ��������� ������� �� DataGridView
            parametersHUGridView.Columns.Add(HUColumn);
            parametersHUGridView.Columns.Add(loadColumn);
            parametersHUGridView.Columns.Add(zoneColumn);
            parametersHUGridView.Columns.Add(statusColumn);

            // ������������� DataGridView �� ������� tabPage1
            parametersHUTabPage.Controls.Add(parametersHUGridView);

            // ������������� ������� �������
            parametersHUGridView.Width = 237;
            parametersHUGridView.Height = 340;

            // ������ ��������� �������
            parametersHUGridView.AllowUserToResizeRows = false;
            parametersHUGridView.AllowUserToResizeColumns = false;

            // ������ ���������� ����� �����
            parametersHUGridView.AllowUserToAddRows = false;

            // ��� ���� ������� ��������� ����������
            foreach (DataGridViewColumn column in parametersHUGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        // ����� ��� �������� ������� RestrictionsHU
        private void RestrictionsHUGridView()
        {
            // ��������� ������������ ���������� �������� �� ������
            restrictionsHUGridView.Columns["HU"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            restrictionsHUGridView.Columns["RoughZoneFB"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            restrictionsHUGridView.Columns["RoughZoneSB"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            restrictionsHUGridView.Columns["MaxLoad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // ��������� ������������ ����� �� ������
            foreach (DataGridViewColumn column in restrictionsHUGridView.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.ReadOnly = true;
            }

            // �������
            HU.Width = 44;
            RoughZoneFB.Width = 63;
            RoughZoneSB.Width = 64;
            MaxLoad.Width = 63;

            // ���������� ������ ����
            restrictionsHUGridView.ScrollBars = ScrollBars.None;


            // ������ ��������� �������
            restrictionsHUGridView.AllowUserToResizeRows = false;
            restrictionsHUGridView.AllowUserToResizeColumns = false;

            // ������ ���������� ����� �����
            restrictionsHUGridView.AllowUserToAddRows = false;

            // ���������� �������� ���������� �� ������ ������
            foreach (DataGridViewColumn column in restrictionsHUGridView.Columns)
            {
                column.HeaderCell.Style.WrapMode = DataGridViewTriState.True;
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
                parametersHUGridView.Rows.Add($"{i}", ������, ����, "� ������");
            }
        }

        // ����� ��� ������������ ������ � XML
        private void SerializeToXml(List<ParametersHU> data, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<ParametersHU>));

            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(fs, data);
            }
        }

        /// <summary>
        /// ������� �� ��������� ����� � ��������.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == zoneColumn.Index)
            {
                string input = e.FormattedValue.ToString();

                if (input != "1" && input != "3")
                {
                    MessageBox.Show("�������� � ������� '����' ������ ���� 1 ��� 3.",
                                    "������", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    e.Cancel = true; // �������� ��������� ��������
                }
            }

            if (e.ColumnIndex == loadColumn.Index)
            {
                string input = e.FormattedValue.ToString();

                if (string.IsNullOrEmpty(input))
                {
                    MessageBox.Show("���� �� ����� ���� ������.",
                                    "������", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    e.Cancel = true; // �������� ��������� ��������
                    return;
                }

                if (!double.TryParse(input, out double loadValue))
                {
                    MessageBox.Show("�������� � ������� '��������' ������ ���� ��������.",
                                    "������", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    e.Cancel = true; // �������� ��������� ��������
                    return;
                }

                if (loadValue < 0 || loadValue > 508)
                {
                    MessageBox.Show($"�������� � ������� '��������' ������ ���� � ��������� �� 0 �� {ParametersHU.MaxLoad} ���.",
                                    "������", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    e.Cancel = true; // �������� ��������� ��������
                }
            }
        }


        private void Save_Click(object sender, EventArgs e)
        {
            // ������� ������ ��� �������� ������
            List<ParametersHU> dataItems = new List<ParametersHU>();

            // �������� �� ������ ������ � DataGridView
            foreach (DataGridViewRow row in parametersHUGridView.Rows)
            {
                // ������� ������ DataItem �� ������ ������ � ������
                ParametersHU item = new ParametersHU
                {
                    HU = row.Cells[0].Value?.ToString(),
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
            // ��������� ������ ����� ���������� ������ ��������������
            parametersHUGridView.EndEdit();

            // ����������� ����� ��������������
            isEditingEnabled = !isEditingEnabled;

            // ������������� �������� ReadOnly ��� ���� �����, ����� ������� �������, � ����������� �� ������ ��������������
            foreach (DataGridViewRow row in parametersHUGridView.Rows)
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
            saveParamsHU.Enabled = !isEditingEnabled;

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
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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
            authorizationForm = new Authorization();
            System.Windows.Forms.DialogResult result = authorizationForm.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                // �������������� ������ ����� �������� �����������
                exportDBButton.Enabled = true;
            }
        }


        private void SaveDataToXml(string queryType)
        {
            using (var cred = new Credential())
            {
                // ��������� ������
                cred.Target = Authorization.TargetDB;

                // ������� ����������� ������� ������
                if (cred.Load())
                {
                    var connector = new PostgresConnector("localhost", "HPPs", cred.Username, cred.Password);

                    try
                    {
                        NpgsqlDataReader reader = queryType == "Characteristics"
                            ? Model.PostgresQueries.SelectCharacteristics(connector)
                            : Model.PostgresQueries.SelectProtocol(connector);

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

                            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                string filePath = saveFileDialog.FileName;
                                dataTable.WriteXml(filePath);

                                MessageBox.Show("������ ������� ��������� � XML ����.",
                                    "���������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            reader.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"������ ��� ������ ������ �� ���� ������: {ex.Message}",
                            "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // �������� ����������
                        connector.CloseConnection();
                    }
                }
                else
                {
                    // ������� ������ �� ������� ��� ������������ ������� ����
                    MessageBox.Show("������ �� ������� ��� ���� �������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// ���������� ���������� �������������.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentCharacteristicsToolStripMenu_Click(object sender, EventArgs e)
        {
            SaveDataToXml("Characteristics");
        }

        /// <summary>
        /// ���������� ��������� ������������.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProtocolToolStripMenu_Click(object sender, EventArgs e)
        {
            SaveDataToXml("Protocol");
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
                // ��������� ������ � ������ �� ����� �����������
                string enteredPassword = authorizationForm.GetEnteredPassword();
                string enteredLogin = authorizationForm.GetEnteredLogin();

                Model.PostgresQueries.InsertOrUpdateHydroGenerator(11, "�������������� 11",
                    "Qi * (96.7 - (Math.Pow(Math.Abs(Qi - 490), 1.78) / Math.Pow(22.5, 2) + Math.Pow(Math.Abs(head - 93), 1.5) / Math.Pow(4, 2)))",
                    enteredLogin, enteredPassword);
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