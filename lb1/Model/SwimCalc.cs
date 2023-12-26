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

            if (value < 1 || value > 300)
            {
                throw new ArgumentException(
                    "расстояние должно лежать в диапазоне " +
                    "от 1 до 300 км!");
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
            return Weight * metCoef * Distance;
        }

        /// <summary>
        /// Метод получения коэффициента метаболизма
        /// в зависимости от стиля плавания.
        /// </summary>
        /// <param name="Style">Стиль плавания.</param>
        /// <returns>Коэффициента метаболизма.</returns>
        public override double CalcMetCoef()
        {
            var value =
                Style is Style.Freestyle
                ? 0.02
                : Style is Style.Backstroke
                ? 0.025
                : Style is Style.Breaststroke
                ? 0.03
                : Style is Style.Butterfly
                ? 0.04
                : 0;

            return value;
        }

        /// <summary>
        /// Расчёт калорий для плавания.
        /// </summary>
        public SwimCalc()
        {
        }
    }
}
