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

            // Инициализация DataTable и BindingSource
            dataTable = new DataTable();
            dataTable.Columns.Add("GeneratorName", typeof(string));
            dataTable.Columns.Add("WaterFlow", typeof(double));

            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            // Привязка данных к DataGridView
            dataGridView.DataSource = bindingSource;

            // Добавление кнопки "Загрузить расходы"
            Button loadFlowsButton = new Button
            {
                Text = "Загрузить расходы",
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
            // Используйте OpenFileDialog для выбора файла с расходами
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "XML Files|*.xml",
                Title = "Выберите файл с расходами"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;

                // Загрузка данных из выбранного файла
                GeneratorFlows generatorFlows = LoadGeneratorFlowsFromFile(selectedFilePath);
                if (generatorFlows != null)
                {
                    // Очистка таблицы перед добавлением новых данных
                    dataTable.Rows.Clear();

                    // Загрузка данных о гидроагрегатах в DataTable
                    foreach (var generatorFlow in generatorFlows.Flows)
                    {
                        dataTable.Rows.Add(generatorFlow.Name, generatorFlow.WaterFlow);
                    }

                    // Обновление привязки данных
                    bindingSource.ResetBindings(false);
                }
                else
                {
                    MessageBox.Show("Ошибка загрузки данных о гидроагрегатах");
                }
            }

            // Обновление привязки данных
            bindingSource.ResetBindings(false);

            // Установка высоты строк для лучшего отображения данных
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Автоматическое изменение размеров столбцов
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Отключение автоматического изменения размеров столбцов
            dataGridView.AllowUserToResizeColumns = false;

            // Выравнивание заголовков столбцов по центру
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

        // Вызывается при загрузке формы
        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        // Нажатие на сохранить расходы воды
        private void saveWaterFlow_Click(object sender, EventArgs e)
        {
        }

        // Нажатие на открыть расходы воды
        private void openWaterFlow_Click(object sender, EventArgs e)
        {
            // Загрузка данных при загрузке формы
            LoadDataToGrid();
        }
    }
}
