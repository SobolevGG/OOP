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
        /// <param name="name">//TODO: XML</param>
        /// <param name="surname"></param>
        /// <param name="age"></param>
        public Person(string name, string surname, int age, Gender gender)
        {
            //TODO: to properties
            _name = name;
            _surname = surname;
            _age = age;
            _gender = gender;
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
                $"Имя: {this._name}\n" +
                $"Фамилия: {this._surname}\n" +
                $"Возраст: {this._age}";
        }

        /// <summary>
        /// Создание путого экземпляра класса.
        /// </summary>
        public Person()
        { }
        
        /// <summary>
        /// Метод получения случайных персон.
        /// </summary>
        /// <returns></returns>
        public static Person GetRandomPerson()
        {
            string[] maleNames =
            {
                "Андрей", "Виктор", "Илья", "Владислав", "Евгений",
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
                //TODO: переписать
                _ = CheckLanguage(value);
                _name = FixRegister(value);

                if (_surname != null)
                {
                    CheckSimilarName();
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
                //TODO: переписать
                _ = CheckLanguage(value);
                _surname = FixRegister(value);

                if (_surname != null)
                {
                    CheckSimilarName();
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
        /// Проверка соответствия имени шаблону.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string CheckLanguage(string value)
        {
            // + значит 1 и более
            // * значит 0 и более
            var latin = new Regex(@"^[A-z]+([-][A-z])*$");
            var cyrillic = new Regex(@"^[А-я]+([-][А-я])*$");

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
                    throw new ArgumentException("Доступные языки: "
                        +"английский и русский. Имя и фамилия " +
                        "должны быть введены на одном языке!");
                }
 
            }

            return Language.Unknown.ToString();
        }

        /// <summary>
        /// Проверка на совпадение языка имени и фамилии.
        /// </summary>
        /// <exception cref="FormatException"></exception>
        private void CheckSimilarName()
        {
            if ((!string.IsNullOrEmpty(Name))
                && (!string.IsNullOrEmpty(Surname)))
            {
                var nameLanguage = CheckLanguage(Name);
                var surnameLanguage = CheckLanguage(Surname);

                if (nameLanguage != surnameLanguage)
                {
                    throw new FormatException("Язык имени " +
                        "и фамилии различается!");
                }
            }
        }

        /// <summary>
        /// Специальный метод преобразования к стринговому формату.
        /// </summary>
        /// <returns></returns>
        public string ToStringMy()
        {
            return $"Полное имя: {Name} {Surname}, возраст: {Age}, пол: {Gender};";
        }

        /// <summary>
        /// Метод преобразование регистра.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private static string FixRegister(string word)
        {
            return CultureInfo.CurrentCulture.TextInfo.
                ToTitleCase(word.ToLower());
        }
    }


}