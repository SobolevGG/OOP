using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Класс для пользователя.
    /// </summary>
    public class Person
    {
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
                throw new System.ArgumentException("Ошибка: " +
                    "имя введено некорректно!");
            }

        }

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
        /// Вывод информации о пользователе.
        /// </summary>
        /// <returns></returns>
        public string GetInfo()
        {
            // Вывод информации о пользователе
            return $"Информация о пользователе:\n" +
            $"Имя: {this._name}\n" +
            $"Фамилия: {this._surname}\n" +
            $"Возраст: {this._age}";
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
                _name = FixRegister(value);

                if (_surname != null)
                {
                    CheckName();
                }
            }
        }

        /// <summary>
        /// Проверка фамилии.
        /// </summary>
        public string Surname
        {
            get
            {
                return _surname;
            }

            set
            {
                _ = CheckLanguage(value);
                _surname = FixRegister(value);

                if (_surname != null)
                {
                    CheckName();
                }
            }
        }

        /// <summary>
        /// Проверка возраста.
        /// </summary>
        public int Age
        {
            get
            {
                return _age;
            }

            set
            {
                if (value > MinAge && value < MaxAge)
                {
                    _age = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Ошибка: " +
                        "подразумевается, что возраст должен быть " +
                        $"в диапазоне от {MinAge} до {MaxAge} лет!");
                }
            }
        }

        /// <summary>
        /// Проверка пола.
        /// </summary>
        public Gender Gender
        {
            get
            {
                return _gender;
            }

            set
            {
                _gender = value;
            }
        }

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
                    return Language.Russian.ToString();
                }
                else if (latin.IsMatch(value))
                {
                    return Language.English.ToString();
                }
                else
                {
                    throw new ArgumentException("Некорректный ввод, попробуйте снова!");
                }
            }

            return Language.Unknown.ToString();
        }

        private void CheckName()
        {
            if ((!string.IsNullOrEmpty(Name))
                && (!string.IsNullOrEmpty(Surname)))
            {
                var nameLanguage = CheckLanguage(Name);
                var surnameLanguage = CheckLanguage(Surname);

                if (nameLanguage != surnameLanguage)
                {
                    throw new FormatException("Ошибка: язык имени " +
                        "и фамилии различается!");
                }
            }
        }

        private static string FixRegister(string word)
        {
            return CultureInfo.CurrentCulture.TextInfo.
                ToTitleCase(word.ToLower());
        }
    }


}