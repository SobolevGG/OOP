namespace Model
{
    /// <summary>
    /// Класс для бега.
    /// </summary>
    public class RunCalc : TrainingCalc
    {
        /// <summary>
        /// Расстояние в километрах.
        /// </summary>
        private double _distance;

        /// <summary>
        /// Проверка пробегаемого расстояния.
        /// </summary>
        public double Distance
        {
            get => _distance;

            set
            {
                CheckDistance(value);
                _distance = value;
            }
        }

        /// <summary>
        /// Метод проверки расстояния для плавания.
        /// </summary>
        /// <param name="value">Расстояние в километрах.</param>
        /// <exception cref="ArgumentException">Исключение
        /// по некорректному значению расстояния.</exception>
        public void CheckDistance(double value)
        {
            CheckNullEmpty(value.ToString());

            if (value < 1 || value > 300)
            {
                throw new ArgumentException(value.ToString(),
                    "Расстояние должно соответствовать диапазону " +
                    "от 1 до 600 км!");
            }
        }




        /// <summary>
        /// Интенсивность бега.
        /// </summary>
        private Intensity _intensity;

        /// <summary>
        /// Получение параметра интенсивности.
        /// </summary>
        public Intensity Intensity { get; set; }

        /// <summary>
        /// Получение параметра дистанции.
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// Конструктор класса-наследника (бег).
        /// </summary>
        /// <param name="weight">Вес человека в килограммах.</param>
        /// <param name="metCoef">Коэффициент метаболизма.</param>
        /// <param name="distance">Расстояние.</param>
        /// <param name="intensity">Интенсивность.</param>
        public RunCalc(double weight, double metCoef, double distance, Intensity intensity)
            : base(weight, metCoef)
        {
            Distance = distance;
            Intensity = intensity;
        }

        /// <summary>
        /// Метод расчёта затраченных калорий при беге.
        /// </summary>
        /// <returns>Количество затраченных калорий при беге.</returns>
        public override double CalculateCalories()
        {
            double metCoef = CalcMetCoef();
            return Weight * metCoef * Distance;
        }

        /// <summary>
        /// Метод получения коэффициента метаболизма
        /// в зависимости от интенсивности бега.
        /// </summary>
        /// <param name="intensity"></param>
        /// <returns>Коэффициент метаболизма.</returns>
        public override double CalcMetCoef()
        {
            double metCoef = 0;

            switch (Intensity)
            {
                case Intensity.MaxLoad:
                    metCoef = 0.04;
                    break;
                case Intensity.ModerateLoad:
                    metCoef = 0.035;
                    break;
                case Intensity.NoLoad:
                    metCoef = 0.02;
                    break;
                default:
                    break;
            }
            return (double)metCoef;
        }

            return (0.025 + ((0.035 - 0.025) * (speed - 4) / (8 - 4)));
        }

        // /// <summary>
        // /// Серия и номер паспорта.
        // /// </summary>
        // private long _pasSeriesAndNumber;
        // 
        // /// <summary>
        // /// Место работы.
        // /// </summary>
        // private string _placeOfWork;
        // 
        // /// <summary>
        // /// Партнёр (муж/жена).
        // /// </summary>
        // private RunСalculation _partner;
        // 
        // /// <summary>
        // /// Минимальный возраст взрослого.
        // /// </summary>
        // private const int _minAge = 18;
        // 
        // /// <summary>
        // /// Максимальный возраст взрослого.
        // /// </summary>
        // private const int _maxAge = 150;
        // 
        // /// <summary>
        // /// Минимальный возраст.
        // /// </summary>
        // protected override int MinAge { get; } = _minAge;
        // 
        // /// <summary>
        // /// Максимальный возраст.
        // /// </summary>
        // protected override int MaxAge { get; } = _maxAge;
        // 
        // /// <summary>
        // /// Минимальные серия и номер паспорта.
        // /// </summary>
        // private const long _fromSeriesAndNumber = 1000000000;
        // 
        // /// <summary>
        // /// Максимальные серия и номер паспорта.
        // /// </summary>
        // private const long _toSeriesAndNumber = 9999999999;
        // 
        // /// <summary>
        // /// Серия и номер паспорта.
        // /// </summary>
        // public long PasSeriesAndNumber
        // {
        //     get => _pasSeriesAndNumber;
        // 
        //     set => _pasSeriesAndNumber = CheckPassport(value);
        // }
        // 
        // /// <summary>
        // /// Проврека паспортных данных.
        // /// </summary>
        // /// <param name="PasSeriesAndNumber">Паспортные данные.</param>
        // /// <returns>Корректные паспортные данные.</returns>
        // /// <exception cref="IndexOutOfRangeException">Некорректный
        // /// ввод паспортных данных.</exception>
        // private long CheckPassport(long pasSeriesAndNumber)
        // {
        //     return pasSeriesAndNumber < _fromSeriesAndNumber || pasSeriesAndNumber > _toSeriesAndNumber
        // 
        //         // Вызов исключения при удовлетворении условия выше
        //         ? throw new IndexOutOfRangeException
        //             ($"\nВ паспортных данных " +
        //             $"должно быть {_toSeriesAndNumber.ToString().Length}" +
        //             $"символов")
        //         // Сохранить паспортные данные
        //         : pasSeriesAndNumber;
        // }
        // 
        // /// <summary>
        // /// Место работы.
        // /// </summary>
        // public string PlaceOfWork
        // {
        //     get => _placeOfWork;
        // 
        //     // Да, по условиям задачи человек может быть безработным
        //     set => _placeOfWork = value;
        // }
        // 
        // /// <summary>
        // /// Партнёр.
        // /// </summary>
        // public RunСalculation Partner
        // {
        //     get => _partner;
        // 
        //     // По условиям задачи, у человека может и не быть партнёра
        //     set
        //     {
        //         CheckPartnerGender(value);
        //         _partner = value;
        //     }
        // }
        // 
        // /// <summary>
        // /// Проверка пола партнёра.
        // /// </summary>
        // /// <param name="partner">Партнёр.</param>
        // /// <exception cref="ArgumentException">Некорректный ввод.</exception>
        // private void CheckPartnerGender(RunСalculation partner)
        // {
        //     if (partner != null && partner.Gender == Gender)
        //     {
        //         throw new ArgumentException
        //             ("Кажется, что-то не так с вашим партнёром :D");
        //     }
        // }
        // 
        // /// <summary>
        // /// Метод информирования по взрослому.
        // /// </summary>
        // /// <returns>Information.</returns>
        // public override string GetInfoBase()
        // {
        //     string marriegeStatus = "не установлено";
        // 
        //     if (Partner == null)
        //     {
        //         if (Gender is Intensity.Sprinting)
        //         {
        //             marriegeStatus = "не женат";
        //         }
        //         else if (Gender is Intensity.ModerateRunning)
        //         {
        //             marriegeStatus = "не замужем";
        //         }
        //     }
        //     else if (Partner != null)
        //     {
        //         marriegeStatus = $"состоит в браке " +
        //             $"с {Partner.Surname} {Partner.Name}";
        //     }
        // 
        //     // Статус по умолчанию
        //     string job = "безработный";
        // 
        //     // Проверяем, есть ли работа у персоны
        //     if (!string.IsNullOrEmpty(PlaceOfWork))
        //     {
        //         job = $"{PlaceOfWork}";
        //     }
        // 
        //     string seriesAndNumber = PasSeriesAndNumber.ToString();
        //     string series = seriesAndNumber.Substring(0, 4);
        //     string number = seriesAndNumber.Substring(4);
        // 
        //     return $"{GetInfo()}" +
        //         $"    Семейное положение: {marriegeStatus};" +
        //         $"\n    Место работы: {job};" +
        //         $"\n    Паспортные данные: серия - {series}, номер - {number}.\n";
        // }
        // 
        // /// <summary>
        // /// Вызов конструктора для наследующего Adult от класса PersonBase. 
        // /// </summary>
        // /// <param name="name">Имя.</param>
        // /// <param name="surname">Фамилия.</param>
        // /// <param name="age">Возраст.</param>
        // /// <param name="gender">Пол.</param>
        // /// <param name="pasSeriesAndNumber">Серия и номер паспорта.</param>
        // /// <param name="placeOfWork">Место работы.</param>
        // /// <param name="partner">Партнёр.</param>
        // public RunСalculation(string name, string surname, int age, Intensity gender,
        //     long pasSeriesAndNumber, string placeOfWork, RunСalculation partner)
        //     : base(name, surname, age, gender)
        // {
        //     PasSeriesAndNumber = pasSeriesAndNumber;
        //     PlaceOfWork = placeOfWork;
        //     Partner = partner;
        // }
        // 
        // /// <summary>
        // /// Метод получения случайных персон.
        // /// </summary>
        // /// <returns>Взрослый человек.</returns>
        // public static CalculationBase GetRandomPerson(Intensity gender = Intensity.LightJogging)
        // {
        //     string[] maleNames =
        //     {
        //         "Борис", "Дмитрий", "Жан", "Игорь",
        //         "Леонид","Николай", "Павел", "Сергей"
        //     };
        // 
        //     string[] femaleNames =
        //     {
        //         "Алиса", "Валентина", "Елена", "Зоя",
        //         "Ксения", "Мария", "Ольга", "Рита"
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
        //     string[] placeOfWork = new string[]
        //     {
        //         "Газпром", "Роснефть", "Сбербанк", "Лукойл",
        //         "Транснефть", "Россети", "Ростелеком", "Магнит",
        //         "Яндекс", "Газпромбанк", "МТС", "Норильский никель",
        //         "Альфа-Банк", "Русал", "Лента"
        //     };
        // 
        //     var random = new Random();
        //     string name = string.Empty;
        // 
        //     if (gender == Intensity.LightJogging)
        //     {
        //         var tmpNumber = random.Next(1, 3);
        //         gender = tmpNumber == 1
        //             ? Intensity.Sprinting
        //             : Intensity.ModerateRunning;
        //     }
        // 
        //     switch (gender)
        //     {
        //         case Intensity.Sprinting:
        //             name = maleNames[random.Next(maleNames.Length)];
        //             break;
        //         case Intensity.ModerateRunning:
        //             name = femaleNames[random.Next(femaleNames.Length)];
        //             break;
        //         case Intensity.LightJogging:
        //             break;
        //         default:
        //             break;
        //     }
        // 
        //     // Генерируем случайное число, но не более длины списка
        //     // Обращаемся в массиве к элементу по индексу
        //     var surname = surnames[random.Next(surnames.Length)];
        // 
        //     // Генерируем случайное число в диапазоне
        //     var age = random.Next(_minAge, _maxAge);
        // 
        //     // Генерируем число, соответвтующее паспортным данным
        //     long pasSeriesAndNumber = random.NextInt64(_fromSeriesAndNumber, _toSeriesAndNumber);
        // 
        //     // Генерируем случайное число, но не более длины списка
        //     // Обращаемся в массиве к элементу по индексу 
        //     string job = placeOfWork[random.Next(placeOfWork.Length)];
        // 
        //     // Определяем переменную для партнёра
        //     RunСalculation partner = null;
        // 
        //     // Случайным образом выбираем его статус
        //     int marriegeStatus = random.Next(1, 3);
        // 
        //     // Если выпала цифра 1, то партнёр имеется
        //     if (marriegeStatus == 1)
        //     {
        //         // Определяем переменную для партнёра
        //         partner = new RunСalculation();
        // 
        //         // Если сам человек мужчина
        //         if (gender == Intensity.Sprinting)
        //         {
        //             // Гендер его партнёра - женский
        //             partner.Gender = Intensity.ModerateRunning;
        // 
        //             // И имя тоже подберём из спика женских имён
        //             partner.Name = femaleNames
        //                 [random.Next(femaleNames.Length)];
        // 
        //         }
        // 
        //         // Если сам человек женщина
        //         else
        //         {
        //             // Гендер его партнёра - мужской
        //             partner.Gender = Intensity.Sprinting;
        // 
        //             // И имя тоже подберём из спика мужских имён
        //             partner.Name = maleNames
        //                 [random.Next(maleNames.Length)];
        //         }
        // 
        //         // Фамилия, как и концепция ООП, несклоняемая
        //         partner.Surname = surnames
        //             [random.Next(surnames.Length)];
        //     }
        // 
        //     return new RunСalculation(name, surname, age, gender,
        //         pasSeriesAndNumber, job, partner);
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
        // /// Специальный метод для взрослых.
        // /// </summary>
        // /// <returns>Зарплата.</returns>
        // public string GetSalary()
        // {
        //     string[] salary = new string[]
        //     {
        //         "100.000 долларов",
        //         "20.000 рублей",
        //         "2.000 евро",
        //         "6.000 датских крон",
        //         "90.000 сербских динар",
        //         "работает за спасибо :D"
        //     };
        //     var random = new Random();
        //     return salary[random.Next(salary.Length)];
        // }
        // 
        // /// <summary>
        // /// Взрослый человек.
        // /// </summary>
        // public RunСalculation()
        // {
        // }
    }
}
