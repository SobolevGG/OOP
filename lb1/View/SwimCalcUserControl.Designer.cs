

namespace View
{
    partial class SwimCalcUserControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
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
            labelWorkingDays = new Label();
            textBoxDaysInMonth = new TextBox();
            textBoxWorkingDays = new TextBox();
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
            // labelWorkingDays
            // 
            labelWorkingDays.AutoSize = true;
            labelWorkingDays.Location = new Point(11, 63);
            labelWorkingDays.Name = "labelWorkingDays";
            labelWorkingDays.Size = new Size(94, 15);
            labelWorkingDays.TabIndex = 3;
            labelWorkingDays.Text = "Интенсивность:";
            labelWorkingDays.KeyPress += LabelSalary_KeyPress;
            // 
            // textBoxDaysInMonth
            // 
            textBoxDaysInMonth.Location = new Point(120, 32);
            textBoxDaysInMonth.Margin = new Padding(3, 2, 3, 2);
            textBoxDaysInMonth.Name = "textBoxDaysInMonth";
            textBoxDaysInMonth.Size = new Size(60, 23);
            textBoxDaysInMonth.TabIndex = 4;
            // 
            // textBoxWorkingDays
            // 
            textBoxWorkingDays.Location = new Point(120, 59);
            textBoxWorkingDays.Margin = new Padding(3, 2, 3, 2);
            textBoxWorkingDays.Name = "textBoxWorkingDays";
            textBoxWorkingDays.Size = new Size(60, 23);
            textBoxWorkingDays.TabIndex = 5;
            // 
            // SwimCalcUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBoxWorkingDays);
            Controls.Add(textBoxDaysInMonth);
            Controls.Add(labelWorkingDays);
            Controls.Add(labelDaysInMonth);
            Controls.Add(labelSalary);
            Controls.Add(textBoxSalary);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SwimCalcUserControl";
            Size = new Size(264, 95);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxSalary;
        private Label labelSalary;
        private Label labelDaysInMonth;
        private Label labelWorkingDays;
        private TextBox textBoxDaysInMonth;
        private TextBox textBoxWorkingDays;
    }
}
