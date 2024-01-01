/// <summary> 
/// Пространство имён View.
/// </summary>
namespace View
{
    /// <summary>
    /// Класс для пользовательского ввода.
    /// </summary>
    partial class RunCalcUserControl
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
            textBoxWeight = new TextBox();
            textBoxDistance = new TextBox();
            labelWeight = new Label();
            labelDistance = new Label();
            intensity = new GroupBox();
            comboBoxIntensity = new ComboBox();
            intensity.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxWeight
            // 
            textBoxWeight.Location = new Point(120, 5);
            textBoxWeight.Margin = new Padding(3, 2, 3, 2);
            textBoxWeight.Name = "textBoxWeight";
            textBoxWeight.Size = new Size(60, 23);
            textBoxWeight.TabIndex = 2;
            // 
            // textBoxDistance
            // 
            textBoxDistance.Location = new Point(120, 32);
            textBoxDistance.Margin = new Padding(3, 2, 3, 2);
            textBoxDistance.Name = "textBoxDistance";
            textBoxDistance.Size = new Size(60, 23);
            textBoxDistance.TabIndex = 3;
            // 
            // labelWeight
            // 
            labelWeight.AutoSize = true;
            labelWeight.Location = new Point(11, 9);
            labelWeight.Name = "labelWeight";
            labelWeight.Size = new Size(72, 15);
            labelWeight.TabIndex = 4;
            labelWeight.Text = "Ваш вес, кг:";
            // 
            // labelDistance
            // 
            labelDistance.AutoSize = true;
            labelDistance.Location = new Point(11, 36);
            labelDistance.Name = "labelDistance";
            labelDistance.Size = new Size(94, 15);
            labelDistance.TabIndex = 5;
            labelDistance.Text = "Расстояние, км:";
            // 
            // intensity
            // 
            intensity.BackColor = Color.White;
            intensity.Controls.Add(comboBoxIntensity);
            intensity.Location = new Point(5, 62);
            intensity.Margin = new Padding(3, 2, 3, 2);
            intensity.Name = "intensity";
            intensity.Padding = new Padding(3, 2, 3, 2);
            intensity.Size = new Size(244, 55);
            intensity.TabIndex = 8;
            intensity.TabStop = false;
            intensity.Text = "Интенсивность";
            // 
            // comboBoxIntensity
            // 
            comboBoxIntensity.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxIntensity.FormattingEnabled = true;
            comboBoxIntensity.Location = new Point(17, 20);
            comboBoxIntensity.Margin = new Padding(3, 2, 3, 2);
            comboBoxIntensity.Name = "comboBoxIntensity";
            comboBoxIntensity.Size = new Size(212, 23);
            comboBoxIntensity.TabIndex = 9;
            // 
            // RunCalcUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(labelDistance);
            Controls.Add(labelWeight);
            Controls.Add(textBoxDistance);
            Controls.Add(textBoxWeight);
            Controls.Add(intensity);
            Margin = new Padding(3, 2, 3, 2);
            Name = "RunCalcUserControl";
            Size = new Size(256, 153);
            intensity.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxWeight;
        private TextBox textBoxDistance;
        private Label labelWeight;
        private Label labelDistance;
        private GroupBox intensity;
        private ComboBox comboBoxIntensity;
    }
}
