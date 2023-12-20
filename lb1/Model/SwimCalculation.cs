namespace Model
{
    /// <summary>
    /// Класс для плавания.
    /// </summary>
    public class SwimCalculation : Training
    {
        /// <summary>
        /// Расстояние в метрах.
        /// </summary>
        private double _distance;

        /// <summary>
        /// Стиль плавания.
        /// </summary>
        private string _style;

        /// <summary>
        /// Время плавания в часах.
        /// </summary>
        private double _duration;


        /// <summary>
        /// Конструктор класса-наследника (плавание).
        /// </summary>
        /// <param name="weight">Вес человека в килограммах.</param>
        /// <param name="metCoef">Коэффициент метаболизма.</param>
        /// <param name="duration">Продолжительность.</param>
        /// <param name="distance">Расстояние в метрах.</param>
        /// <param name="style">Стиль.</param>
        public SwimCalculation(double weight, double metCoef, double duration,
            double distance, string style)
            : base(weight, metCoef)
        {
            _distance = distance;
            _style = style;
            _duration = duration;
        }

        /// <summary>
        /// Метод расчёта затраченных калорий при плавании.
        /// </summary>
        /// <returns>Количество затраченных калорий при плавании.</returns>
        public override double CalculateCalories()
        {
            double metCoef = GetMetCoef(_style);
            return _weight * metCoef * _duration * _distance;
        }

        /// <summary>
        /// Метод получения коэффициента метаболизма
        /// в зависимости от стиля плавания.
        /// </summary>
        /// <param name="style"></param>
        /// <returns>Коэффициента метаболизма.</returns>
        private double GetMetCoef(string style)
        {
            if (style == "Кроль")
            {
                return 15;
            }
            else if (style == "Брасс")
            {
                return 12;
            }
            // Другие случаи
            else
            {
                return 0; // Значение по умолчанию
            }
        }

        /// <summary>
        /// Расчёт калорий для плавания.
        /// </summary>
        public SwimCalculation()
        {
        }



















        // /// <summary>
        // /// Минимальный возраст.
        // /// </summary>
        // private const int _minAge = 0;
        // 
        // /// <summary>
        // /// Максимальный возраст.
        // /// </summary>
        // private const int _maxAge = 17;
        // 
        // /// <summary>
        // /// Переопределение базового метода мин. возраста.
        // /// </summary>
        // protected override int MinAge { get; } = _minAge;
        // 
        // /// <summary>
        // /// Переопределение базового метода макс. возраста.
        // /// </summary>
        // protected override int MaxAge { get; } = _maxAge;
        // 
        // /// <summary>
        // /// Мать ребенка.
        // /// </summary>
        // private RunСalculation _mother;
        // 
        // /// <summary>
        // /// Отец ребенка.
        // /// </summary>
        // private RunСalculation _father;
        // 
        // /// <summary>
        // /// Учреждение, которое посещает ребенок.
        // /// </summary>
        // private string _institute;
        // 
        // /// <summary>
        // /// Метод для обращения к полям матери.
        // /// </summary>
        // public RunСalculation Mother
        // {
        //     get => _mother;
        // 
        //     set
        //     {
        //         CheckParentGender(value, Intensity.ModerateLoad);
        // 
        //         // Допускается пустой ввод
        //         _mother = value;
        //     }
        // }
        // 
        // /// <summary>
        // /// Метод для обращения к полям отца.
        // /// </summary>
        // public RunСalculation Father
        // {
        //     get => _father;
        // 
        //     set
        //     {
        //         CheckParentGender(value, Intensity.MaxLoad);
        // 
        //         // Допускается пустой ввод
        //         _father = value;
        //     }
        // }
        // 
        // /// <summary>
        // /// Метод для обращения к полям школы.
        // /// </summary>
        // public string Institute
        // {
        //     get => _institute;
        // 
        //     // Школа должна быть у всех детей
        //     set => _institute = CheckValue(value);
        // }
        // 
        // /// <summary>
        // /// Метод проверки корректности полов родителей.
        // /// </summary>
        // /// <param name="parent">Партнёр.</param>
        // /// <param name="gender">Пол.</param>
        // /// <exception cref="ArgumentException">Некорректный ввод.</exception>
        // private void CheckParentGender(RunСalculation parent, Intensity gender)
        // {
        //     if (parent != null && parent.Gender != gender)
        //     {
        //         throw new ArgumentException("Быть такого не может, " +
        //             "должно быть, Вы ошиблись при вводе!");
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
        // protected override int CheckAge(int age)
        // {
        //     // Передать значение переменной _age,
        //     // однако, прежде провести проверку:
        //     // значение входит в НЕправильный диапазон?
        //     return MinAge > age || age > MaxAge
        //             // Если да, то кинуть исключение
        //             ? throw new IndexOutOfRangeException("Возраст " +
        //                 $"должен быть в диапазоне " +
        //                 $"от {MinAge} до {MaxAge} лет!")
        //             // Если нет, то продолжить присваивание
        //             : age;
        // }
        // 
        // /// <summary>
        // /// Метод вывода информации о ребёнке.
        // /// </summary>
        // /// <returns>Информация о ребёнке.</returns>
        // public override string GetInfoBase()
        // {
        //     string instituteStatus = "";
        //     if (!string.IsNullOrEmpty(Institute))
        //     {
        //         if (Age >= 7)
        //         {
        //             instituteStatus = $"    Учебное заведение: {Institute}";
        //         }
        //         else if (Age < 7)
        //         {
        //             string group = "";
        //             switch (Age)
        //             {
        //                 case < 2:
        //                     group = "первая младшая группа";
        //                     break;
        //                 case <= 2 and <= 3:
        //                     group = "вторая младшая группа";
        //                     break;
        //                 case <= 4 and <= 5:
        //                     group = "средняя группа";
        //                     break;
        //                 case > 5 and <= 6:
        //                     group = "старшая группа";
        //                     break;
        //                 default:
        //                     break;
        //             }
        // 
        //             instituteStatus = $"    Учреждение дошкольного " +
        //                 $"образования \"{Institute}\" ({group})";
        //         }
        //     }
        // 
        //     // Информация о родителях
        //     string parents = "информация отсутствует";
        //     // Оба родителя имеются
        //     if (Mother != null && Father != null)
        //     {
        //         parents = $"мать - {Mother.Surname} {Mother.Name}, " +
        //         $"отец - {Father.Surname} {Father.Name}";
        //     }
        //     // Имеется хотя бы 1 родитель
        //     else if (Mother != null || Father != null)
        //     {
        //         // Имеется мать
        //         if (Mother != null && Father == null)
        //         {
        //             parents = $"мать - {Mother.Surname} {Mother.Name}, " +
        //                 $"воспитывающийся без отца";
        //         }
        //         // Имеется отец
        //         else if (Mother == null && Father != null)
        //         {
        //             parents = $"отец - {Father.Surname} {Father.Name}, " +
        //                 $"воспитывающийся без матери";
        //         }
        //     }
        //     // Родителей нет
        //     else if (Mother == null || Father == null)
        //     {
        //         parents = "воспитывается без родителей";
        //     }
        // 
        //     return $"{GetInfo()}" +
        //         $"{instituteStatus}, " +
        //         $"\n    Информация о родителях: {parents}\n";
        // }
        // 
        // /// <summary>
        // /// Конструктор для ребёнка.
        // /// </summary>
        // /// <param name="name">Имя ребёнка.</param>
        // /// <param name="surname">Фамилия ребёнка.</param>
        // /// <param name="age">Возраст ребёнка.</param>
        // /// <param name="gender">Пол ребёнка.</param>
        // /// <param name="mother">Мать ребёнка.</param>
        // /// <param name="father">Отец ребёнка.</param>
        // /// <param name="institute">Образовательное учреждение.</param>
        // public SwimCalculation(string name, string surname, int age, Intensity gender,
        //     RunСalculation mother, RunСalculation father, string institute)
        //     : base(name, surname, age, gender)
        // {
        //     Mother = mother;
        //     Father = father;
        //     Institute = institute;
        // }
        // 
        // /// <summary>
        // /// Метод генерирования детей.
        // /// </summary>
        // /// <returns>Ребенок.</returns>
        // public static SwimCalculation GetRandomPerson()
        // {
        //     string[] maleNames =
        //     {
        //         "Александр", "Владимир", "Григорий", "Максим",
        //         "Артем", "Егор", "Иван", "Илья"
        //     };
        // 
        //     string[] femaleNames =
        //     {
        //         "Светлана", "Татьяна","Ульяна", "Фаина",
        //         "Христина", "Цветана", "Эвелина", "Анастасия"
        //     };
        // 
        //     string[] surnames =
        //     {
        //         "Живаго",
        //         "Шапиро",
        //         "Грабчак",
        //         "Дей",
        //         "Штольберг"
        //     };
        // 
        //     string[] kindergartens = new string[]
        //     {
        //         "Радуга", "Солнышко","Весёлые карапузы","Ласточка",
        //         "Дружные малыши","Звёздочка","Улыбка","Мишутка",
        //         "Теремок","Сказка","Весёлый мир","Зайчонок",
        //         "Смешарики","Волшебный лес","Колобок","Спутничок"
        //     };
        // 
        //     string[] schools = new string[10];
        // 
        //     for (int i = 1; i <= schools.Length; i++)
        //     {
        //         schools[i - 1] = $"Школа №{i}";
        //     }
        // 
        //     var random = new Random();
        //     string name = string.Empty;
        //     var gender = (Intensity)random.Next(0, 2);
        //     switch (gender)
        //     {
        //         case Intensity.MaxLoad:
        //             name = maleNames[random.Next(maleNames.Length)];
        //             break;
        //         case Intensity.ModerateLoad:
        //             name = femaleNames[random.Next(femaleNames.Length)];
        //             break;
        //         case Intensity.NoLoad:
        //             break;
        //         default:
        //             break;
        //     }
        // 
        //     string surname = surnames[random.Next(surnames.Length)];
        //     int age = random.Next(_minAge, _maxAge);
        // 
        //     // Случайным образом выбирается школа
        //     string institute = schools[random.Next(schools.Length)];
        // 
        //     // Условимся, что дети идут в школу с 7 лет
        //     if (age < 7)
        //     {
        //         institute = kindergartens[random.Next(kindergartens.Length)];
        //     }
        // 
        //     RunСalculation mother = GetRandomParent(1);
        //     RunСalculation father = GetRandomParent(0);
        // 
        //     return new SwimCalculation(name, surname, age, gender,
        //                     mother, father, institute);
        // }
        // 
        // /// <summary>
        // /// Метод создания родителей для ребёнка.
        // /// </summary>
        // /// <param name="numberParent"> 0 - мальчик, 1 - девочка.</param>
        // /// <returns>Случайный родитель.</returns>
        // /// <exception cref="ArgumentException">Некорректный ввод.</exception>
        // private static RunСalculation GetRandomParent(int numberParent)
        // {
        //     var random = new Random();
        //     var parentStatus = random.Next(1, 3);
        // 
        //     // Если выпала 1, то партнёра нет
        //     if (parentStatus == 1)
        //     {
        //         return null;
        //     }
        // 
        //     // В ином случае будет партнёр
        //     else
        //     {
        //         switch (numberParent)
        //         {
        //             // Если был передан 0, то партнёр - мужчина
        //             case 0:
        //                 return (RunСalculation)RunСalculation.GetRandomPerson(Intensity.MaxLoad);
        // 
        //             // Если была передана 1, то партнёр - женщина
        //             case 1:
        //                 return (RunСalculation)RunСalculation.GetRandomPerson(Intensity.ModerateLoad);
        // 
        //             // Если передали неожидаемое значение
        //             default:
        //                 throw new ArgumentException
        //                     ("Введите, пожалуйста, число 1 или 2");
        //         }
        //     }
        // }
        // 
        // /// <summary>
        // /// Метод генерации успеваемости в школе.
        // /// </summary>
        // /// <returns>Успеваемость в школе.</returns>
        // public string GetSchoolProgress()
        // {
        //     string[] schoolProgress = { "\"даже лучше, чем у сына " +
        //             "маминой подруги\"", "отлично", "хорошо", "удовлетворительно" };
        //     Random random = new Random();
        //     return schoolProgress[random.Next(schoolProgress.Length)];
        // }
        // 
        // /// <summary>
        // /// Метод генерации карманных расходов
        // /// исходя из успеваемости.
        // /// </summary>
        // /// <returns>Карманные расходы.</returns>
        // public string GetPocketExpenses(string schoolProgress)
        // {
        //     int pocketExpenses = 0;
        //     Random random = new Random();
        //     switch (schoolProgress)
        //     {
        //         case "\"даже лучше, чем у сына " +
        //             "маминой подруги\"":
        //             pocketExpenses = random.Next(10, 21) * 100;
        //             break;
        //         case "отлично":
        //             pocketExpenses = random.Next(10, 16) * 100;
        //             break;
        //         case "хорошо":
        //             pocketExpenses = random.Next(5, 11) * 100;
        //             break;
        //         case "удовлетворительно":
        //             pocketExpenses = random.Next(1, 5) * 100;
        //             break;
        //         default:
        //             break;
        //     }
        //     return $"{pocketExpenses} рублей";
        // }
        // 
        // /// <summary>
        // /// Ребёнок.
        // /// </summary>
        // public SwimCalculation()
        // {
        // }
    }
}
