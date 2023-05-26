namespace Model
{
    /// <summary>
    /// Класс для взрослого пользователя.
    /// </summary>
    internal class Adult : PersonBase
    {
        /// <summary>
        /// Серия и номер паспорта.
        /// </summary>
        private long _pasSeriesAndNumber;

        /// <summary>
        /// Место работы.
        /// </summary>
        private string _placeOfWork;

        /// <summary>
        /// Партнёр (муж/жена).
        /// </summary>
        private Adult _partner;

        /// <summary>
        /// Минимальный возраст взрослого.
        /// </summary>
        private const int _minAge = 18;

        /// <summary>
        /// Максимальный возраст взрослого.
        /// </summary>
        private const int _maxAge = 150;

        /// <summary>
        /// Минимальный возраст.
        /// </summary>
        protected override int MinAge { get; } = _minAge;

        /// <summary>
        /// Максимальный возраст.
        /// </summary>
        protected override int MaxAge { get; } = _maxAge;

        /// <summary>
        /// Минимальные серия и номер паспорта.
        /// </summary>
        private const long _fromSeriesAndNumber = 1000000000;

        /// <summary>
        /// Максимальные серия и номер паспорта.
        /// </summary>
        private const long _toSeriesAndNumber = 9999999999;

        /// <summary>
        /// Серия и номер паспорта.
        /// </summary>
        public long PasSeriesAndNumber
        {
            get => _pasSeriesAndNumber;

            set => _pasSeriesAndNumber = CheckPassportID(value);
        }

        /// <summary>
        /// Место работы.
        /// </summary>
        public string PlaceOfWork
        {
            get => _placeOfWork;

            set => _placeOfWork = CheckValue(value);
        }

        /// <summary>
        /// Партнёр.
        /// </summary>
        public Adult Partner
        {
            get => _partner;

            set
            {
                CheckPartnerGender(value);
                _partner = value;
            }
        }

        /// <summary>
        /// Метод информирования по взрослому.
        /// </summary>
        /// <returns>Information.</returns>
        public override string GetInfoBase()
        {
            string marriegeStatus = "Свободный человек";

            if (Partner != null)
            {
                marriegeStatus = $"Состоит в браке " +
                    $"с замечательным человеком по имени " +
                    $"{Partner.Surname} {Partner.Name}";
            }

            string job = "Фрилансер (по факту безработный)";

            if (!string.IsNullOrEmpty(PlaceOfWork))
            {
                job = $"Место работы: {PlaceOfWork}";
            }

            return $"{GetInfo()}" +
                    $"\n{marriegeStatus},\n{job}.";
        }

        /// <summary>
        /// Вызов конструктора для наследующего Adult от класса PersonBase. 
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="surname">Фамилия.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="pasSeriesAndNumber">Серия и номер паспорта.</param>
        /// <param name="placeOfWork">Место работы.</param>
        /// <param name="partner">Паптнёр.</param>
        public Adult(string name, string surname, int age, Gender gender,
            long pasSeriesAndNumber, string placeOfWork, Adult partner)
            : base(name, surname, age, gender)
        {
            PasSeriesAndNumber = pasSeriesAndNumber;
            PlaceOfWork = placeOfWork;
            Partner = partner;
        }

        /// <summary>
        /// Метод получения случайных персон.
        /// </summary>
        /// <returns>Пользователь с его параметрами.</returns>
        public static PersonBase GetRandomPerson()
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

            string[] placeOfWork = new string[]
            {
                "Эльдорадо", "М.Видео", "Ситилинк",
                "Пятёрочка", "Магнит", "Лента",
                "Чибис", "Абрикос", "Мария Ра"
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

            long pasSeriesAndNumber = random.NextInt64(_fromSeriesAndNumber, _toSeriesAndNumber);
            string job = placeOfWork[random.Next(placeOfWork.Length)];

            Adult partner = null;
            int marriegeStatus = random.Next(1, 3);
            if (marriegeStatus == 1)
            {
                partner = new Adult();
                if (tmpGender == Gender.Male)
                {
                    partner.Gender = Gender.Female;
                    partner.Name = femaleNames
                        [random.Next(femaleNames.Length)];

                }
                else
                {
                    partner.Gender = Gender.Male;
                    partner.Name = maleNames
                        [random.Next(maleNames.Length)];
                }

                partner.Surname = surnames
                    [random.Next(surnames.Length)];
            }

            return new Adult(tmpName, tmpSurname, tmpAge, tmpGender,
                pasSeriesAndNumber, job, partner);
        }

        /// <summary>
        /// Метод проверки возраста.
        /// </summary>
        /// <param name="age"></param>
        /// <returns>Возраст.</returns>
        /// <exception cref="IndexOutOfRangeException">Исключение
        /// по нарушающему диапазон возрасту.</exception>
        protected override int CheckAge(int age)
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

        /// <summary>
        /// Проврека паспортных данных.
        /// </summary>
        /// <param name="PasSeriesAndNumber">Passport ID.</param>
        /// <returns>Correct passport ID.</returns>
        /// <exception cref="IndexOutOfRangeException">Incorrect.</exception>
        private long CheckPassportID(long PasSeriesAndNumber)
        {
            if (PasSeriesAndNumber < _fromSeriesAndNumber || PasSeriesAndNumber > _toSeriesAndNumber)
            {
                throw new IndexOutOfRangeException
                    ($"\nВ паспортных данных " +
                    $"должно быть {_toSeriesAndNumber.ToString().Length}" +
                    $"символов");
            }
            else
            {
                return PasSeriesAndNumber;
            }
        }

        /// <summary>
        /// Проверка пола партнёра.
        /// </summary>
        /// <param name="partner">Partner.</param>
        /// <exception cref="ArgumentException">Incorrect input.</exception>
        private void CheckPartnerGender(Adult partner)
        {
            if (partner != null && partner.Gender == Gender)
            {
                throw new ArgumentException
                    ("Кажется");
            }
        }

        /// <summary>
        /// Special method for adult.
        /// </summary>
        /// <returns>Name of tempSalary.</returns>
        public string GetSalary()
        {
            string[] salary = new string[]
            {
                "100.000 долларов", "20.000 рублей", "Спасибо"
            };
            var random = new Random();
            string tempSalary = salary[random.Next(salary.Length)];
            return tempSalary;
        }

        /// <summary>
        /// Взрослый человек.
        /// </summary>
        public Adult()
        {
        }
    }
}
