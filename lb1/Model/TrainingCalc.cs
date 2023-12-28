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
        /// Публичный метод для доступа к весу человека.
        /// </summary>
        public virtual double Weight
        {
            get => _weight;

            set
            {
                CheckWeight(value);
                _weight = value;
            }
        }

        /// <summary>
        /// Метод проверки веса человека.
        /// </summary>
        /// <param name="value">Вес человека.</param>
        /// <exception cref="Exception">Исключение
        /// по некорректному значению веса.</exception>
        public virtual void CheckWeight(double value)
        {
            CheckNullEmpty(value.ToString());
            if (value < 3 || value > 500)
            {
                throw new Exception("вес " +
                    "должен лежать в диапазоне от 3 до 500 кг!");
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
    }
}
