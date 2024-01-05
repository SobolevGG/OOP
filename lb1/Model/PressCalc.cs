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
                return $"Вес с учётом грифа, кг: {Weight};\n " +
                    $"Количество повторов: {Repetitions}";
            }
        }

        /// <summary>
        /// Публичный метод для доступа к поднимаемому весу.
        /// </summary>
        public override double Weight
        {
            get => _weight;

            set
            {
                CheckRange(value, 1, 1000);
                _weight = value;
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
            (Weight * 5 * Repetitions / 150);
    }
}
