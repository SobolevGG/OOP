using System.Globalization;
using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Класс для пользователя.
    /// </summary>
    public abstract class PersonBase
    {
        /// <summary>
        /// Конструктор для инициализации данных о пользователе.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="surname">Фамилия.</param>
        /// <param name="age">Возраст.</param>
        /// /// <param name="gender">Пол.</param>
        public PersonBase(string name,
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
        protected abstract int MinAge { get; }

        /// <summary>
        /// Максимальный возраст для контроля некорректного ввода.
        /// </summary>
        protected abstract int MaxAge { get; }

        /// <summary>
        /// Вывод информации о пользователе.
        /// </summary>
        /// <returns>Информация о пользователе.</returns>
        public string GetInfo()
        {
            return $"Информация о пользователе:\n" +
                $"Имя: {_name}, " +
                $"Фамилия: {_surname}, " +
                $"\nВозраст: {_age}, " +
                $"Пол: {Gender}";
        }

        /// <summary>
        /// Базовый метод по выводу информации о человеке.
        /// </summary>
        public abstract string GetInfoBase();

        /// <summary>
        /// Метод для корректной работы Action`ов.
        /// </summary>
        public PersonBase()
        {
        }

        /// <summary>
        /// Метод проверки на пустой ввод.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <exception cref="ArgumentNullException">Исключение
        /// по пустому вводу.</exception>
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
                _age = CheckAge(value);
            }
        }

        /// <summary>
        /// Метод проверки возраста.
        /// </summary>
        /// <param name="age"></param>
        /// <returns>Возраст.</returns>
        /// <exception cref="IndexOutOfRangeException">Исключение
        /// по нарушающему диапазон возрасту.</exception>
        protected virtual int CheckAge(int age)
        {
            // Передать значение переменной _age,
            // однако, прежде провести проверку:
            // значение входит в НЕправильный диапазон?
            return MinAge >= age || age >= MaxAge
                    // Если да, то кинуть исключение
                    ? throw new IndexOutOfRangeException("Возраст " +
                        $"должен быть в диапазоне " +
                        $"от {MinAge} до {MaxAge} лет!")
                    // Если нет, то продолжить присваивание
                    : age;
        }

        // TODO(+): to autoproperty
        /// <summary>
        /// Получение параметра пола.
        /// </summary>
        public Gender Gender
        {
            get => _gender;
            set => _gender = value;
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
