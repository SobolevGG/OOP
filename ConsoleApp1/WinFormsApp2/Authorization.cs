﻿using System;
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

            // Установить свойство PasswordChar для скрытия введенных символов
            passwordTextBox.PasswordChar = '*';
        }

        // Пароль для доступа к базе данных
        private static string passwordDB = "023098";

        // Только для чтения свойство
        public static string PasswordDB
        {
            get { return passwordDB; }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            // Ваш пароль для сравнения
            string actualPassword = passwordDB;

            // Получить введенный пользователем пароль
            string enteredPassword = passwordTextBox.Text;

            // Проверить правильность пароля
            if (enteredPassword == actualPassword)
            {
                Password = enteredPassword;
                DialogResult = DialogResult.OK;
                Close();
                MessageBox.Show("Пароль верный. Авторизация успешна.",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cancelButton_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}