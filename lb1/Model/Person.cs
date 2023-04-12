using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml.Linq;

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
        /// <param name="name">Имя.</param>
        /// <param name="surname">Фамилия.</param>
        /// <param name="age">Возраст.</param>
        /// /// <param name="gender">Пол.</param>
        public Person(string name,
                      string surname,
                      int age,
                      Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
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
        private const int MinAge = 0;

        /// <summary>
        /// Максимальный возраст для контроля некорректного ввода.
        /// </summary>
        private const int MaxAge = 200;

        /// <summary>
        /// Вывод информации о пользователе.
        /// </summary>
        /// <returns></returns>
        public string GetInfo()
        {
            // Вывод информации о пользователе
            return $"Информация о пользователе:\n" +
                $"Имя: {this._name}, " +
                $"Фамилия: {this._surname}, " +
                $"\nВозраст: {this._age}, " +
                $"Пол: {this.Gender}" ;
        }

        // Всё же нужно для корректной работы Action`ов
        public Person()
        {
        }

        /// <summary>
        /// Метод получения случайных персон.
        /// </summary>
        /// <returns></returns>
        public static Person GetRandomPerson()
        {
            string[] maleNames =
            {
                "Андрей", "ВикТОР", "Илья", "Владисlove", "ЕвГЕНИЙ",
                "Вячеслав", "Пётр", "Иван", "Алексей", "Александр"
            };

            string[] femaleNames =
            {
                "Виктория", "Евгения", "Екатерина", "Юлия", "Алёна",
                "Людмила", "Ольга", "Валентина", "Александра", "Нюша"
            };

            string[] surnames =
            {
                "Ким", "Чен", "Фукс", "Икс", "Сок",
                "Лок", "Лоск", "Кей", "Кац", "Фру"
            };

            var random = new Random();
            var tmpNumber = random.Next(1, 3);

            Gender tmpGender = tmpNumber == 1
                ? Gender.Male
                : Gender.Female;

            string tmpName = tmpGender == Gender.Male
                ? maleNames[random.Next(maleNames.Length)]
                : femaleNames[random.Next(femaleNames.Length)];

            var tmpSurname = surnames[random.Next(surnames.Length)];
            var tmpAge = random.Next(MinAge, MaxAge);

            return new Person(tmpName, tmpSurname, tmpAge, tmpGender);
        }

        /// <summary>
        /// Метод проверки на пустой ввод.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public void CheckNullOrEmpty(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(value, "Ввод не может " +
                    "быть пустым!");
            }
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
                // TODO: дублирование
                CheckNullOrEmpty(value);
                CheckPattern(value);
                if (!string.IsNullOrEmpty(_surname))
                {
                    if (CheckLanguage(value) != CheckLanguage(_surname))
                    {
                        throw new FormatException("Язык имени " +
                            "и фамилии различается!");
                    }
                }

                _name = FixRegister(value);
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
                // TODO: дублирование
                CheckNullOrEmpty(value);
                CheckPattern(value);
                if (!(string.IsNullOrEmpty(_name))) 
                {
                    if (CheckLanguage(value) != CheckLanguage(_name))
                    {
                        throw new FormatException("Язык имени " +
                            "и фамилии различается!");
                    }
                }

                _surname = FixRegister(value);
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
                    throw new IndexOutOfRangeException("Возраст " +
                        $"должен быть в диапазоне " +
                        $"от {MinAge} до {MaxAge} лет!");
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
        /// Метод проверяет паттерн.
        /// </summary>
        /// <param name="value">Имя или фамилия пользователя.</param>
        public void CheckPattern(string value)
        {
            // + значит 1 и более
            // * значит 0 и более
            // Структура паттерна включает проверку
            // на совпадение языков в двойных именах и фамилиях  
            var latin = new Regex(@"^[A-z]+(-[A-z])?[A-z]*$");
            var cyrillic = new Regex(@"^[А-я]+(-[А-я])?[А-я]*$");

            //TODO: to boolean and
            if (!(cyrillic.IsMatch(value)) &
                    !(latin.IsMatch(value)))
            {
                throw new ArgumentException("Двойные имена и фамилии " +
                    "необходимо вводить данные в формате: " +
                    "\n*ruName-ruName* или *enName-enName*.");
            }
        }

        /// <summary>
        /// Метод возвращает язык ввода данных.
        /// </summary>
        /// <param name="value">Имя или фамилия пользователя.</param>
        /// <returns>Язык введённого значения. </returns>
        public string CheckLanguage(string value)
        {
            // + значит 1 и более
            // * значит 0 и более
            // Структура паттерна включает проверку
            // на совпадение языков в двойных именах и фамилиях  
            var latin = new Regex(@"^[A-z]+(-[A-z])?[A-z]*$");
            var cyrillic = new Regex(@"^[А-я]+(-[А-я])?[А-я]*$");

            if (cyrillic.IsMatch(value))
            {
                return Language.Russian.ToString();
            }
            else if (latin.IsMatch(value))
            {
                return Language.English.ToString();
            }
            // Исключение на язык, отличный от RU и EN
            else
            {
                throw new ArgumentException("Неизвестный язык!");
            }
            
        }

        /// <summary>
        /// Метод преобразование регистра.
        /// </summary>
        /// <param name="word">Имя или фамилия пользователя.</param>
        /// <returns></returns>
        private static string FixRegister(string word)
        {
            return CultureInfo.CurrentCulture.TextInfo.
                ToTitleCase(word.ToLower());
        }
    }


}