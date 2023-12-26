namespace Model
{
    /// <summary>
    /// Класс для расчёта калорий.
    /// </summary>
    public abstract class TrainingCalc
    {
        /// <summary>
        /// Абстрактный метод расчета калорий.
        /// </summary>
        public abstract double CalculateCalories();

        /// <summary>
        /// Абстрактный метод расчета коэффициента метаболизма.
        /// </summary>
        public abstract double CalcMetCoef();

        /// <summary>
        /// Вес человека в килограммах.
        /// </summary>
        protected double _weight;

        /// <summary>
        /// Публичный метод для доступа к весу человека.
        /// </summary>
        public double Weight
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
        /// <exception cref="ArgumentException">Исключение
        /// по некорректному значению веса.</exception>
        public void CheckWeight(double value)
        {
            CheckNullEmpty(value.ToString());
            if (value < 3 || value > 500)
            {
                throw new ArgumentException("вес " +
                    "должен лежать в диапазоне от 3 до 500 кг!");
            }
        }

        /// <summary>
        /// Метод проверки пустого ввода.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <exception cref="ArgumentNullException">Исключение
        /// на пустой ввод.</exception>
        public void CheckNullEmpty(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(value, "Ввод не может " +
                    "быть пустым!");
            }
        }

        /// <summary>
        /// Коэффициент метаболизма.
        /// </summary>
        protected double _metCoef;

        /// <summary>
        /// Публичный метод для доступа к коэффициенту метаболизма.
        /// </summary>
        public double MetCoef
        {
            get => _metCoef;
            set => _metCoef = value;
        }
    }
}
