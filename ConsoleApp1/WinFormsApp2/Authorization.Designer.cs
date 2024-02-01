namespace View
{
    partial class Authorization
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authorization));
            passwordTextBox = new TextBox();
            okButton = new Button();
            errorLabel = new Label();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(38, 34);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(143, 23);
            passwordTextBox.TabIndex = 0;
            // 
            // okButton
            // 
            okButton.Location = new Point(38, 75);
            okButton.Name = "okButton";
            okButton.Size = new Size(59, 23);
            okButton.TabIndex = 1;
            okButton.Text = "Вход";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.Location = new Point(38, 16);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(96, 15);
            errorLabel.TabIndex = 2;
            errorLabel.Text = "Введите пароль:";
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(122, 75);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(59, 23);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click_1;
            // 
            // Authorization
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(220, 115);
            Controls.Add(cancelButton);
            Controls.Add(errorLabel);
            Controls.Add(okButton);
            Controls.Add(passwordTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Authorization";
            Text = "Авторизация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox passwordTextBox;
        private Button okButton;
        private Label errorLabel;
        private MenuStrip menuStrip1;
        private Button cancelButton;
    }
}