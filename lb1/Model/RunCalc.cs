using System.ComponentModel;

/// <summary>
/// Пространство имён Model.
/// </summary>
namespace Model
{
    /// <summary>
    /// Класс для бега.
    /// </summary>
    public class RunCalc : TrainingCalc
    {
        /// <summary>
        /// Тип тренировки - бег.
        /// </summary>
        public override string TrainingType => "Бег";

        /// <summary>
        /// Программа тренировки для расчёта калорий.
        /// </summary>
        [DisplayName("Программа тренировки")]
        public override string Params
        {
            get
            {
                return $"Вес человека, кг: {Weight};\n " +
                    $"Расстояние, км: {RunDistance};\n " +
                    $"Интенсивность: {RuIntensity}";
            }
        }

        /// <summary>
        /// Получение параметра интенсивности на русском языке.
        /// </summary>
        public string RuIntensity
            => GetRuEnumDescrip(Intensity).ToLower();

        /// <summary>
        /// Расстояние в километрах.
        /// </summary>
        private double _runDistance;

        /// <summary>
        /// Публичный метод доступа к пробегаемому расстоянию.
        /// </summary>
        public double RunDistance
        {
            get => _runDistance;

            set
            {
                if (!CheckRange(value, 0, MaxRunDistance))
                {
                    throw new Exception(
                        "расстояние должно быть задано " +
                        "неотрицательным значением " +
                        $"и не должно превышать " +
                        $"{MaxRunDistance} км!");
                }
                _runDistance = value;
            }
        }

        /// <summary>
        /// Максимальная дистанция бега.
        /// </summary>
        private const int _maxRunDistance = 600;

        /// <summary>
        /// Метод для обращения к приватному полю _maxRunDistance.
        /// </summary>
        protected int MaxRunDistance => _maxRunDistance;

        /// <summary>
        /// Получение параметра интенсивности.
        /// </summary>
        public Intensity Intensity { get; set; }

        /// <summary>
        /// Метод расчёта затраченных калорий при беге.
        /// </summary>
        /// <returns>Количество затраченных калорий при беге.</returns>
        public override double CalculateCalories =>
            (Weight * 3.5 * CalcMetCoef() * RunDistance / 200);


        /// <summary>
        /// Метод получения коэффициента метаболизма
        /// в зависимости от интенсивности бега.
        /// </summary>
        /// <returns>Коэффициент метаболизма.</returns>
        public double CalcMetCoef()
        {
            double metCoef = 10;
            switch (Intensity)
            {
                case Intensity.Sprinting:
                    metCoef = 16.38 / 15 * 60;
                    break;
                case Intensity.FastRunning:
                    metCoef = 12.59 / 12 * 60;
                    break;
                case Intensity.ModerateRunning:
                    metCoef = 10.06 / 10 * 60;
                    break;
                case Intensity.LightJogging:
                    metCoef = 7.54 / 8 * 60;
                    break;
                default:
                    break;
            }
            return (double)metCoef;
        }
    }
}
