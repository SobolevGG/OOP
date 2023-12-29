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
                    $"Расстояние, км: {Distance};\n " +
                    $"Стиль: {StyleStr}";
            }
        }

        /// <summary>
        /// Получение параметра стиля на русском языке.
        /// </summary>
        public string StyleStr
        {
            get
            {
                string tmpStyle = "";
                switch (Style)
                {
                    case Style.Butterfly:
                        tmpStyle = "баттерфляй";
                        break;
                    case Style.Breaststroke:
                        tmpStyle = "брасс";
                        break;
                    case Style.Backstroke:
                        tmpStyle = "на спине";
                        break;
                    case Style.Freestyle:
                        tmpStyle = "свободный стиль";
                        break;
                    default:
                        break;
                }
                return tmpStyle;
            }
            set { }
        }

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
        /// <exception cref="Exception">Исключение
        /// по некорректному значению расстояния.</exception>
        public void CheckDistance(double value)
        {
            CheckNullEmpty(value.ToString());
            if (value <= 0 || value > 500)
            {
                throw new Exception(
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
        public override double CalculateCalories =>
            (Weight * 3.5 * CalcMetCoef() * Distance / 200);


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

        /// <summary>
        /// Расчёт калорий для плавания.
        /// </summary>
        public SwimCalc()
        {
        }
    }
}
