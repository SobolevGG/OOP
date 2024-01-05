using System.ComponentModel;

/// <summary>
/// Пространство имён Model.
/// </summary>
namespace Model
{
    /// <summary>
    /// Класс для жима штанги.
    /// </summary>
    public class PressCalc : TrainingCalc
    {
        /// <summary>
        /// Тип тренировки - жим штанги.
        /// </summary>
        public override string TrainingType => "Жим штанги";

        /// <summary>
        /// Программа тренировки для расчёта калорий.
        /// </summary>
        [DisplayName("Программа тренировки")]
        public override string Params
        {
            get
            {
                return $"Вес с учётом грифа, кг: {WeightForPress};\n " +
                    $"Количество повторов: {Repetitions}";
            }
        }

        /// <summary>
        /// Вес штанги (с учётом грифа) в килограммах.
        /// </summary>
        protected double _weightForPress;

        /// <summary>
        /// Публичный метод для доступа к поднимаемому весу.
        /// </summary>
        public double WeightForPress
        {
            get => _weightForPress;

            set
            {
                if (!CheckRangeNew(value, MinPressWeight, MaxPressWeight))
                {
                    throw new Exception("вес " +
                    $"должен лежать в диапазоне от " +
                    $"{MinPressWeight} до {MaxPressWeight} кг!");
                }
                _weightForPress = value;
            }
        }

        /// <summary>
        /// Максимальный поднимаемый вес в 1000 кг.
        /// </summary>
        private const int _maxPressWeight = 1000;

        /// <summary>
        /// Метод для обращения к приватному полю _maxPressWeight.
        /// </summary>
        protected int MaxPressWeight { get; } = _maxPressWeight;

        /// <summary>
        /// Минимальный вес штанги (только гриф): 20 кг.
        /// </summary>
        private const int _minPressWeight = 20;

        /// <summary>
        /// Метод для обращения к приватному полю _minPressWeight.
        /// </summary>
        protected int MinPressWeight { get; } = _minPressWeight;

        /// <summary>
        /// Количество повторений.
        /// </summary>
        private int _repetitions;

        /// <summary>
        /// Публичный метод доступа к количеству повторений.
        /// </summary>
        public int Repetitions
        {
            get => _repetitions;

            set
            {
                CheckRepetitions(value);
                _repetitions = value;
            }
        }

        /// <summary>
        /// Метод проверки количества повторений.
        /// </summary>
        /// <param name="value">Количество повторений.</param>
        /// <exception cref="Exception">Исключение
        /// по некорректному значению
        /// количества повторений.</exception>
        public void CheckRepetitions(int value)
        {
            CheckNullEmpty(value.ToString());

            if (value <= 0
                || value > 300)
            {
                throw new Exception(
                    "количество повторов должно быть задано " +
                    "положительным целочисленным значением " +
                    "и не должно превышать 300!");
            }
        }

        /// <summary>
        /// Метод расчёта затраченных калорий при жиме штанги.
        /// </summary>
        /// <returns>Количество затраченных калорий
        /// при жиме штанги.</returns>
        public override double CalculateCalories =>
            (WeightForPress * 5 * Repetitions / 150);
    }
}
