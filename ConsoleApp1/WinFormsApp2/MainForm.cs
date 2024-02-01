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



            // Вызываем тестовый метод при загрузке формы
            FillData();

            // Добавляем TextBox-ы для powerDRtableLayoutPanel
            AddPowerDRTextBoxesToTableLayoutPanel(powerDRtableLayoutPanel);
        }

        // Класс для хранения данных
        [Serializable]
        public class DataItem
        {
            public string GA { get; set; }
            public int Load { get; set; }
            public int Zone { get; set; }
            public string Status { get; set; }
        }

        // Метод для создания таблицы
        private void CreateDataGridView()
        {
            // Создаем колонки
            DataGridViewTextBoxColumn gaColumn = new DataGridViewTextBoxColumn();
            gaColumn.HeaderText = "ГА";
            gaColumn.Width = 44; // Устанавливаем ширину для столбца "ГА"
            gaColumn.ReadOnly = true;

            DataGridViewTextBoxColumn loadColumn = new DataGridViewTextBoxColumn();
            loadColumn.HeaderText = "Загрузка, МВт";
            loadColumn.Width = 70; // Устанавливаем ширину для столбца "Загрузка"

            DataGridViewTextBoxColumn zoneColumn = new DataGridViewTextBoxColumn();
            zoneColumn.HeaderText = "Зона";
            zoneColumn.Width = 40; // Устанавливаем ширину для столбца "Зона работы"

            // Создаем комбобокс для столбца "Статус"
            DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
            statusColumn.HeaderText = "Статус";
            statusColumn.Items.AddRange("В работе", "Выведен");
            statusColumn.Width = 80; // Устанавливаем ширину для столбца "Статус"

            loadColumn.HeaderCell.Style.WrapMode = DataGridViewTriState.True;

            // Устанавливаем выравнивание по центру для ячеек и заголовков столбцов
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

            // Добавляем колонки на DataGridView
            dataGridView.Columns.Add(gaColumn);
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

        private void FillData()
        {
            // Создаем таблицу
            CreateDataGridView();

            // Заполняем таблицу данными
            TestFillData();
        }

        // Метод для сериализации данных в XML
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
            // Устанавливаем свойство ReadOnly для всех ячеек в true
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.ReadOnly = true;
                }
            }

            // Добавляем TextBox-ы в TableLayoutPanel
            AddTextBoxesToTableLayoutPanel(tableLayoutPanel);

            // Добавляем TableLayoutPanel в calcGroupBox
            calcGroupBox.Controls.Add(tableLayoutPanel);

            // Заблокировать кнопку при неверном пароле
            exportDBButton.Enabled = false;
        }

        private void AddTextBoxesToTableLayoutPanel(TableLayoutPanel tableLayoutPanel)
        {
            // Создаем TextBox-ы
            TextBox textBox1 = new TextBox();
            textBox1.Dock = DockStyle.Fill;
            textBox1.Text = "НПРЧ";
            textBox1.ReadOnly = true;
            // невозможность установки курсора
            textBox1.Enter += TextBox_Enter;
            // Убираем рамку
            textBox1.BorderStyle = BorderStyle.None;

            TextBox textBox2 = new TextBox();
            textBox2.Dock = DockStyle.Fill;

            TextBox textBox3 = new TextBox();
            textBox3.Dock = DockStyle.Fill;
            textBox3.Text = "ОГ";
            textBox3.ReadOnly = true;
            textBox3.Enter += TextBox_Enter;
            // Убираем рамку
            textBox3.BorderStyle = BorderStyle.None;

            TextBox textBox4 = new TextBox();
            textBox4.Dock = DockStyle.Fill;


            // Добавляем TextBox-ы в ячейки TableLayoutPanel
            tableLayoutPanel.Controls.Add(textBox1, 0, 0);
            tableLayoutPanel.Controls.Add(textBox2, 1, 0);
            tableLayoutPanel.Controls.Add(textBox3, 0, 1);
            tableLayoutPanel.Controls.Add(textBox4, 1, 1);
        }

        private void AddPowerDRTextBoxesToTableLayoutPanel(TableLayoutPanel tableLayoutPanel)
        {
            // Создаем TextBox-ы
            TextBox textBox1 = new TextBox();
            textBox1.Dock = DockStyle.Fill;
            textBox1.Text = "СВМ 220 кВ";
            textBox1.ReadOnly = true;
            textBox1.Enter += TextBox_Enter;
            // Убираем рамку
            textBox1.BorderStyle = BorderStyle.None;

            TextBox textBox2 = new TextBox();
            textBox2.Dock = DockStyle.Fill;
            // Оставляем рамку (по умолчанию)
            textBox2.BorderStyle = BorderStyle.FixedSingle;

            TextBox textBox3 = new TextBox();
            textBox3.Dock = DockStyle.Fill;

            textBox3.Text = "СВМ 500 кВ";
            textBox3.ReadOnly = true;
            textBox3.Enter += TextBox_Enter;
            // Убираем рамку
            textBox3.BorderStyle = BorderStyle.None;

            TextBox textBox4 = new TextBox();
            textBox4.Dock = DockStyle.Fill;
            // Оставляем рамку (по умолчанию)
            textBox4.BorderStyle = BorderStyle.FixedSingle;

            // Добавляем TextBox-ы в ячейки TableLayoutPanel
            tableLayoutPanel.Controls.Add(textBox1, 0, 0);
            tableLayoutPanel.Controls.Add(textBox2, 1, 0);
            tableLayoutPanel.Controls.Add(textBox3, 0, 1);
            tableLayoutPanel.Controls.Add(textBox4, 1, 1);
        }



        private void TextBox_Enter(object sender, EventArgs e)
        {
            // При активации TextBox устанавливаем фокус на другой элемент
            ActiveControl = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Создаем список для хранения данных
            List<DataItem> dataItems = new List<DataItem>();

            // Проходим по каждой строке в DataGridView
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Создаем объект DataItem на основе данных в строке
                DataItem item = new DataItem
                {
                    GA = row.Cells[0].Value?.ToString(), // Индекс 0 соответствует первому столбцу
                    Load = Convert.ToInt32(row.Cells[1].Value), // Индекс 1 соответствует второму столбцу
                    Zone = Convert.ToInt32(row.Cells[2].Value), // Индекс 2 соответствует третьему столбцу
                    Status = row.Cells[3].Value?.ToString() // Индекс 3 соответствует четвертому столбцу
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

        private void editingModeButton_Click(object sender, EventArgs e)
        {
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
            saveParamsHU.Enabled = isEditingEnabled;

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
        private void openDoc_Click(object sender, EventArgs e)
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

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
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
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Получаем путь к выбранному файлу
                string selectedFilePath = openFileDialog.FileName;

                // Ваш код для обработки выбранного файла
                // Например, загрузка данных из файла или отображение пути к файлу
                MessageBox.Show($"Выбран файл XML: {selectedFilePath}", "Выбор файла", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void authorizationButton_Click(object sender, EventArgs e)
        {
            // Вывести диалоговое окно для авторизации
            Authorization authorizationForm = new Authorization();
            DialogResult result = authorizationForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Разблокировать кнопку после успешной авторизации
                exportDBButton.Enabled = true;
            }
        }

        private void currentCharacteristicsToolStripMenu_Click(object sender, EventArgs e)
        {
            var connector = new PostgresConnector("localhost", "HPPs", "postgres", $"{Authorization.PasswordDB}");

            try
            {
                // Чтение данных из столбцов name, characteristic и change_date из таблицы generator_characteristic_history
                string selectQuery = "SELECT name, characteristic FROM hydro_generators;";
                var reader = connector.ExecuteQuery(selectQuery);

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

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;
                        dataTable.WriteXml(filePath);

                        MessageBox.Show("Данные успешно сохранены в XML файл.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при чтении данных из базы данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Закрытие соединения
                connector.CloseConnection();
            }
        }

        private void protocolToolStripMenu_Click(object sender, EventArgs e)
        {
            var connector = new PostgresConnector("localhost", "HPPs", "postgres", $"{Authorization.PasswordDB}");

            try
            {
                // Чтение данных из столбцов name, characteristic и change_date из таблицы generator_characteristic_history
                string selectQuery = "SELECT hydro_generators.name, generator_characteristic_history.characteristic, generator_characteristic_history.change_date " +
                    "FROM generator_characteristic_history " +
                    "JOIN hydro_generators ON generator_characteristic_history.generator_id = hydro_generators.id;";
                var reader = connector.ExecuteQuery(selectQuery);

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

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;
                        dataTable.WriteXml(filePath);

                        MessageBox.Show("Данные успешно сохранены в XML файл.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при чтении данных из базы данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Закрытие соединения
                connector.CloseConnection();
            }
        }

        private void exportDBButton_Click(object sender, EventArgs e)
        {
            // Проверка доступности кнопки
            if (!exportDBButton.Enabled)
            {
                MessageBox.Show("Авторизация не выполнена. Введите правильный пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
        }
    }
}