using System.ComponentModel;
using System.Xml.Serialization;

/// <summary>
/// Пространство имён Model.
/// </summary>
namespace Model
{
    /// <summary>
    /// Класс для расчёта калорий.
    /// </summary>
    [XmlInclude(typeof(PressCalc))]
    [XmlInclude(typeof(RunCalc))]
    [XmlInclude(typeof(SwimCalc))]
    public abstract class TrainingCalc
    {
        /// <summary>
        /// Тип тренировки.
        /// </summary>
        [DisplayName("Тип тренировки")]
        public virtual string TrainingType { get; }

        /// <summary>
        /// Абстрактный метод расчета калорий.
        /// </summary>
        public abstract double CalculateCalories { get; }

        /// <summary>
        /// Программа тренировки для расчёта калорий.
        /// </summary>
        [DisplayName("Программа тренировки")]
        public virtual string Params { get; }

        /// <summary>
        /// Метод получения округлённых калорий.
        /// </summary>
        [DisplayName("Калории, ккал")]
        public double RoundCalories => Math.Round(CalculateCalories);

        /// <summary>
        /// Вес в килограммах.
        /// </summary>
        protected double _weight;

        /// <summary>
        /// Публичный метод для доступа к весу.
        /// </summary>
        public double Weight
        {
            get => _weight;

            set
            {
                if (!CheckRangeNew(value, MinWeight, MaxWeight))
                {
                    throw new Exception("вес " +
                    $"должен лежать в диапазоне от " +
                    $"{MinWeight} до {MaxWeight} кг!");
                }
                _weight = value;
            }
        }

        /// <summary>
        /// Максимальный вес в 500 кг.
        /// </summary>
        private const int _maxWeight = 500;

        /// <summary>
        /// Метод для обращения к приватному полю _maxWeight.
        /// </summary>
        protected int MaxWeight { get; } = _maxWeight;

        /// <summary>
        /// Минимальный вес в 3 кг.
        /// </summary>
        private const int _minWeight = 3;

        /// <summary>
        /// Метод для обращения к приватному полю _minWeight.
        /// </summary>
        protected int MinWeight { get; } = _minWeight;

        /// <summary>
        /// Метод проверки числа на допустимый диапазон.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <param name="min">Минимальное значение.</param>
        /// <param name="max">Максимальное значение.</param>
        /// <returns>Логическое значение: true - значение не нарушает
        /// допустимый диапазон, false - нарушает.</returns>
        public bool CheckRangeNew(double value,
                                  double min,
                                  double max)
        {
            CheckNullEmpty(value.ToString());
            return value >= min && value <= max;
        }

        /// <summary>
        /// Метод проверки пустого значения.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <exception cref="Exception">Исключение
        /// на пустое значение.</exception>
        public void CheckNullEmpty(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("значение не может " +
                    "быть пустым!");
            }
        }

        /// <summary>
        /// Метод замены точки на запятую.
        /// </summary>
        /// <returns>Скорректированное значение.</returns>
        public static double CheckInput()
        {
            string tmpValue = Console.ReadLine().Replace(".", ",");

            return !double.TryParse(tmpValue,
                out double checkedValue)
                ? throw new Exception("введено " +
                "нечисловое значение!")
                : checkedValue;
        }
    }
}
