﻿namespace View
{
    partial class RunCalcUserControl
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
            textBoxRate = new TextBox();
            textBoxWorkingHours = new TextBox();
            labelSalary = new Label();
            labelDaysInMonth = new Label();
            payrollMethod = new GroupBox();
            comboTrainingSelection = new ComboBox();
            payrollMethod.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxRate
            // 
            textBoxRate.Location = new Point(120, 5);
            textBoxRate.Margin = new Padding(3, 2, 3, 2);
            textBoxRate.Name = "textBoxRate";
            textBoxRate.Size = new Size(60, 23);
            textBoxRate.TabIndex = 2;
            // 
            // textBoxWorkingHours
            // 
            textBoxWorkingHours.Location = new Point(120, 32);
            textBoxWorkingHours.Margin = new Padding(3, 2, 3, 2);
            textBoxWorkingHours.Name = "textBoxWorkingHours";
            textBoxWorkingHours.Size = new Size(60, 23);
            textBoxWorkingHours.TabIndex = 3;
            // 
            // labelSalary
            // 
            labelSalary.AutoSize = true;
            labelSalary.Location = new Point(11, 9);
            labelSalary.Name = "labelSalary";
            labelSalary.Size = new Size(72, 15);
            labelSalary.TabIndex = 4;
            labelSalary.Text = "Ваш вес, кг:";
            // 
            // labelDaysInMonth
            // 
            labelDaysInMonth.AutoSize = true;
            labelDaysInMonth.Location = new Point(11, 36);
            labelDaysInMonth.Name = "labelDaysInMonth";
            labelDaysInMonth.Size = new Size(94, 15);
            labelDaysInMonth.TabIndex = 5;
            labelDaysInMonth.Text = "Расстояние, км:";
            // 
            // payrollMethod
            // 
            payrollMethod.BackColor = Color.White;
            payrollMethod.Controls.Add(comboTrainingSelection);
            payrollMethod.Location = new Point(5, 57);
            payrollMethod.Margin = new Padding(3, 2, 3, 2);
            payrollMethod.Name = "payrollMethod";
            payrollMethod.Padding = new Padding(3, 2, 3, 2);
            payrollMethod.Size = new Size(254, 55);
            payrollMethod.TabIndex = 8;
            payrollMethod.TabStop = false;
            payrollMethod.Text = "Стиль";
            // 
            // comboTrainingSelection
            // 
            comboTrainingSelection.FormattingEnabled = true;
            comboTrainingSelection.Location = new Point(17, 20);
            comboTrainingSelection.Margin = new Padding(3, 2, 3, 2);
            comboTrainingSelection.Name = "comboTrainingSelection";
            comboTrainingSelection.Size = new Size(213, 23);
            comboTrainingSelection.TabIndex = 9;
            // 
            // RunCalcUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(labelDaysInMonth);
            Controls.Add(labelSalary);
            Controls.Add(textBoxWorkingHours);
            Controls.Add(textBoxRate);
            Controls.Add(payrollMethod);
            Margin = new Padding(3, 2, 3, 2);
            Name = "RunCalcUserControl";
            Size = new Size(264, 113);
            payrollMethod.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxRate;
        private TextBox textBoxWorkingHours;
        private Label labelSalary;
        private Label labelDaysInMonth;
        private GroupBox payrollMethod;
        private ComboBox comboTrainingSelection;
    }
}
