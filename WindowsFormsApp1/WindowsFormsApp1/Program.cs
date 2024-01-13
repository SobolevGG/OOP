using System;
using System.Windows.Forms;

namespace GeneratorCompositionApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeGeneratorButtons();
        }

        private void InitializeGeneratorButtons()
        {
            const int buttonCount = 12;

            for (int i = 1; i <= buttonCount; i++)
            {
                var radioButton = new RadioButton
                {
                    Text = $"Генератор {i}",
                    Name = $"generator{i}",
                    AutoSize = true,
                    Location = new System.Drawing.Point(20, 30 + 25 * i)
                };

                Controls.Add(radioButton);
            }

            var headerLabel = new Label
            {
                Text = "Состав генерирующего оборудования",
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(20, 5),
                AutoSize = true
            };

            Controls.Add(headerLabel);
        }
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
