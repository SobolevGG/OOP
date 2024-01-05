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
        public virtual double Weight
        {
            get => _weight;

            set
            {
                CheckRange(value, 3, 500);
                _weight = value;
            }
        }

        /// <summary>
        /// Метод проверки допустимых значений.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <exception cref="Exception">Исключение
        /// по некорректному значению.</exception>
        public void CheckRange(double value, double min, double max)
        {
            CheckNullEmpty(value.ToString());
            if (value < min || value > max)
            {
                throw new Exception("вес " +
                    $"должен лежать в диапазоне от {min} до {max} кг!");
            }
        }

        /// <summary>
        /// Метод проверки пустого ввода.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <exception cref="Exception">Исключение
        /// на пустой ввод.</exception>
        public void CheckNullEmpty(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("ввод не может " +
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
