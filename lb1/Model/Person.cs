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
        /// Минимальный возраст для контроля некорректного ввода.
        /// </summary>
        private const int _minAge = 0;

        /// <summary>
        /// Максимальный возраст для контроля некорректного ввода.
        /// </summary>
        private const int _maxAge = 200;

        /// <summary>
        /// Вывод информации о пользователе.
        /// </summary>
        /// <returns>Информация о пользователе.</returns>
        public string GetInfo()
        {
            return $"Имя: {_name}, " +
                $"Фамилия: {_surname}, " +
                $"\nВозраст: {_age}, " +
                $"Пол: {Gender}";
        }

        /// <summary>
        /// Метод для корректной работы Action`ов.
        /// </summary>
        public Person()
        {
        }

        /// <summary>
        /// Метод получения случайных персон.
        /// </summary>
        /// <returns>Пользователь с его параметрами.</returns>
        public static Person GetRandomPerson()
        {
            string[] maleNames =
            {
                "Андрей", "Виктор", "Илья", "Владислав",
                "Вячеслав", "Иван", "Алексей", "Александр"
            };

            string[] femaleNames =
            {
                "Виктория", "Евгения", "Екатерина", "Юлия",
                "Людмила", "Ольга", "Валентина", "Нюша"
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
            var tmpAge = random.Next(_minAge, _maxAge);

            return new Person(tmpName, tmpSurname, tmpAge, tmpGender);
        }

        /// <summary>
        /// Метод проверки на пустой ввод.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <exception cref="ArgumentNullException">Исключение по пустому вводу.</exception>
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
                _name = FullCheck(value, _surname);
            }
        }

        /// <summary>
        /// Метод включает в себя проверку на регистр, 
        /// совпадение языков и пустой ввод.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <returns>Проверенное значение имени или фамилии.</returns>
        /// <exception cref="FormatException">Исключение 
        /// по различию языков имени и фамилии.</exception>
        public string FullCheck(string value, string nameOrSurname)
        {
            CheckNullOrEmpty(value);
            CheckPattern(value);
            if (!string.IsNullOrEmpty(nameOrSurname))
            {
                if ((CheckLanguage(value) != CheckLanguage(nameOrSurname)))
                {
                    throw new FormatException("Язык имени " +
                        "и фамилии различается!");
                }
            }

            return FixRegister(value);
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
                _surname = FullCheck(value, _name);
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
                // Передать значение переменной _age,
                // однако, прежде провести проверку:
                // значение входит в НЕправильный диапазон?
                _age = _minAge >= value || value >= _maxAge
                    // Если да, то кинуть исключение
                    ? throw new IndexOutOfRangeException("Возраст " +
                        $"должен быть в диапазоне " +
                        $"от {_minAge} до {_maxAge} лет!")
                    // Если нет, то продолжить присваивание
                    : value;
            }
        }

        /// <summary>
        /// Получение параметра пола.
        /// </summary>
        public Gender Gender
        {
            get;
            set;
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

            if (!(cyrillic.IsMatch(value)) &&
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
        /// <returns>Язык введённого значения.</returns>
        public string CheckLanguage(string value)
        {
            // + значит 1 и более
            // * значит 0 и более
            // Структура паттерна включает проверку
            // на совпадение языков в двойных именах и фамилиях  
            var latin = new Regex(@"^[A-z]+(-[A-z])?[A-z]*$");
            var cyrillic = new Regex(@"^[А-я]+(-[А-я])?[А-я]*$");

            // ?: — тернарный условный оператор
            // Проверка: значение не соответствует кириллице
            return !cyrillic.IsMatch(value)
                // Если да, то проверка: соответствует ли латинице?
                ? latin.IsMatch(value)
                    // Если да, что вернуть английский язык
                    ? Language.English.ToString()
                    // Если нет, то бросить исключение
                    : throw new ArgumentException("Неизвестный язык!")
                // Проверка на "значение не соответствует кириллице"
                // Завершилась значением "false"
                // Т.е. значение не не на кириллице
                // Вернём русский язык
                : Language.Russian.ToString();
        }

        /// <summary>
        /// Метод преобразование регистра.
        /// </summary>
        /// <param name="word">Имя или фамилия пользователя.</param>
        /// <returns>Имя или фамилия с заглавной буквы.</returns>
        private static string FixRegister(string word)
        {
            return CultureInfo.CurrentCulture.TextInfo.
                ToTitleCase(word.ToLower());
        }
    }
}
