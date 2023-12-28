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
        /// Публичный метод для доступа к поднимаемому весу.
        /// </summary>
        public override double Weight
        {
            get => _weight;

            set
            {
                CheckWeight(value);
                _weight = value;
            }
        }

        /// <summary>
        /// Метод проверки поднимаемого веса.
        /// </summary>
        /// <param name="value">Поднимаемый вес.</param>
        /// <exception cref="ArgumentException">Исключение
        /// по некорректному значению веса.</exception>
        public override void CheckWeight(double value)
        {
            CheckNullEmpty(value.ToString());
            if (value <= 0)
            {
                throw new ArgumentException("величина веса " +
                    "должна быть положительной!");
            }
            if (value > 1000)
            {
                throw new ArgumentException("величина веса " +
                    " не должна превышать 1000 кг!");
            }
        }

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
        /// <exception cref="ArgumentException">Исключение
        /// по некорректному значению
        /// количества повторений.</exception>
        public void CheckRepetitions(int value)
        {
            CheckNullEmpty(value.ToString());

            if (value < 0)
            {
                throw new ArgumentException(
                    "количество повторений должно быть " +
                    "задано неотрицательной величиной!");
            }
        }

        /// <summary>
        /// Метод расчёта затраченных калорий при жиме штанги.
        /// </summary>
        /// <returns>Количество затраченных калорий
        /// при жиме штанги.</returns>
        public override double CalculateCalories()
        {
            return (Weight * 5 * Repetitions / 150);
        }
    }
}
