namespace Model
{
    /// <summary>
    /// Класс для расчёта калорий.
    /// </summary>
    public abstract class CalculationBase
    {
        public CalculationBase()
        {
        }

        /// <summary>
        /// Вес человека в килограммах.
        /// </summary>
        protected double _weight;

        /// <summary>
        /// Время тренировки в часах.
        /// </summary>
        protected double _duration;

        /// <summary>
        /// Конструктор базового класса.
        /// </summary>
        /// <param name="weight">Вес человека в килограммах.</param>
        /// <param name="duration">Время тренировки в часах.</param>
        public CalculationBase(double weight, double duration)
        {
            _weight = weight;
            _duration = duration;
        }

        /// <summary>
        /// Абстрактный метод расчета калорий.
        /// </summary>
        public abstract double CalculateCalories();
















        // /// <summary>
        // /// Конструктор для инициализации данных о пользователе.
        // /// </summary>
        // /// <param name="name">Имя.</param>
        // /// <param name="surname">Фамилия.</param>
        // /// <param name="age">Возраст.</param>
        // /// /// <param name="gender">Пол.</param>
        // public CalculationBase(string name,
        //               string surname,
        //               int age,
        //               Intensity gender)
        // {
        //     Name = name;
        //     Surname = surname;
        //     Age = age;
        //     Gender = gender;
        // }
        // 
        // /// <summary>
        // /// Имя пользователя.
        // /// </summary>
        // private string _name;
        // 
        // /// <summary>
        // /// Фамилия пользователя.
        // /// </summary>
        // private string _surname;
        // 
        // /// <summary>
        // /// Возраст пользователя.
        // /// </summary>
        // private int _age;
        // 
        // /// <summary>
        // /// Минимальный возраст для контроля некорректного ввода.
        // /// </summary>
        // protected abstract int MinAge { get; }
        // 
        // /// <summary>
        // /// Максимальный возраст для контроля некорректного ввода.
        // /// </summary>
        // protected abstract int MaxAge { get; }
        // 
        // /// <summary>
        // /// Вывод информации о пользователе.
        // /// </summary>
        // /// <returns>Информация о пользователе.</returns>
        // public virtual string GetInfo()
        // {
        //     var tmpGender = "мужской";
        // 
        //     if (Gender is Intensity.ModerateLoad)
        //     {
        //         tmpGender = "женский";
        //     }
        //     return $"Имя: {Name};\n" +
        //            $"    Фамилия: {Surname};\n" +
        //            $"    Возраст: {Age};\n" +
        //            $"    Пол: {tmpGender};\n";
        // }
        // 
        // /// <summary>
        // /// Базовый метод по выводу информации о человеке.
        // /// </summary>
        // public abstract string GetInfoBase();
        // 
        // /// <summary>
        // /// Метод проверки на пустой ввод.
        // /// </summary>
        // /// <param name="value">Проверяемое значение.</param>
        // /// <exception cref="ArgumentNullException">Исключение
        // /// по пустому вводу.</exception>
        // public void CheckNullOrEmpty(string value)
        // {
        //     if (string.IsNullOrEmpty(value))
        //     {
        //         throw new ArgumentNullException(value, "Ввод не может " +
        //             "быть пустым!");
        //     }
        // }
        // 
        // /// <summary>
        // /// Проверка имени.
        // /// </summary>
        // public string Name
        // {
        //     get
        //     {
        //         return _name;
        //     }
        // 
        //     set
        //     {
        //         _name = FullCheck(value, _surname);
        //     }
        // }
        // 
        // /// <summary>
        // /// Метод включает в себя проверку на регистр, 
        // /// совпадение языков и пустой ввод.
        // /// </summary>
        // /// <param name="value">Проверяемое значение.</param>
        // /// <returns>Проверенное значение имени или фамилии.</returns>
        // /// <exception cref="FormatException">Исключение 
        // /// по различию языков имени и фамилии.</exception>
        // public string FullCheck(string value, string nameOrSurname)
        // {
        //     CheckNullOrEmpty(value);
        //     CheckPattern(value);
        //     if (!string.IsNullOrEmpty(nameOrSurname))
        //     {
        //         if ((CheckLanguage(value) != CheckLanguage(nameOrSurname)))
        //         {
        //             throw new FormatException("Язык имени " +
        //                 "и фамилии различается!");
        //         }
        //     }
        // 
        //     return FixRegister(value);
        // }
        // 
        // /// <summary>
        // /// Проверка фамилии.
        // /// </summary>
        // public string Surname
        // {
        //     get
        //     {
        //         return _surname;
        //     }
        //     set
        //     {
        //         _surname = FullCheck(value, _name);
        //     }
        // }
        // 
        // /// <summary>
        // /// Проверка возраста.
        // /// </summary>
        // public int Age
        // {
        //     get
        //     {
        //         return _age;
        //     }
        //     set
        //     {
        //         _age = CheckAge(value);
        //     }
        // }
        // 
        // /// <summary>
        // /// Метод проверки возраста.
        // /// </summary>
        // /// <param name="age"></param>
        // /// <returns>Возраст.</returns>
        // /// <exception cref="IndexOutOfRangeException">Исключение
        // /// по нарушающему диапазон возрасту.</exception>
        // protected abstract int CheckAge(int age);
        // 
        // /// <summary>
        // /// Получение параметра пола.
        // /// </summary>
        // public Intensity Gender { get; set; }
        // 
        // /// <summary>
        // /// Метод проверяет паттерн.
        // /// </summary>
        // /// <param name="value">Имя или фамилия пользователя.</param>
        // public void CheckPattern(string value)
        // {
        //     // + значит 1 и более
        //     // * значит 0 и более
        //     // Структура паттерна включает проверку
        //     // на совпадение языков в двойных именах и фамилиях  
        //     var latin = new Regex(@"^[A-z]+(-[A-z])?[A-z]*$");
        //     var cyrillic = new Regex(@"^[А-я]+(-[А-я])?[А-я]*$");
        // 
        //     if (!(cyrillic.IsMatch(value)) &&
        //             !(latin.IsMatch(value)))
        //     {
        //         throw new ArgumentException("Двойные имена и фамилии " +
        //             "необходимо вводить данные в формате: " +
        //             "\n*ruName-ruName* или *enName-enName*.");
        //     }
        // }
        // 
        // /// <summary>
        // /// Персона.
        // /// </summary>
        // public CalculationBase()
        // {
        // }
        // 
        // /// <summary>
        // /// Метод возвращает язык ввода данных.
        // /// </summary>
        // /// <param name="value">Имя или фамилия пользователя.</param>
        // /// <returns>Язык введённого значения.</returns>
        // public string CheckLanguage(string value)
        // {
        //     // + значит 1 и более
        //     // * значит 0 и более
        //     // Структура паттерна включает проверку
        //     // на совпадение языков в двойных именах и фамилиях  
        //     var latin = new Regex(@"^[A-z]+(-[A-z])?[A-z]*$");
        //     var cyrillic = new Regex(@"^[А-я]+(-[А-я])?[А-я]*$");
        // 
        //     // ?: — тернарный условный оператор
        //     // Проверка: значение не соответствует кириллице
        //     return !cyrillic.IsMatch(value)
        //         // Если да, то проверка: соответствует ли латинице?
        //         ? latin.IsMatch(value)
        //             // Если да, что вернуть английский язык
        //             ? Language.English.ToString()
        //             // Если нет, то бросить исключение
        //             : throw new ArgumentException("Неизвестный язык!")
        //         // Проверка на "значение не соответствует кириллице"
        //         // Завершилась значением "false"
        //         // Т.е. значение не не на кириллице
        //         // Вернём русский язык
        //         : Language.Russian.ToString();
        // }
        // 
        // /// <summary>
        // /// Метод преобразование регистра.
        // /// </summary>
        // /// <param name="word">Имя или фамилия пользователя.</param>
        // /// <returns>Имя или фамилия с заглавной буквы.</returns>
        // private static string FixRegister(string word)
        // {
        //     return CultureInfo.CurrentCulture.TextInfo.
        //         ToTitleCase(word.ToLower());
        // }
        // 
        // /// <summary>
        // /// Проверка на пустой ввод.
        // /// </summary>
        // /// <param name="value"></param>
        // /// <returns>Непустое значение.</returns>
        // /// <exception cref="ArgumentException">Исключение
        // /// на пустой ввод.</exception>
        // protected string CheckValue(string value)
        // {
        //     return string.IsNullOrEmpty(value)
        //         ? throw new ArgumentException
        //             ("\nВвод не должен быть пустым.")
        //         : value;
        // }
    }
}
