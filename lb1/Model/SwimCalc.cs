namespace Model
{
    /// <summary>
    /// Класс для плавания.
    /// </summary>
    public class SwimCalc : TrainingCalc
    {
        /// <summary>
        /// Расстояние в метрах.
        /// </summary>
        private double _distance;

        /// <summary>
        /// Проверка проплываемого расстояния.
        /// </summary>
        public double Distance
        {
            get => _distance;

            set
            {
                CheckDistance(value);
                _distance = value;
            }
        }

        /// <summary>
        /// Метод проверки расстояния для плавания.
        /// </summary>
        /// <param name="value">Расстояние в километрах.</param>
        /// <exception cref="ArgumentException">Исключение
        /// по некорректному значению расстояния.</exception>
        public void CheckDistance(double value)
        {
            CheckNullEmpty(value.ToString());
            if (value <= 0 || value > 500)
            {
                throw new ArgumentException(
                    "расстояние должно быть положительным " +
                    "и не превышать 500 км!");
            }
        }

        /// <summary>
        /// Стиль плавания.
        /// </summary>
        private Style _style;

        /// <summary>
        /// Получение параметра стиля.
        /// </summary>
        public Style Style
        {
            get => _style;
            set
            {
                _style = value;
            }
        }

        /// <summary>
        /// Метод расчёта затраченных калорий при плавании.
        /// </summary>
        /// <returns>Количество затраченных калорий при плавании.</returns>
        public override double CalculateCalories()
        {
            double metCoef = CalcMetCoef();
            return (double)(Weight * 3.5 * metCoef * Distance / 200);
        }

        /// <summary>
        /// Метод получения коэффициента метаболизма
        /// в зависимости от стиля плавания.
        /// </summary>
        /// <returns>Коэффициента метаболизма.</returns>
        public override double CalcMetCoef()
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

        /// <summary>
        /// Расчёт калорий для плавания.
        /// </summary>
        public SwimCalc()
        {
        }
    }
}
