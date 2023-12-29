/// <summary> 
/// Пространство имён View.
/// </summary>
namespace View
{
    /// <summary>
    /// Класс для пользовательского ввода.
    /// </summary>
    partial class SwimCalcUserControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">true - если управляемые 
        /// ресурсы должны быть освобождены; 
        /// иначе - false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxSalary = new TextBox();
            labelSalary = new Label();
            labelDaysInMonth = new Label();
            textBoxDaysInMonth = new TextBox();
            payrollMethod = new GroupBox();
            comboBoxStyle = new ComboBox();
            payrollMethod.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxSalary
            // 
            textBoxSalary.Location = new Point(120, 5);
            textBoxSalary.Margin = new Padding(3, 2, 3, 2);
            textBoxSalary.Name = "textBoxSalary";
            textBoxSalary.Size = new Size(60, 23);
            textBoxSalary.TabIndex = 0;
            // 
            // labelSalary
            // 
            labelSalary.AutoSize = true;
            labelSalary.Location = new Point(11, 9);
            labelSalary.Name = "labelSalary";
            labelSalary.Size = new Size(72, 15);
            labelSalary.TabIndex = 1;
            labelSalary.Text = "Ваш вес, кг:";
            labelSalary.KeyPress += LabelSalary_KeyPress;
            // 
            // labelDaysInMonth
            // 
            labelDaysInMonth.AutoSize = true;
            labelDaysInMonth.Location = new Point(11, 36);
            labelDaysInMonth.Name = "labelDaysInMonth";
            labelDaysInMonth.Size = new Size(94, 15);
            labelDaysInMonth.TabIndex = 2;
            labelDaysInMonth.Text = "Расстояние, км:";
            labelDaysInMonth.KeyPress += LabelSalary_KeyPress;
            // 
            // textBoxDaysInMonth
            // 
            textBoxDaysInMonth.Location = new Point(120, 32);
            textBoxDaysInMonth.Margin = new Padding(3, 2, 3, 2);
            textBoxDaysInMonth.Name = "textBoxDaysInMonth";
            textBoxDaysInMonth.Size = new Size(60, 23);
            textBoxDaysInMonth.TabIndex = 4;
            // 
            // payrollMethod
            // 
            payrollMethod.BackColor = Color.White;
            payrollMethod.Controls.Add(comboBoxStyle);
            payrollMethod.Location = new Point(5, 62);
            payrollMethod.Margin = new Padding(3, 2, 3, 2);
            payrollMethod.Name = "payrollMethod";
            payrollMethod.Padding = new Padding(3, 2, 3, 2);
            payrollMethod.Size = new Size(244, 55);
            payrollMethod.TabIndex = 9;
            payrollMethod.TabStop = false;
            payrollMethod.Text = "Стиль";
            // 
            // comboBoxStyle
            // 
            comboBoxStyle.FormattingEnabled = true;
            comboBoxStyle.Location = new Point(17, 20);
            comboBoxStyle.Margin = new Padding(3, 2, 3, 2);
            comboBoxStyle.Name = "comboBoxStyle";
            comboBoxStyle.Size = new Size(212, 23);
            comboBoxStyle.TabIndex = 9;
            // 
            // SwimCalcUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(payrollMethod);
            Controls.Add(textBoxDaysInMonth);
            Controls.Add(labelDaysInMonth);
            Controls.Add(labelSalary);
            Controls.Add(textBoxSalary);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SwimCalcUserControl";
            Size = new Size(256, 153);
            payrollMethod.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxSalary;
        private Label labelSalary;
        private Label labelDaysInMonth;
        private TextBox textBoxDaysInMonth;
        private GroupBox payrollMethod;
        private ComboBox comboBoxStyle;
    }
}
