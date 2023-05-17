using System.Reflection;
using System.Xml.Linq;

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
        private int _pasSeriesAndNumber;

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
        public int PasSeriesAndNumber
        {
            get => _pasSeriesAndNumber;

            set => _pasSeriesAndNumber = CheckPassportID(value);
        }

        /// <summary>
        /// Место работы.
        /// </summary>
        public string PlaceOfWork
        {
            get => _placeOfWorky;

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
        public override string GetInfo()
        {
            string marriegeStatus = "Single";

            if (Partner != null)
            {
                marriegeStatus = $"Married to {Partner.GetNameSurname()}";
            }

            string job = "An unemployed pirate";

            if (!string.IsNullOrEmpty(PlaceOfWork))
            {
                job = $"Employed in {PlaceOfWork}";
            }

            return $"{GetPersonInfo()}" +
                    $"\n{marriegeStatus},\n{job}";
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
            int pasSeriesAndNumber, string placeOfWork, Adult partner)
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

            return new Adult(name, surname, age, gender,
                pasSeriesAndNumber, placeOfWork, partner);
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
            return _minAge >= age || age >= _maxAge
                    // Если да, то кинуть исключение
                    ? throw new IndexOutOfRangeException("Возраст " +
                        $"должен быть в диапазоне " +
                        $"от {_minAge} до {_maxAge} лет!")
                    // Если нет, то продолжить присваивание
                    : age;
        }
    }
}
