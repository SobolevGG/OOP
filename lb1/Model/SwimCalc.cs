using System.ComponentModel;

/// <summary>
/// Пространство имён Model.
/// </summary>
namespace Model
{
    /// <summary>
    /// Класс для плавания.
    /// </summary>
    public class SwimCalc : TrainingCalc
    {
        /// <summary>
        /// Тип тренировки - плавание.
        /// </summary>
        public override string TrainingType => "Плавание";

        /// <summary>
        /// Программа тренировки для расчёта калорий.
        /// </summary>
        [DisplayName("Программа тренировки")]
        public override string Params
        {
            get
            {
                return $"Вес человека, кг: {Weight};\n " +
                    $"Расстояние, км: {SwimDistance};\n " +
                    $"Стиль: {RuStyle}";
            }
        }

        /// <summary>
        /// Получение параметра стиля на русском языке.
        /// </summary>
        public string RuStyle
            => GetRuEnumDescrip(Style).ToLower();

        /// <summary>
        /// Расстояние в метрах.
        /// </summary>
        private double _swimDistance;

        /// <summary>
        /// Проверка проплываемого расстояния.
        /// </summary>
        public double SwimDistance
        {
            get => _swimDistance;

            set
            {
                if (!CheckRange(value, 0, MaxSwimDistance))
                {
                    throw new Exception(
                        "расстояние должно быть задано " +
                        "неотрицательным значением " +
                        $"и не должно превышать " +
                        $"{MaxSwimDistance} км!");
                }
                _swimDistance = value;
            }
        }

        /// <summary>
        /// Максимальная дистанция плавания.
        /// </summary>
        private const int _maxSwimDistance = 300;

        /// <summary>
        /// Метод для обращения к приватному полю _maxSwimDistance.
        /// </summary>
        protected int MaxSwimDistance { get; } = _maxSwimDistance;

        /// <summary>
        /// Получение параметра стиля.
        /// </summary>
        public Style Style { get; set; }

        /// <summary>
        /// Метод расчёта затраченных калорий при плавании.
        /// </summary>
        /// <returns>Количество затраченных калорий при плавании.</returns>
        public override double CalculateCalories =>
            (Weight * 3.5 * CalcMetCoef() * SwimDistance / 200);


        /// <summary>
        /// Метод получения коэффициента метаболизма
        /// в зависимости от стиля плавания.
        /// </summary>
        /// <returns>Коэффициента метаболизма.</returns>
        public double CalcMetCoef()
        {
            double metCoef = 10;
            switch (Style)
            {
                case Style.Butterfly:
                    metCoef = (11 * 60 / 15);
                    break;
                case Style.Freestyle:
                    metCoef = 10.5 * 60 / 12;
                    break;
                case Style.Breaststroke:
                    metCoef = 9 * 60 / 10;
                    break;
                case Style.Backstroke:
                    metCoef = 8 * 60 / 8;
                    break;
                default:
                    break;
            }
            return metCoef;
        }
    }
}
