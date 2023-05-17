using static System.Net.Mime.MediaTypeNames;

namespace Model
{

    internal class Adult : PersonBase
    {
        /// <summary>
        /// Passport ID.
        /// </summary>
        private int _passportID;

        /// <summary>
        /// Name of company.
        /// </summary>
        private string _company;

        /// <summary>
        /// Partner.
        /// </summary>
        private Adult _partner;

        /// <summary>
        /// Minimum age.
        /// </summary>
        private const int _minAge = 18;

        /// <summary>
        /// Maximum age.
        /// </summary>
        private const int _maxAge = 150;

        /// <summary>
        /// Minimum age.
        /// </summary>
        protected override int MinAge { get; } = _minAge;

        /// <summary>
        /// Maximum age.
        /// </summary>
        protected override int MaxAge { get; } = _maxAge;

        /// <summary>
        /// Minimum value of passport ID.
        /// </summary>
        private const int _minPassportID = 1000;

        /// <summary>
        /// Maximum value of passport ID.
        /// </summary>
        private const int _maxPassportID = 9999;

        /// <summary>
        /// passport ID.
        /// </summary>
        public int PassportID
        {
            get => _passportID;

            set => _passportID = CheckPassportID(value);
        }

        /// <summary>
        /// Вызов конструктора для наследующего Adult от класса PersonBase. 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        public Adult(string name, string surname, int age, Gender gender)
            : base(name, surname, age, gender)
        {
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
