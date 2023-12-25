namespace Model
{
    /// <summary>
    /// Класс для расчёта калорий.
    /// </summary>
    public abstract class TrainingCalc
    {
        /// <summary>
        /// Конструктор базового класса.
        /// </summary>
        public TrainingCalc()
        {
        }

        /// <summary>
        /// Вес человека в килограммах.
        /// </summary>
        protected double _weight;

        /// <summary>
        /// Проверка веса человека.
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
            value = PeriodComma(value.ToString());
            if (value < 3 || value > 500)
            {
                throw new ArgumentException(value.ToString(), "Масса " +
                    "должна быть задана в диапазоне от 3 до 500 кг!");
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
        /// Метод проверки замены точки на запятую.
        /// </summary>
        /// <returns>Проверенное значение.</returns>
        public double PeriodComma(string value)
        {
            if (value.Contains('.'))
            {
                // Заменяем точку на запятую
                value = value.Replace(".", ",");
            }
            return double.Parse(value);
        }

        /// <summary>
        /// Коэффициент метаболизма.
        /// </summary>
        protected double _metCoef;

        /// <summary>
        /// Проверка коэффициента метаболизма.
        /// </summary>
        public double MetCoef
        {
            get => _metCoef;

            set
            {
                CheckMetCoef(value);
                _metCoef = value;
            }
        }

        /// <summary>
        /// Метод проверки коэффициента метаболизма.
        /// </summary>
        /// <param name="value">Коэффициент метаболизма.</param>
        /// <exception cref="ArgumentException">Исключение
        /// на некорректное значение
        /// коэффициента метаболизма.</exception>
        public void CheckMetCoef(double value)
        {
            CheckNullEmpty(value.ToString());

            if (value > 1 || value < 0)
            {
                throw new ArgumentException(value.ToString(),
                    "Коэффициент метаболизма должен быть " +
                    "в диапазоне от 0 до 1 о.е.!");
            }
        }

        /// <summary>
        /// Абстрактный метод расчета калорий.
        /// </summary>
        public abstract double CalculateCalories();

        /// <summary>
        /// Абстрактный метод расчета коэффициента метаболизма.
        /// </summary>
        public abstract double CalcMetCoef();
    }
}
