namespace Model
{
    /// <summary>
    /// Класс для создания случайной тренировки.
    /// </summary>
    public static class RandomTrainingCalc
    {
        /// <summary>
        /// Рандомайзер
        /// </summary>
        private static Random _random = new Random();

        /// <summary>
        /// Метод генерации случайного числа.
        /// </summary>
        /// <param name="minValue">Минимальное значение.</param>
        /// <param name="maxValue">Максимальное значение.</param>
        /// <returns>Случайное число.</returns>
        public static int GetRandomNum(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }

        /// <summary>
        /// Метод генерации случайной интенсивности.
        /// </summary>
        /// <returns>Случайная интенсивность.</returns>
        public static Intensity GetRandomIntensity()
        {
            // Массив значений перечисления Intensity
            Array intensities = Enum.GetValues(typeof(Intensity));

            // Выбираем случайную интенсивность из перечисления
            return (Intensity)intensities.GetValue
                (_random.Next(intensities.Length));
        }

        /// <summary>
        /// Метод генерации случайного стиля.
        /// </summary>
        /// <returns>Случайный стиль.</returns>
        public static Style GetRandomStyle()
        {
            // Массив значений перечисления Style
            Array styles = Enum.GetValues(typeof(Style));

            // Выбираем случайный стиль из перечисления
            return (Style)styles.GetValue
                (_random.Next(styles.Length));
        }

        /// <summary>
        /// Генерация случайно тренировки.
        /// </summary>
        /// <returns>Случайная тренировка.</returns>
        /// <exception cref="ArgumentException">Исключение
        /// на некорректный аргумент.</exception>
        public static TrainingCalc GetRandomTrainingCalc()
        {
            var figureType = _random.Next(0, 3);

            switch (figureType)
            {
                case 0:
                    {
                        return RandomPressCalc();
                    }
                case 1:
                    {
                        return RandomSwimCalc();
                    }
                case 2:
                    {
                        return RandomRunCalc();
                    }
                default:
                    {
                        throw new ArgumentException("ожидалось " +
                            "значение в диапазоне от 0 до 2.");
                    }
            }
        }

        /// <summary>
        /// Генерация случайной тренировки - жим штанги.
        /// </summary>
        /// <returns>Тренировка - жим штанги.</returns>
        public static TrainingCalc RandomPressCalc()
        {
            var pressCalc = new PressCalc
            {
                // подбираем случайную величину веса
                Weight = GetRandomNum(20, 300),

                // подбираем случайную величину повторений
                Repetitions = GetRandomNum(1, 20),
            };
            return pressCalc;
        }

        /// <summary>
        /// Генерация случайной тренировки - плавание.
        /// </summary>
        /// <returns>Тренировка - плавание.</returns>
        public static TrainingCalc RandomSwimCalc()
        {
            var swimCalc = new SwimCalc
            {
                // подбираем случайную величину веса
                Weight = GetRandomNum(30, 150),

                // подбираем случайную величину расстояния
                Distance = GetRandomNum(1, 10),

                // случайным образом выбираем стиль
                Style = GetRandomStyle(),
            };
            return swimCalc;
        }

        /// <summary>
        /// Генерация случайной тренировки - бег.
        /// </summary>
        /// <returns>Тренировка - бег.</returns>
        public static TrainingCalc RandomRunCalc()
        {
            var runCalc = new RunCalc
            {
                Weight = GetRandomNum(30, 150),
                Distance = GetRandomNum(1, 25),
                Intensity = GetRandomIntensity(),
            };
            return runCalc;
        }
    }
}
