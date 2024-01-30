using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Вызываем тестовый метод при загрузке формы
            TestFillData();
        }

        private void TestFillData()
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
