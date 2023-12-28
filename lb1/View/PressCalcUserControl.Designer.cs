namespace View
{
    partial class PressCalcUserControl
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
            this.labelHourlyWageRate = new System.Windows.Forms.Label();
            this.labelTimeHourlyRate = new System.Windows.Forms.Label();
            this.textBoxWeight = new System.Windows.Forms.TextBox();
            this.textBoxRepetitions = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelHourlyWageRate
            // 
            this.labelHourlyWageRate.AutoSize = true;
            this.labelHourlyWageRate.Location = new System.Drawing.Point(18, 20);
            this.labelHourlyWageRate.Name = "labelHourlyWageRate";
            this.labelHourlyWageRate.Size = new System.Drawing.Size(115, 20);
            this.labelHourlyWageRate.TabIndex = 0;
            this.labelHourlyWageRate.Text = "Часовая ставка";
            this.labelHourlyWageRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LabelHourlyWageRate_KeyPress);
            // 
            // labelTimeHourlyRate
            // 
            this.labelTimeHourlyRate.AutoSize = true;
            this.labelTimeHourlyRate.Location = new System.Drawing.Point(18, 62);
            this.labelTimeHourlyRate.Name = "labelTimeHourlyRate";
            this.labelTimeHourlyRate.Size = new System.Drawing.Size(206, 20);
            this.labelTimeHourlyRate.TabIndex = 1;
            this.labelTimeHourlyRate.Text = "Кол-во отработанных часов";
            this.labelTimeHourlyRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LabelHourlyWageRate_KeyPress);
            // 
            // textBoxWeight
            // 
            this.textBoxWeight.Location = new System.Drawing.Point(139, 20);
            this.textBoxWeight.Name = "textBoxWeight";
            this.textBoxWeight.Size = new System.Drawing.Size(134, 27);
            this.textBoxWeight.TabIndex = 2;
            // 
            // textBoxRepetitions
            // 
            this.textBoxRepetitions.Location = new System.Drawing.Point(230, 62);
            this.textBoxRepetitions.Name = "textBoxRepetitions";
            this.textBoxRepetitions.Size = new System.Drawing.Size(43, 27);
            this.textBoxRepetitions.TabIndex = 3;
            // 
            // PressCalcUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxRepetitions);
            this.Controls.Add(this.textBoxWeight);
            this.Controls.Add(this.labelTimeHourlyRate);
            this.Controls.Add(this.labelHourlyWageRate);
            this.Name = "PressCalcUserControl";
            this.Size = new System.Drawing.Size(292, 121);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelHourlyWageRate;
        private Label labelTimeHourlyRate;
        private TextBox textBoxWeight;
        private TextBox textBoxRepetitions;
    }
}
