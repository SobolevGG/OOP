using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class Authorization : Form
    {
        public string Password { get; private set; }

        public Authorization()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            // Ваш пароль для сравнения (замените его на фактический пароль)
            string actualPassword = "023098";

            // Получить введенный пользователем пароль
            string enteredPassword = passwordTextBox.Text;

            // Проверить правильность пароля
            if (enteredPassword == actualPassword)
            {
                Password = enteredPassword;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                errorLabel.Text = "Неверный пароль. Попробуйте снова.";
                passwordTextBox.Text = string.Empty; // Очистить TextBox
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
