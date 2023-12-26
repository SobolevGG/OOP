namespace Model
{
    /// <summary>
    /// Класс для бега.
    /// </summary>
    public class RunCalc : TrainingCalc
    {
        /// <summary>
        /// Расстояние в километрах.
        /// </summary>
        private double _distance;

        /// <summary>
        /// Проверка пробегаемого расстояния.
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
                throw new ArgumentException(value.ToString(),
                    "Расстояние должно соответствовать диапазону " +
                    "от 1 до 600 км!");
            }
        }

        /// <summary>
        /// Интенсивность бега.
        /// </summary>
        private Intensity _intensity;

        /// <summary>
        /// Получение параметра интенсивности.
        /// </summary>
        public Intensity Intensity
        {
            get => _intensity;
            set
            {
                _intensity = value;
            }
        }

        /// <summary>
        /// Метод расчёта затраченных калорий при беге.
        /// </summary>
        /// <returns>Количество затраченных калорий при беге.</returns>
        public override double CalculateCalories()
        {
            double metCoef = CalcMetCoef();
            return Weight * metCoef * Distance;
        }

        /// <summary>
        /// Метод получения коэффициента метаболизма
        /// в зависимости от интенсивности бега.
        /// </summary>
        /// <param name="intensity"></param>
        /// <returns>Коэффициент метаболизма.</returns>
        public override double CalcMetCoef()
        {
            double metCoef = 0;

            switch (Intensity)
            {
                case Intensity.Sprinting:
                    metCoef = 0.04;
                    break;
                case Intensity.FastRunning:
                    metCoef = 0.035;
                    break;
                case Intensity.ModerateRunning:
                    metCoef = 0.03;
                    break;
                case Intensity.LightJogging:
                    metCoef = 0.015;
                    break;
                default:
                    break;
            }
            return (double)metCoef;
        }
    }
}
