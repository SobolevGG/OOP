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
            => $"Вес с учётом грифа, кг: {WeightForPress};\n " +
                    $"Количество повторов: {Repetitions}";

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
                if (!CheckRange(value, MinPressWeight, MaxPressWeight))
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
        /// Максимальное количество повторений.
        /// </summary>
        private const int _maxRepetitions = 100;

        /// <summary>
        /// Метод для обращения к приватному полю _maxRepetitions.
        /// </summary>
        protected int MaxRepetitions { get; } = _maxRepetitions;

        /// <summary>
        /// Публичный метод доступа к количеству повторений.
        /// </summary>
        public int Repetitions
        {
            get => _repetitions;

            set
            {
                if (!CheckRange(value, 0, MaxRepetitions))
                {
                    throw new Exception(
                    "количество повторов должно быть задано " +
                    "неотрицательным целочисленным значением " +
                    $"и не должно превышать {MaxRepetitions}!");
                }

                _repetitions = value;
            }
        }

        /// <summary>
        /// Метод расчёта затраченных калорий при жиме штанги.
        /// </summary>
        /// <returns>Количество затраченных калорий
        /// при жиме штанги.</returns>
        public override double CalculateCalories =>
            (WeightForPress * 5 * Repetitions / 150.0);
    }
}
