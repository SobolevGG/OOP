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

        public string GetEnteredPassword()
        {
            return passwordTextBox.Text;
        }

        public Authorization()
        {
            InitializeComponent();

            // Установить свойство PasswordChar для скрытия введенных символов
            passwordTextBox.PasswordChar = '*';
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            // Получить введенный пользователем пароль
            string enteredPassword = passwordTextBox.Text;

            // Создать объект PostgresConnector с введенным паролем
            var connector = new PostgresConnector("localhost", "HPPs", "postgres", enteredPassword);

            // Проверить правильность пароля
            if (connector.TestConnection()) // Метод для проверки подключения
            {
                Password = enteredPassword;
                DialogResult = DialogResult.OK;
                Close();
                MessageBox.Show("Пароль верный. Авторизация успешна.",
                    "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                passwordTextBox.Text = string.Empty; // Очистить TextBox
                MessageBox.Show("Неверный пароль. Авторизация не удалась.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
