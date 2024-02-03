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
            passwordLabel = new Label();
            cancelButton = new Button();
            loginLabel = new Label();
            loginTextBox = new TextBox();
            SuspendLayout();
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(50, 86);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(143, 23);
            passwordTextBox.TabIndex = 1;
            // 
            // okButton
            // 
            okButton.Location = new Point(50, 115);
            okButton.Name = "okButton";
            okButton.Size = new Size(59, 23);
            okButton.TabIndex = 2;
            okButton.Text = "Вход";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(47, 68);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(96, 15);
            passwordLabel.TabIndex = 5;
            passwordLabel.Text = "Введите пароль:";
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(134, 115);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(59, 23);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // loginLabel
            // 
            loginLabel.AutoSize = true;
            loginLabel.Location = new Point(47, 24);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new Size(89, 15);
            loginLabel.TabIndex = 4;
            loginLabel.Text = "Введите логин:";
            // 
            // loginTextBox
            // 
            loginTextBox.Location = new Point(50, 42);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.Size = new Size(143, 23);
            loginTextBox.TabIndex = 0;
            // 
            // Authorization
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(240, 161);
            Controls.Add(loginLabel);
            Controls.Add(loginTextBox);
            Controls.Add(cancelButton);
            Controls.Add(passwordLabel);
            Controls.Add(okButton);
            Controls.Add(passwordTextBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Authorization";
            Text = "Авторизация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox passwordTextBox;
        private Button okButton;
        private Label passwordLabel;
        private Button cancelButton;
        private Label loginLabel;
        private TextBox loginTextBox;
    }
}