﻿/// <summary> 
/// Пространство имён View.
/// </summary>
namespace View
{
    /// <summary>
    /// Класс для пользовательского ввода.
    /// </summary>
    partial class PressCalcUserControl
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
            labelHourlyWageRate = new Label();
            labelTimeHourlyRate = new Label();
            textBoxWeight = new TextBox();
            textBoxRepetitions = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // labelHourlyWageRate
            // 
            labelHourlyWageRate.AutoSize = true;
            labelHourlyWageRate.Location = new Point(11, 9);
            labelHourlyWageRate.Name = "labelHourlyWageRate";
            labelHourlyWageRate.Size = new Size(51, 15);
            labelHourlyWageRate.TabIndex = 0;
            labelHourlyWageRate.Text = "Вес*, кг:";
            labelHourlyWageRate.TextAlign = ContentAlignment.MiddleLeft;
            labelHourlyWageRate.KeyPress += LabelHourlyWageRate_KeyPress;
            // 
            // labelTimeHourlyRate
            // 
            labelTimeHourlyRate.AutoSize = true;
            labelTimeHourlyRate.Location = new Point(11, 36);
            labelTimeHourlyRate.Name = "labelTimeHourlyRate";
            labelTimeHourlyRate.Size = new Size(60, 15);
            labelTimeHourlyRate.TabIndex = 1;
            labelTimeHourlyRate.Text = "Повторы:";
            labelTimeHourlyRate.KeyPress += LabelHourlyWageRate_KeyPress;
            // 
            // textBoxWeight
            // 
            textBoxWeight.Location = new Point(88, 5);
            textBoxWeight.Margin = new Padding(3, 2, 3, 2);
            textBoxWeight.Name = "textBoxWeight";
            textBoxWeight.Size = new Size(53, 23);
            textBoxWeight.TabIndex = 2;
            // 
            // textBoxRepetitions
            // 
            textBoxRepetitions.Location = new Point(88, 32);
            textBoxRepetitions.Margin = new Padding(3, 2, 3, 2);
            textBoxRepetitions.Name = "textBoxRepetitions";
            textBoxRepetitions.Size = new Size(53, 23);
            textBoxRepetitions.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 63);
            label1.Name = "label1";
            label1.Size = new Size(112, 15);
            label1.TabIndex = 4;
            label1.Text = "* - с учётом грифа ";
            // 
            // PressCalcUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(textBoxRepetitions);
            Controls.Add(textBoxWeight);
            Controls.Add(labelTimeHourlyRate);
            Controls.Add(labelHourlyWageRate);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PressCalcUserControl";
            Size = new Size(264, 95);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelHourlyWageRate;
        private Label labelTimeHourlyRate;
        private TextBox textBoxWeight;
        private TextBox textBoxRepetitions;
        private Label label1;
    }
}