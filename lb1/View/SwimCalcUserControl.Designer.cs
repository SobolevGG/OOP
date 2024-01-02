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
            textBoxWeight = new TextBox();
            labelWeight = new Label();
            labelDistance = new Label();
            textBoxDistance = new TextBox();
            style = new GroupBox();
            comboBoxStyle = new ComboBox();
            style.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxWeight
            // 
            textBoxWeight.Location = new Point(120, 5);
            textBoxWeight.Margin = new Padding(3, 2, 3, 2);
            textBoxWeight.Name = "textBoxWeight";
            textBoxWeight.Size = new Size(60, 23);
            textBoxWeight.TabIndex = 0;
            // 
            // labelWeight
            // 
            labelWeight.AutoSize = true;
            labelWeight.Location = new Point(11, 9);
            labelWeight.Name = "labelWeight";
            labelWeight.Size = new Size(72, 15);
            labelWeight.TabIndex = 1;
            labelWeight.Text = "Ваш вес, кг:";
            labelWeight.KeyPress += LabelSwimKeyPress;
            // 
            // labelDistance
            // 
            labelDistance.AutoSize = true;
            labelDistance.Location = new Point(11, 36);
            labelDistance.Name = "labelDistance";
            labelDistance.Size = new Size(94, 15);
            labelDistance.TabIndex = 2;
            labelDistance.Text = "Расстояние, км:";
            labelDistance.KeyPress += LabelSwimKeyPress;
            // 
            // textBoxDistance
            // 
            textBoxDistance.Location = new Point(120, 32);
            textBoxDistance.Margin = new Padding(3, 2, 3, 2);
            textBoxDistance.Name = "textBoxDistance";
            textBoxDistance.Size = new Size(60, 23);
            textBoxDistance.TabIndex = 4;
            // 
            // style
            // 
            style.BackColor = Color.White;
            style.Controls.Add(comboBoxStyle);
            style.Location = new Point(5, 62);
            style.Margin = new Padding(3, 2, 3, 2);
            style.Name = "style";
            style.Padding = new Padding(3, 2, 3, 2);
            style.Size = new Size(244, 55);
            style.TabIndex = 9;
            style.TabStop = false;
            style.Text = "Стиль";
            // 
            // comboBoxStyle
            // 
            comboBoxStyle.DropDownStyle = ComboBoxStyle.DropDownList;
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
            Controls.Add(style);
            Controls.Add(textBoxDistance);
            Controls.Add(labelDistance);
            Controls.Add(labelWeight);
            Controls.Add(textBoxWeight);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SwimCalcUserControl";
            Size = new Size(256, 153);
            style.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxWeight;
        private Label labelWeight;
        private Label labelDistance;
        private TextBox textBoxDistance;
        private GroupBox style;
        private ComboBox comboBoxStyle;
    }
}
