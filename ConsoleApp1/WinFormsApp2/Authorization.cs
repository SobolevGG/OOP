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
        public string Login { get; private set; }
        public static string TargetDB { get => targetDB; set => targetDB = value; }

        private static string targetDB = @"HPPsDatabase";

        public string GetEnteredPassword()
        {
            return passwordTextBox.Text;
        }

        public string GetEnteredLogin()
        {
            return loginTextBox.Text;
        }

        public Authorization()
        {
            InitializeComponent();

            // Установить свойство PasswordChar для скрытия введенных символов
            passwordTextBox.PasswordChar = '*';
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            // Получить введенные пользователем логин и пароль
            string enteredUsername = loginTextBox.Text;
            string enteredPassword = passwordTextBox.Text;

            // Создать объект PostgresConnector с введенными логином и паролем
            var connector = new PostgresConnector("localhost", "HPPs", enteredUsername, enteredPassword);

            // Проверить правильность логина и пароля
            if (connector.TestConnection()) // Метод для проверки подключения
            {
                Login = enteredUsername;
                Password = enteredPassword;

                // Сохранить учетные данные после успешной авторизации
                SaveCredentials(enteredUsername, enteredPassword);

                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
                MessageBox.Show("Авторизация успешна.", 
                    "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                loginTextBox.Text = string.Empty; // Очистить TextBox для логина
                passwordTextBox.Text = string.Empty; // Очистить TextBox для пароля
                MessageBox.Show("Неверный логин или пароль. Авторизация не удалась.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveCredentials(string username, string password)
        {
            // Создать объект учетных данных
            var cred = new Credential
            {
                // Уникальный идентификатор для вашего приложения
                Target = TargetDB,
                // Имя пользователя
                Username = username,
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
