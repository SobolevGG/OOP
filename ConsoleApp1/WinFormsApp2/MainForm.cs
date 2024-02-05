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
using static System.Runtime.InteropServices.JavaScript.JSType;
using ConsoleAppNew;

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

            double waterHead = 93;
            maxLoadRoughZone = new MaxLoadRoughZone(waterHead);
            // ������� restrictionsHUGridView
            restrictionsHUGridView.Rows.Clear();
            // ��������� ������� �������
            FillDataRestrictions();


            // �������� �������� ����� ��� �������� �����
            TestFillData();
            parametersHUGridView.CellValidating += DataGridView_CellValidating;
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
                roughZoneFB = Math.Round(roughZoneFB, 3);
                roughZoneSB = Math.Round(roughZoneSB, 3);
                maxPower = Math.Round(maxPower, 3);

                // ��������� �������� � restrictionsHUGridView
                restrictionsHUGridView.Rows.Add($"{i}", roughZoneFB, roughZoneSB, maxPower);
            }
        }

        private void saveMaxLoadPoughZone_Click(object sender, EventArgs e)
        {
            // ������� ������ ��� �������� ������
            List<MaxLoadRoughZone> dataItems = new List<MaxLoadRoughZone>();

            double waterHead;

            if ((string.IsNullOrWhiteSpace(LRTextBox.Text)) &&
                (string.IsNullOrWhiteSpace(URTextBox.Text)) &&
                (restrictionsHUGridView.Rows.Count > 0))
            {
                waterHead = 93;

                // �������� �� ������ ������ � DataGridView
                foreach (DataGridViewRow row in restrictionsHUGridView.Rows)
                {
                    // ������� ������ MaxLoadRoughZone �� ������ ������ � ������
                    MaxLoadRoughZone item = new MaxLoadRoughZone(waterHead)
                    {
                        HU = row.Cells[0].Value?.ToString(),
                        MaxPower = Convert.ToDouble(row.Cells[1].Value),
                        RoughZoneFB = Convert.ToDouble(row.Cells[2].Value),
                        RoughZoneSB = Convert.ToDouble(row.Cells[3].Value)
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
                    XmlSerializer serializer = new XmlSerializer(typeof(List<MaxLoadRoughZone>));

                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        serializer.Serialize(fs, dataItems);
                    }
                }
            }
            else if (double.TryParse(URTextBox.Text, out double upperReservoirLevel) &&
                double.TryParse(LRTextBox.Text, out double lowerReservoirLevel))
            {
                // ��������� �����
                waterHead = upperReservoirLevel - lowerReservoirLevel;

                // �������� �� ������ ������ � DataGridView
                foreach (DataGridViewRow row in restrictionsHUGridView.Rows)
                {
                    // ������� ������ MaxLoadRoughZone �� ������ ������ � ������
                    MaxLoadRoughZone item = new MaxLoadRoughZone(waterHead)
                    {
                        HU = row.Cells[0].Value?.ToString(),
                        MaxPower = Convert.ToDouble(row.Cells[1].Value),
                        RoughZoneFB = Convert.ToDouble(row.Cells[2].Value),
                        RoughZoneSB = Convert.ToDouble(row.Cells[3].Value)
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
                    XmlSerializer serializer = new XmlSerializer(typeof(List<MaxLoadRoughZone>));

                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        serializer.Serialize(fs, dataItems);
                    }
                }
            }
            else
            {
                MessageBox.Show("���������� ������������� ���� �� �������� ������� ������ � �����.",
                                    "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // ����� ��� �������� ������
        private void TestFillData()
        {
            // ���������� ����� ReadLoadForTimeStamp ��� �������� ������
            DateTime targetTimeStamp = DateTime.Parse("2024-01-10T01:00:00Z");
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "generatorsLoad.xml");

            // ��������� ������ ��� targetTimeStamp � ��������� DataGridView ��� ����������
            Dictionary<int, double> loadDictionary = GeneratorsLoader.ReadLoadForTimeStamp(filePath, targetTimeStamp, parametersHUGridView);
        }

        public class GeneratorsLoader
        {
            public static Dictionary<int, double> ReadLoadForTimeStamp(string filePath, DateTime targetTimeStamp, DataGridView parametersHUGridView)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Generator>));

                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    List<Generator> loadedData = (List<Generator>)serializer.Deserialize(fs);

                    Dictionary<int, double> loadDictionary = new Dictionary<int, double>();
                    int hydroUnitNumberCounter = 1;

                    foreach (Generator item in loadedData)
                    {
                        GeneratorsLoad targetLoadItem = item.GeneratorsLoadList
                            .FirstOrDefault(loadItem => loadItem.TimeStamp == targetTimeStamp);

                        if (targetLoadItem != null)
                        {
                            double loadValue = targetLoadItem.Load;
                            loadDictionary.Add(hydroUnitNumberCounter, loadValue);

                            // ��������� ���� ������
                            int zone = loadValue >= 320 ? 3 : (loadValue <= 150 ? 1 : 2);


                            // ������� ����� ������ � DataGridView
                            ParametersHU parametersHU = new ParametersHU
                            {
                                HU = hydroUnitNumberCounter.ToString(),
                                Load = loadValue,
                                Zone = zone,
                                Status = loadValue > 0 ? "� ������" : "�������"
                            };

                            parametersHUGridView.Rows.Add(
                                parametersHU.HU,
                                parametersHU.Load,
                                parametersHU.Zone,
                                parametersHU.Status
                            );
                        }

                        hydroUnitNumberCounter++;
                    }

                    return loadDictionary;
                }
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


        private void SaveParametersHU_Click(object sender, EventArgs e)
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
                XmlSerializer serializer = new XmlSerializer(typeof(List<ParametersHU>));

                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    serializer.Serialize(fs, dataItems);
                }
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.Title = "Open XML File";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<ParametersHU>));

                    using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                    {
                        List<ParametersHU> loadedData = (List<ParametersHU>)serializer.Deserialize(fs);

                        // ������� ������������ ������ � DataGridView
                        parametersHUGridView.Rows.Clear();

                        // ��������� DataGridView ������������ �������
                        foreach (ParametersHU item in loadedData)
                        {
                            parametersHUGridView.Rows.Add(item.HU, item.Load, item.Zone, item.Status);
                        }
                    }

                    MessageBox.Show("������ ������� ��������� �� �����.", "���������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������ ��� ������ �����: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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


        private void SaveToXmlFromDB(string queryType)
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
            SaveToXmlFromDB("Characteristics");
        }

        /// <summary>
        /// ���������� ��������� ������������.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProtocolToolStripMenu_Click(object sender, EventArgs e)
        {
            SaveToXmlFromDB("Protocol");
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

        private void openMaxLoadPoughZone_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.Title = "Open XML File";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // ������ ����, ��������� ��������� ������
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<MaxLoadRoughZone>));

                    using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                    {
                        List<MaxLoadRoughZone> loadedData = (List<MaxLoadRoughZone>)serializer.Deserialize(fs);

                        // ������� ������������ ������ � DataGridView
                        restrictionsHUGridView.Rows.Clear();

                        // ��������� DataGridView ������� �� �����
                        foreach (MaxLoadRoughZone item in loadedData)
                        {
                            restrictionsHUGridView.Rows.Add(
                                item.HU,
                                Math.Round(item.MaxPower, 3),
                                Math.Round(item.RoughZoneFB, 3),
                                Math.Round(item.RoughZoneSB, 3)
                            );
                        }

                        MessageBox.Show("������ ������� ��������� �� �����.", "���������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������ ��� ������ �����: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void importBMPButton_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Generator>));
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.Title = "Open XML File";

            try
            {
                // ���������� ���������� ���� ��� ������ �����
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                    {
                        List<Generator> loadedData = (List<Generator>)serializer.Deserialize(fs);

                        // ������ ������������ ��� �������� TimeStamp
                        DateTime targetTimeStamp = DateTime.Parse("2024-01-10T01:00:00Z");

                        // ����� �������������, ��� �������� ����� ��������/�������� �������� Load
                        int targetHydroUnitNumber = 5; // ���������� ��������������� �����

                        // ������� ��������������� ��������� � ��� Load
                        foreach (Generator item in loadedData)
                        {
                            GeneratorsLoad targetLoadItem = item.GeneratorsLoadList
                                .FirstOrDefault(loadItem => loadItem.TimeStamp == targetTimeStamp);

                            if (targetLoadItem != null)
                            {
                                // ������� ������ ������ � �������� ������� ������������� � DataGridView
                                int rowIndex = -1;
                                foreach (DataGridViewRow row in parametersHUGridView.Rows)
                                {
                                    int rowHydroUnitNumber;
                                    if (int.TryParse(row.Cells[0].Value?.ToString(), out rowHydroUnitNumber) && rowHydroUnitNumber == targetHydroUnitNumber)
                                    {
                                        rowIndex = row.Index;
                                        break;
                                    }
                                }

                                // ���� ������ � ����� ������� ������������� �� �������, ��������� �����
                                if (rowIndex == -1)
                                {
                                    rowIndex = parametersHUGridView.Rows.Add();
                                    // ������������� ����� ������������� � ������ �������
                                    parametersHUGridView.Rows[rowIndex].Cells[0].Value = targetHydroUnitNumber;
                                }

                                // �������� �������� �� ������ �������
                                parametersHUGridView.Rows[rowIndex].Cells[1].Value = targetLoadItem.Load;
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                // ��������� ����������, ���� ��� ��������� ��� ������ �����
                MessageBox.Show($"��������� ������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}