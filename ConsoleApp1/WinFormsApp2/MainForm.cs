using Npgsql;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using System.Xml.Serialization;
using static View.MainForm;
using CredentialManagement;
using Model;

namespace View
{
    public partial class MainForm : Form
    {
        private bool isEditingEnabled = false;

        private Authorization authorizationForm;

        // Добавляем переменные как члены класса
        private DataGridViewTextBoxColumn zoneColumn;
        private DataGridViewTextBoxColumn loadColumn;
        private DataGridViewComboBoxColumn statusColumn;

        public MainForm()
        {
            InitializeComponent();
            
            // Создаем таблицу
            CreateDataGridView();

            // Вызываем тестовый метод при загрузке формы
            TestFillData();
        }

        // Метод для создания таблицы
        private void CreateDataGridView()
        {
            // Создаем колонки
            DataGridViewTextBoxColumn HUColumn = new DataGridViewTextBoxColumn();
            HUColumn.HeaderText = "ГА";
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
            dataGridView.Columns.Add(HUColumn);
            dataGridView.Columns.Add(loadColumn);
            dataGridView.Columns.Add(zoneColumn);
            dataGridView.Columns.Add(statusColumn);

            // Устанавливаем DataGridView на вкладку tabPage1
            tabPage1.Controls.Add(dataGridView);

            // Устанавливаем размеры таблицы
            dataGridView.Width = 237;
            dataGridView.Height = 340;

            // запрет изменения размера
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AllowUserToResizeColumns = false;

            // Запрет добавления новых строк
            dataGridView.AllowUserToAddRows = false;

            // для всех колонок отключена сортировка
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        // Метод для тестовых данных
        private void TestFillData()
        {
            // Генерируем тестовые данные и заполняем таблицу
            Random random = new Random();
            for (int i = 1; i <= 12; i++)
            {
                // Выбираем случайный диапазон расходов
                int[] диапазон = random.Next(2) == 0 ? new[] { 0, 150 } : new[] { 320, 500 };

                // Генерируем случайный расход внутри выбранного диапазона
                int расход = random.Next(диапазон[0], диапазон[1] + 1);

                // Вычисляем зону работы
                int зона = расход >= 320 ? 3 : (расход <= 150 ? 1 : 2);

                // Добавляем строку с тестовыми данными
                dataGridView.Rows.Add($"{i}", расход, зона, "В работе");
            }
        }

        // Метод для сериализации данных в XML
        private void SerializeToXml(List<ParametersHU> data, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<ParametersHU>));

            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(fs, data);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Устанавливаем свойство ReadOnly для всех ячеек в true
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.ReadOnly = true;
                }
            }

            // Недоступность кнопки экспорта по умолчанию
            exportDBButton.Enabled = false;

            // Подписываемся на событие CellValueChanged
            dataGridView.CellValidating += dataGridView_CellValidating;

        }

        /// <summary>
        /// Событие на изменение ячеек в датагрид.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
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


        private void Save_Click(object sender, EventArgs e)
        {
            // Создаем список для хранения данных
            List<ParametersHU> dataItems = new List<ParametersHU>();

            // Проходим по каждой строке в DataGridView
            foreach (DataGridViewRow row in dataGridView.Rows)
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
                SerializeToXml(dataItems, saveFileDialog.FileName);
            }
        }

        private void EditingModeButton_Click(object sender, EventArgs e)
        {
            // Сохраняем данные перед изменением режима редактирования
            dataGridView.EndEdit();

            // Переключаем режим редактирования
            isEditingEnabled = !isEditingEnabled;

            // Устанавливаем свойство ReadOnly для всех ячеек, кроме первого столбца, в зависимости от режима редактирования
            foreach (DataGridViewRow row in dataGridView.Rows)
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
            // Создаем объект OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Устанавливаем фильтр для выбора файлов формата XML
            openFileDialog.Filter = "XML files (*.xml)|*.xml";

            // Устанавливаем заголовок диалогового окна
            openFileDialog.Title = "Выберите файл XML";

            // Устанавливаем свойство ShowHelp в false, чтобы скрыть опцию "All Files"
            openFileDialog.ShowHelp = false;

            // Показываем диалоговое окно и проверяем, был ли выбран файл
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Получаем путь к выбранному файлу
                string selectedFilePath = openFileDialog.FileName;

                // Ваш код для обработки выбранного файла
                // Например, загрузка данных из файла или отображение пути к файлу
                MessageBox.Show($"Выбран файл XML: {selectedFilePath}", "Выбор файла", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private void SaveDataToXml(string queryType)
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
            SaveDataToXml("Characteristics");
        }

        /// <summary>
        /// Сохранение протокола актуализации.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProtocolToolStripMenu_Click(object sender, EventArgs e)
        {
            SaveDataToXml("Protocol");
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
    }
}