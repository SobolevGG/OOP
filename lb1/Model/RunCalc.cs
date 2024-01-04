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
                    $"Расстояние, км: {Distance};\n " +
                    $"Интенсивность: {IntensityStr}";
            }
        }

        /// <summary>
        /// Получение параметра интенсивности на русском языке.
        /// </summary>
        public string IntensityStr
        {
            get
            {
                string tmpIntensity = "";
                switch (Intensity)
                {
                    case Intensity.Sprinting:
                        tmpIntensity = "спринт";
                        break;
                    case Intensity.FastRunning:
                        tmpIntensity = "быстрый бег";
                        break;
                    case Intensity.ModerateRunning:
                        tmpIntensity = "умеренный бег";
                        break;
                    case Intensity.LightJogging:
                        tmpIntensity = "лёгкий бег";
                        break;
                    default:
                        break;
                }
                return tmpIntensity;
            }
            set { }
        }

        /// <summary>
        /// Расстояние в километрах.
        /// </summary>
        private double _distance;

        /// <summary>
        /// Публичный метод доступа к пробегаемому расстоянию.
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
        /// <exception cref="Exception">Исключение
        /// по некорректному значению расстояния.</exception>
        public void CheckDistance(double value)
        {
            CheckNullEmpty(value.ToString());

            if (value <= 0 || value > 1000)
            {
                throw new Exception(
                    "расстояние должно быть положительным " +
                    "и не превышать 1000 км!");
            }
        }

        /// <summary>
        /// Получение параметра интенсивности.
        /// </summary>
        public Intensity Intensity { get; set; }

        /// <summary>
        /// Метод расчёта затраченных калорий при беге.
        /// </summary>
        /// <returns>Количество затраченных калорий при беге.</returns>
        public override double CalculateCalories =>
            (Weight * 3.5 * CalcMetCoef() * Distance / 200);


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