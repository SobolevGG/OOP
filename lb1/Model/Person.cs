using System;
using System.Text.RegularExpressions;

namespace Model
{
    public class Person
    {
        /// <summary>
        /// Имя.
        /// </summary>
        private string _name;

        /// <summary>
        /// Фамилия.
        /// </summary>
        private string _surname;

        /// <summary>
        /// Возраст.
        /// </summary>
        private int _age;

        /// <summary>
        /// Вывод информации о пользователе.
        /// </summary>
        /// <returns></returns>
        public string GetInfo()
        {
            // Вывод информации о пользователе
            return $"Person info:\n" +
            $"name: {this._name}\n" +
            $"surname: {this._surname}\n" +
            $"age: {this._age}";
        }

        /// <summary>
        /// Конструктор для инициализации данных о пользователе.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="age"></param>
        public Person(string name, string surname, int age)
        {
            _name = name;
            _surname = surname;
            _age = age;

            Regex regex = new Regex("");
            // Если не соответствует шаблону, кинуть исключение!
            if (string.IsNullOrEmpty(name))
            {
                throw new System.ArgumentException("Name is`t correct!");
            }

        }
    }


}