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
        // Экземпляр класса для работы с данными о максимальной мощности и зонах
        private MaxLoadRoughZone maxLoadRoughZone;

        // Флаг для отслеживания возможности редактирования
        private bool isEditingEnabled = false;

        // Форма для авторизации
        private Authorization authorizationForm;

        // Переменные для настройки столбцов в DataGridView
        private DataGridViewTextBoxColumn zoneColumn;
        private DataGridViewTextBoxColumn loadColumn;
        private DataGridViewComboBoxColumn statusColumn;

        public MainForm()
        {
            InitializeComponent();

            // Создаем таблицы
            ParametersHUGridView();
            RestrictionsHUGridView();


            // Создаем объект MaxLoadRoughZone
            // Здесь указывается начальный напор

            double waterHead = 93;
            maxLoadRoughZone = new MaxLoadRoughZone(waterHead);
            // Очищаем restrictionsHUGridView
            restrictionsHUGridView.Rows.Clear();
            // Заполняем таблицу данными
            FillDataRestrictions();


            // Вызываем тестовый метод при загрузке формы
            TestFillData();
            parametersHUGridView.CellValidating += DataGridView_CellValidating;
        }

        // Метод для настройки формы при загрузке
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Устанавливаем свойство ReadOnly для всех ячеек в true
            foreach (DataGridViewRow row in parametersHUGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.ReadOnly = true;
                }
            }

            // Недоступность кнопки экспорта по умолчанию
            exportDBButton.Enabled = false;
        }

        // Метод для обновления данных и заполнения таблицы RestrictionsHUGridView
        private void UpdateRestrictionsData()
        {
            // Проверяем, что значения в URTextBox и LRTextBox можно преобразовать в числа
            if (double.TryParse(URTextBox.Text, out double upperReservoirLevel) &&
                double.TryParse(LRTextBox.Text, out double lowerReservoirLevel))
            {
                // Вычисляем напор
                double waterHead = upperReservoirLevel - lowerReservoirLevel;

                // Обновляем значения в maxLoadRoughZone
                maxLoadRoughZone = new MaxLoadRoughZone(waterHead);

                // Очищаем restrictionsHUGridView
                restrictionsHUGridView.Rows.Clear();

                // Заполняем таблицу данными
                FillDataRestrictions();
            }
        }

        // Событие, срабатывающее при нажатии кнопки calcHeadButton
        private void CalcHeadButton_Click(object sender, EventArgs e)
        {
            // Проверка наличия данных в URTextBox
            if (string.IsNullOrWhiteSpace(URTextBox.Text))
            {
                MessageBox.Show("Введите значение верхнего бьефа.",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Проверка наличия данных в LRTextBox
            else if (string.IsNullOrWhiteSpace(LRTextBox.Text))
            {
                MessageBox.Show("Введите значение нижнего бьефа.",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Проверка возможности преобразования данных в URTextBox в double
                if (!double.TryParse(URTextBox.Text, out double upperReservoirLevel))
                {
                    MessageBox.Show("Невозможно преобразовать значение верхнего бьефа в число.",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Проверка возможности преобразования данных в LRTextBox в double
                else if (!double.TryParse(LRTextBox.Text, out double lowerReservoirLevel))
                {
                    MessageBox.Show("Невозможно преобразовать значение нижнего бьефа в число.",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Проверка на допустимые значения верхнего бьефа
                else if (upperReservoirLevel < maxLoadRoughZone.MinUpperReservoirLevel ||
                         upperReservoirLevel > maxLoadRoughZone.MaxUpperReservoirLevel)
                {
                    MessageBox.Show($"Значение уровня верхнего бьефа должно быть \nв диапазоне " +
                        $"от {maxLoadRoughZone.MinUpperReservoirLevel} " +
                        $"до {maxLoadRoughZone.MaxUpperReservoirLevel} м.",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Проверка на допустимые значения нижнего бьефа
                else if (lowerReservoirLevel < maxLoadRoughZone.MinLowerReservoirLevel ||
                         lowerReservoirLevel > maxLoadRoughZone.MaxLowerReservoirLevel)
                {
                    MessageBox.Show($"Значение уровня нижнего бьефа должно быть \nв диапазоне " +
                        $"от {maxLoadRoughZone.MinLowerReservoirLevel} " +
                        $"до {maxLoadRoughZone.MaxLowerReservoirLevel} м.",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Проверка на допустимое значение напора
                else if ((upperReservoirLevel - lowerReservoirLevel) < maxLoadRoughZone.MinWaterHead ||
                    (upperReservoirLevel - lowerReservoirLevel) > maxLoadRoughZone.MaxWaterHead)
                {
                    MessageBox.Show($"Значение напора должно быть в диапазоне " +
                        $"от {maxLoadRoughZone.MinWaterHead} \n" +
                        $"до {maxLoadRoughZone.MaxWaterHead} м. " +
                        $"Напор, согласно введённым значениям уровней, " +
                        $"составляет {upperReservoirLevel - lowerReservoirLevel} м, " +
                        $"что недопустимо согласно паспортным данным гидротурбин.",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Если все проверки пройдены успешно, обновляем данные
                    UpdateRestrictionsData();
                }
            }
        }

        // Метод для заполнения таблицы RestrictionsHUGridView тестовыми данными
        private void FillDataRestrictions()
        {
            for (int i = 1; i <= 12; i++)
            {
                // Получаем значения RoughZoneFB, RoughZoneSB, MaxPower
                double roughZoneFB = maxLoadRoughZone.RoughZoneFB;
                double roughZoneSB = maxLoadRoughZone.RoughZoneSB;
                double maxPower = maxLoadRoughZone.MaxPower;

                // Округляем значения для отображения в DataGridView
                roughZoneFB = Math.Round(roughZoneFB, 3);
                roughZoneSB = Math.Round(roughZoneSB, 3);
                maxPower = Math.Round(maxPower, 3);

                // Добавляем значения в restrictionsHUGridView
                restrictionsHUGridView.Rows.Add($"{i}", roughZoneFB, roughZoneSB, maxPower);
            }
        }

        private void saveMaxLoadPoughZone_Click(object sender, EventArgs e)
        {
            // Создаем список для хранения данных
            List<MaxLoadRoughZone> dataItems = new List<MaxLoadRoughZone>();

            double waterHead;

            if ((string.IsNullOrWhiteSpace(LRTextBox.Text)) &&
                (string.IsNullOrWhiteSpace(URTextBox.Text)) &&
                (restrictionsHUGridView.Rows.Count > 0))
            {
                waterHead = 93;

                // Проходим по каждой строке в DataGridView
                foreach (DataGridViewRow row in restrictionsHUGridView.Rows)
                {
                    // Создаем объект MaxLoadRoughZone на основе данных в строке
                    MaxLoadRoughZone item = new MaxLoadRoughZone(waterHead)
                    {
                        HU = row.Cells[0].Value?.ToString(),
                        MaxPower = Convert.ToDouble(row.Cells[1].Value),
                        RoughZoneFB = Convert.ToDouble(row.Cells[2].Value),
                        RoughZoneSB = Convert.ToDouble(row.Cells[3].Value)
                    };

                    // Добавляем объект в список
                    dataItems.Add(item);
                }

                // Инициализируем SaveFileDialog
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog.Title = "Save XML File";
                saveFileDialog.ShowDialog();

                // Если пользователь выбрал файл
                if (saveFileDialog.FileName != "")
                {
                    // Сохраняем данные в выбранный файл
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
                // Вычисляем напор
                waterHead = upperReservoirLevel - lowerReservoirLevel;

                // Проходим по каждой строке в DataGridView
                foreach (DataGridViewRow row in restrictionsHUGridView.Rows)
                {
                    // Создаем объект MaxLoadRoughZone на основе данных в строке
                    MaxLoadRoughZone item = new MaxLoadRoughZone(waterHead)
                    {
                        HU = row.Cells[0].Value?.ToString(),
                        MaxPower = Convert.ToDouble(row.Cells[1].Value),
                        RoughZoneFB = Convert.ToDouble(row.Cells[2].Value),
                        RoughZoneSB = Convert.ToDouble(row.Cells[3].Value)
                    };

                    // Добавляем объект в список
                    dataItems.Add(item);
                }

                // Инициализируем SaveFileDialog
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog.Title = "Save XML File";
                saveFileDialog.ShowDialog();

                // Если пользователь выбрал файл
                if (saveFileDialog.FileName != "")
                {
                    // Сохраняем данные в выбранный файл
                    XmlSerializer serializer = new XmlSerializer(typeof(List<MaxLoadRoughZone>));

                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        serializer.Serialize(fs, dataItems);
                    }
                }
            }
            else
            {
                MessageBox.Show("Невозможно преобразовать одно из значений уровней бьефов в число.",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод для создания таблицы RestrictionsHU
        private void RestrictionsHUGridView()
        {
            // Настройка выравнивания заголовков столбцов по центру
            restrictionsHUGridView.Columns["HU"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            restrictionsHUGridView.Columns["RoughZoneFB"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            restrictionsHUGridView.Columns["RoughZoneSB"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            restrictionsHUGridView.Columns["MaxLoad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Настройка выравнивания ячеек по центру
            foreach (DataGridViewColumn column in restrictionsHUGridView.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.ReadOnly = true;
            }

            // Размеры
            HU.Width = 44;
            RoughZoneFB.Width = 63;
            RoughZoneSB.Width = 64;
            MaxLoad.Width = 63;

            // Отключение скролл бара
            restrictionsHUGridView.ScrollBars = ScrollBars.None;


            // запрет изменения размера
            restrictionsHUGridView.AllowUserToResizeRows = false;
            restrictionsHUGridView.AllowUserToResizeColumns = false;

            // Запрет добавления новых строк
            restrictionsHUGridView.AllowUserToAddRows = false;

            // Разрешение переноса заголовков на вторую строку
            foreach (DataGridViewColumn column in restrictionsHUGridView.Columns)
            {
                column.HeaderCell.Style.WrapMode = DataGridViewTriState.True;
            }
        }

        // Метод для создания таблицы ParametersHU
        private void ParametersHUGridView()
        {
            // Создаем колонки
            DataGridViewTextBoxColumn HUColumn = new DataGridViewTextBoxColumn();
            HUColumn.HeaderText = "ГА ";
            // Устанавливаем ширину для столбца "ГА"
            HUColumn.Width = 44;
            HUColumn.ReadOnly = true;

            loadColumn = new DataGridViewTextBoxColumn();
            loadColumn.HeaderText = "Загрузка, МВт";
            loadColumn.Width = 70;

            zoneColumn = new DataGridViewTextBoxColumn();
            zoneColumn.HeaderText = "Зона";
            zoneColumn.Width = 40;

            // Создаем комбобокс для столбца "Статус"
            statusColumn = new DataGridViewComboBoxColumn();
            statusColumn.HeaderText = "Статус";
            statusColumn.Items.AddRange("В работе", "Выведен");
            statusColumn.Width = 80;

            // Перенос названия столбца на новую строку, если он не помещается
            loadColumn.HeaderCell.Style.WrapMode = DataGridViewTriState.True;

            // Устанавливаем выравнивание по центру для ячеек и заголовков столбцов
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

            // Добавляем колонки на DataGridView
            parametersHUGridView.Columns.Add(HUColumn);
            parametersHUGridView.Columns.Add(loadColumn);
            parametersHUGridView.Columns.Add(zoneColumn);
            parametersHUGridView.Columns.Add(statusColumn);

            // Устанавливаем DataGridView на вкладку tabPage1
            parametersHUTabPage.Controls.Add(parametersHUGridView);

            // Устанавливаем размеры таблицы
            parametersHUGridView.Width = 237;
            parametersHUGridView.Height = 340;

            // запрет изменения размера
            parametersHUGridView.AllowUserToResizeRows = false;
            parametersHUGridView.AllowUserToResizeColumns = false;

            // Запрет добавления новых строк
            parametersHUGridView.AllowUserToAddRows = false;

            // для всех колонок отключена сортировка
            foreach (DataGridViewColumn column in parametersHUGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        // Метод для тестовых данных
        private void TestFillData()
        {
            // Используем метод ReadLoadForTimeStamp для загрузки данных
            DateTime targetTimeStamp = DateTime.Parse("2024-01-10T01:00:00Z");
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "generatorsLoad.xml");

            // Загружаем данные для targetTimeStamp и указываем DataGridView для заполнения
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

                            // Вычисляем зону работы
                            int zone = loadValue >= 320 ? 3 : (loadValue <= 150 ? 1 : 2);


                            // Добавим также запись в DataGridView
                            ParametersHU parametersHU = new ParametersHU
                            {
                                HU = hydroUnitNumberCounter.ToString(),
                                Load = loadValue,
                                Zone = zone,
                                Status = loadValue > 0 ? "В работе" : "Выведен"
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
        /// Событие на изменение ячеек в датагрид.
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
                    MessageBox.Show("Значение в столбце 'Зона' должно быть 1 или 3.",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    e.Cancel = true; // Отменяем изменение значения
                }
            }

            if (e.ColumnIndex == loadColumn.Index)
            {
                string input = e.FormattedValue.ToString();

                if (string.IsNullOrEmpty(input))
                {
                    MessageBox.Show("Ввод не может быть пустым.",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    e.Cancel = true; // Отменяем изменение значения
                    return;
                }

                if (!double.TryParse(input, out double loadValue))
                {
                    MessageBox.Show("Значение в столбце 'Загрузка' должно быть числовым.",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    e.Cancel = true; // Отменяем изменение значения
                    return;
                }

                if (loadValue < 0 || loadValue > 508)
                {
                    MessageBox.Show($"Значение в столбце 'Загрузка' должно быть в диапазоне от 0 до {ParametersHU.MaxLoad} МВт.",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    e.Cancel = true; // Отменяем изменение значения
                }
            }
        }


        private void SaveParametersHU_Click(object sender, EventArgs e)
        {
            // Создаем список для хранения данных
            List<ParametersHU> dataItems = new List<ParametersHU>();

            // Проходим по каждой строке в DataGridView
            foreach (DataGridViewRow row in parametersHUGridView.Rows)
            {
                // Создаем объект DataItem на основе данных в строке
                ParametersHU item = new ParametersHU
                {
                    HU = row.Cells[0].Value?.ToString(),
                    Load = Convert.ToInt32(row.Cells[1].Value),
                    Zone = Convert.ToInt32(row.Cells[2].Value),
                    Status = row.Cells[3].Value?.ToString()
                };

                // Добавляем объект в список
                dataItems.Add(item);
            }

            // Инициализируем SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog.Title = "Save XML File";
            saveFileDialog.ShowDialog();

            // Если пользователь выбрал файл
            if (saveFileDialog.FileName != "")
            {
                // Сохраняем данные в выбранный файл
                XmlSerializer serializer = new XmlSerializer(typeof(List<ParametersHU>));

                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    serializer.Serialize(fs, dataItems);
                }
            }
        }

        private void EditingModeButton_Click(object sender, EventArgs e)
        {
            // Сохраняем данные перед изменением режима редактирования
            parametersHUGridView.EndEdit();

            // Переключаем режим редактирования
            isEditingEnabled = !isEditingEnabled;

            // Устанавливаем свойство ReadOnly для всех ячеек, кроме первого столбца, в зависимости от режима редактирования
            foreach (DataGridViewRow row in parametersHUGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex != 0) // Проверяем, что это не первый столбец
                    {
                        cell.ReadOnly = !isEditingEnabled;
                    }
                }
            }

            // Теперь делаем кнопку saveParamsHU доступной или недоступной в зависимости от режима редактирования
            saveParamsHU.Enabled = !isEditingEnabled;

            // Меняем текст кнопки в зависимости от режима редактирования
            if (isEditingEnabled)
            {
                editingModeButton.Text = "Сохранить (включен режим правки)";
            }
            else
            {
                editingModeButton.Text = "Режим правки";
            }
        }

        /// <summary>
        /// Открытие руководства пользователя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenGuide_Click(object sender, EventArgs e)
        {
            // Формируем путь к файлу "Руководство пользователя.pdf" в директории приложения
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Руководство пользователя.pdf");

            try
            {
                if (File.Exists(filePath))
                {
                    // Пытаемся запустить процесс для открытия файла
                    Process.Start(new ProcessStartInfo
                    {
                        // Указываем имя файла для запуска
                        FileName = filePath,
                        // Используем оболочку операционной системы для открытия файла
                        UseShellExecute = true
                    });
                }

                else
                {
                    MessageBox.Show("Файл 'Руководство пользователя.pdf' не найден в директории: ..\\bin\\Debug\\net8.0-windows.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                        // Очищаем существующие данные в DataGridView
                        parametersHUGridView.Rows.Clear();

                        // Заполняем DataGridView загруженными данными
                        foreach (ParametersHU item in loadedData)
                        {
                            parametersHUGridView.Rows.Add(item.HU, item.Load, item.Zone, item.Status);
                        }
                    }

                    MessageBox.Show("Данные успешно загружены из файла.", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при чтении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AuthorizationButton_Click(object sender, EventArgs e)
        {
            // Вывести диалоговое окно для авторизации
            authorizationForm = new Authorization();
            System.Windows.Forms.DialogResult result = authorizationForm.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                // Разблокировать кнопку после успешной авторизации
                exportDBButton.Enabled = true;
            }
        }


        private void SaveToXmlFromDB(string queryType)
        {
            using (var cred = new Credential())
            {
                // Указываем таргет
                cred.Target = Authorization.TargetDB;

                // Находим сохраненные учетные данные
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

                            // Создание XML-файла и запись в него данных
                            SaveFileDialog saveFileDialog = new SaveFileDialog
                            {
                                Filter = "XML files (*.xml)|*.xml",
                                Title = "Сохранить данные в XML"
                            };

                            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                string filePath = saveFileDialog.FileName;
                                dataTable.WriteXml(filePath);

                                MessageBox.Show("Данные успешно сохранены в XML файл.",
                                    "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            reader.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при чтении данных из базы данных: {ex.Message}",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // Закрытие соединения
                        connector.CloseConnection();
                    }
                }
                else
                {
                    // Учетные данные не найдены или пользователь отменил ввод
                    MessageBox.Show("Данные не найдены или ввод отменен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Сохранение актуальных характерситик.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentCharacteristicsToolStripMenu_Click(object sender, EventArgs e)
        {
            SaveToXmlFromDB("Characteristics");
        }

        /// <summary>
        /// Сохранение протокола актуализации.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProtocolToolStripMenu_Click(object sender, EventArgs e)
        {
            SaveToXmlFromDB("Protocol");
        }


        private void ExportDBButton_Click(object sender, EventArgs e)
        {
            // Проверка доступности кнопки
            if (!exportDBButton.Enabled)
            {
                MessageBox.Show("Авторизация не выполнена. Введите правильный пароль.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Вызов нового метода для вставки/обновления данных
            try
            {
                // Получение пароля и логина из формы авторизации
                string enteredPassword = authorizationForm.GetEnteredPassword();
                string enteredLogin = authorizationForm.GetEnteredLogin();

                Model.PostgresQueries.InsertOrUpdateHydroGenerator(11, "Гидрогенератор 11",
                    "Qi * (96.7 - (Math.Pow(Math.Abs(Qi - 490), 1.78) / Math.Pow(22.5, 2) + Math.Pow(Math.Abs(head - 93), 1.5) / Math.Pow(4, 2)))",
                    enteredLogin, enteredPassword);
                MessageBox.Show("Данные успешно вставлены/обновлены.", "Выполнено",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openMaxLoadPoughZone_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.Title = "Open XML File";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Выбран файл, попробуем прочитать данные
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<MaxLoadRoughZone>));

                    using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                    {
                        List<MaxLoadRoughZone> loadedData = (List<MaxLoadRoughZone>)serializer.Deserialize(fs);

                        // Очищаем существующие данные в DataGridView
                        restrictionsHUGridView.Rows.Clear();

                        // Заполняем DataGridView данными из файла
                        foreach (MaxLoadRoughZone item in loadedData)
                        {
                            restrictionsHUGridView.Rows.Add(
                                item.HU,
                                Math.Round(item.MaxPower, 3),
                                Math.Round(item.RoughZoneFB, 3),
                                Math.Round(item.RoughZoneSB, 3)
                            );
                        }

                        MessageBox.Show("Данные успешно загружены из файла.", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при чтении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Показываем диалоговое окно для выбора файла
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                    {
                        List<Generator> loadedData = (List<Generator>)serializer.Deserialize(fs);

                        // Задаем интересующее нас значение TimeStamp
                        DateTime targetTimeStamp = DateTime.Parse("2024-01-10T01:00:00Z");

                        // Номер гидроагрегата, для которого нужно обновить/добавить значение Load
                        int targetHydroUnitNumber = 5; // Установите соответствующий номер

                        // Находим соответствующий генератор и его Load
                        foreach (Generator item in loadedData)
                        {
                            GeneratorsLoad targetLoadItem = item.GeneratorsLoadList
                                .FirstOrDefault(loadItem => loadItem.TimeStamp == targetTimeStamp);

                            if (targetLoadItem != null)
                            {
                                // Находим индекс строки с заданным номером гидроагрегата в DataGridView
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

                                // Если строка с таким номером гидроагрегата не найдена, добавляем новую
                                if (rowIndex == -1)
                                {
                                    rowIndex = parametersHUGridView.Rows.Add();
                                    // Устанавливаем номер гидроагрегата в первом столбце
                                    parametersHUGridView.Rows[rowIndex].Cells[0].Value = targetHydroUnitNumber;
                                }

                                // Заменяем значение во втором столбце
                                parametersHUGridView.Rows[rowIndex].Cells[1].Value = targetLoadItem.Load;
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                // Обработка исключений, если они возникнут при чтении файла
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}