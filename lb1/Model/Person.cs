using System;
using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Класс для пользователя.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        private string _name;

        /// <summary>
        /// Фамилия пользователя.
        /// </summary>
        private string _surname;

        /// <summary>
        /// Возраст пользователя.
        /// </summary>
        private int _age;

        /// <summary>
        /// Пол пользователя.
        /// </summary>
        private Gender _gender;

        /// <summary>
        /// Минимальный возраст для контроля некорректного ввода.
        /// </summary>
        private int MinAge = 0;

        /// <summary>
        /// Максимальный возраст для контроля некорректного ввода.
        /// </summary>
        private int MaxAge = 200;

        /// <summary>
        /// Проверка соответствия имени шаблону.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string CheckLanguage(string value) 
        {
            // + значит 1 и более
            // * значит 0 и более
            var latin = new Regex(@"^[A-z]+[-][A-z]*$");
            var cyrillic = new Regex(@"^[А-я]+[-][А-я]*$");

            if (!string.IsNullOrEmpty(value)) 
            { 
                if (cyrillic.IsMatch(value)) 
                {
                    return Language.Russian;
                }
                else if (latin.IsMatch(value)) 
                {
                    return Language.English;
                }
                else 
                {
                    throw new ArgumentException("Некорректный ввод, попробуйте снова!");
                }
            }

            return Language.Unknown;
        }

        /// <summary>
        /// Проверка имени.
        /// </summary>
        public string Name
        {
            get 
            {
                return _name;
            }

            set 
            { 
                _ = CheckLanguage(value);
            }
        }

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