namespace View
{
    partial class FilterTrainingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterTrainingForm));
            groupBox1 = new GroupBox();
            label1 = new Label();
            textBoxTraining = new TextBox();
            checkBoxInput = new CheckBox();
            checkBoxSwimCalc = new CheckBox();
            checkBoxRunCalc = new CheckBox();
            checkBoxPressCalc = new CheckBox();
            buttonSearch = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBoxTraining);
            groupBox1.Controls.Add(checkBoxInput);
            groupBox1.Controls.Add(checkBoxSwimCalc);
            groupBox1.Controls.Add(checkBoxRunCalc);
            groupBox1.Controls.Add(checkBoxPressCalc);
            groupBox1.Location = new Point(8, 2);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(240, 126);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Параметры фильтрации";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(339, 146);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 5;
            // 
            // textBoxTraining
            // 
            textBoxTraining.Location = new Point(151, 94);
            textBoxTraining.Margin = new Padding(3, 2, 3, 2);
            textBoxTraining.Name = "textBoxTraining";
            textBoxTraining.Size = new Size(79, 23);
            textBoxTraining.TabIndex = 4;
            textBoxTraining.TextChanged += TextBoxTraining_TextChanged;
            textBoxTraining.KeyPress += TextBoxTraining_KeyPress;
            // 
            // checkBoxInput
            // 
            checkBoxInput.AutoSize = true;
            checkBoxInput.Location = new Point(12, 96);
            checkBoxInput.Margin = new Padding(3, 2, 3, 2);
            checkBoxInput.Name = "checkBoxInput";
            checkBoxInput.Size = new Size(136, 19);
            checkBoxInput.TabIndex = 3;
            checkBoxInput.Text = "Поиск по калориям";
            checkBoxInput.UseVisualStyleBackColor = true;
            checkBoxInput.CheckedChanged += CheckBoxInput_CheckedChanged;
            // 
            // checkBoxSwimCalc
            // 
            checkBoxSwimCalc.AutoSize = true;
            checkBoxSwimCalc.Location = new Point(12, 48);
            checkBoxSwimCalc.Margin = new Padding(3, 2, 3, 2);
            checkBoxSwimCalc.Name = "checkBoxSwimCalc";
            checkBoxSwimCalc.Size = new Size(80, 19);
            checkBoxSwimCalc.TabIndex = 2;
            checkBoxSwimCalc.Text = "Плавание";
            checkBoxSwimCalc.UseVisualStyleBackColor = true;
            // 
            // checkBoxRunCalc
            // 
            checkBoxRunCalc.AutoSize = true;
            checkBoxRunCalc.Location = new Point(12, 24);
            checkBoxRunCalc.Margin = new Padding(3, 2, 3, 2);
            checkBoxRunCalc.Name = "checkBoxRunCalc";
            checkBoxRunCalc.Size = new Size(44, 19);
            checkBoxRunCalc.TabIndex = 1;
            checkBoxRunCalc.Text = "Бег";
            checkBoxRunCalc.UseVisualStyleBackColor = true;
            // 
            // checkBoxPressCalc
            // 
            checkBoxPressCalc.AutoSize = true;
            checkBoxPressCalc.Location = new Point(12, 72);
            checkBoxPressCalc.Margin = new Padding(3, 2, 3, 2);
            checkBoxPressCalc.Name = "checkBoxPressCalc";
            checkBoxPressCalc.Size = new Size(97, 19);
            checkBoxPressCalc.TabIndex = 0;
            checkBoxPressCalc.Text = "Жим штанги";
            checkBoxPressCalc.UseVisualStyleBackColor = true;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(156, 134);
            buttonSearch.Margin = new Padding(3, 2, 3, 2);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(93, 22);
            buttonSearch.TabIndex = 1;
            buttonSearch.Text = "Поиск";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += ButtonSearch_Click;
            // 
            // FilterTraining
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(256, 162);
            Controls.Add(buttonSearch);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "FilterTraining";
            Text = "Фильтр";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private TextBox textBoxTraining;
        private CheckBox checkBoxInput;
        private CheckBox checkBoxSwimCalc;
        private CheckBox checkBoxRunCalc;
        private CheckBox checkBoxPressCalc;
        private Button buttonSearch;
    }
}