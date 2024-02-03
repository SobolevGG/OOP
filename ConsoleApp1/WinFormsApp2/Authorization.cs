using CredentialManagement;
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
        public static string TargetDB { get => targetDB; set => targetDB = value; }

        private static string targetDB = @"HPPsDatabase";

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

                // Сохранить учетные данные после успешной авторизации
                SaveCredentials(enteredPassword);

                DialogResult = System.Windows.Forms.DialogResult.OK;
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

        private void SaveCredentials(string password)
        {
            // Создать объект учетных данных
            var cred = new Credential
            {
                // Уникальный идентификатор для вашего приложения
                Target = TargetDB,
                // Имя пользователя
                Username = "postgres",
                Password = password
            };

            // Сохранить учетные данные
            cred.Save();
        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}
