using Model;

/// <summary>
/// Пространство имён.
/// </summary>
namespace ConsoleApp1
{
    /// <summary>
    /// Класс Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("\n    Для начала расчёта" +
                " сжигаемых калорий выберите тренировку:" +
                "\n    1 - Плавание;" +
                "\n    2 - Бег;" +
                "\n    3 - Жим штанги;" +
                "\n    4 - Отмена.");

            for (; ; )
            {
                Console.Write("\n    Выберите вариант тренировки: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            PrintConsole(SwimTraining());
                            break;
                        }

                    case "2":
                        {
                            PrintConsole(RunTraining());
                            break;
                        }

                    case "3":
                        {
                            // PrintConsole(WagesAtTheTariffRate());
                            break;
                        }

                    case "4":
                        {
                            Environment.Exit(4);
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("\n    Некорректный " +
                                "ввод! Попробуйте еще раз.");
                        }

                        break;
                }
            }
        }

        /// <summary>
        /// Метод расчёта затрачиваемых калорий для бега.
        /// </summary>
        /// <returns>Количество сжигаемых калорий.</returns>
        /// <exception cref="IndexOutOfRangeException">Исключение
        /// на недопустимый ввод.</exception>
        public static RunCalc RunTraining()
        {
            Console.WriteLine("\n    Вы выбрали бег, " +
                "перейдём к вводу данных:");
            var runCalc = new RunCalc();
            var actions = new List<Action>()
            {
                new Action(() =>
                {
                    Console.Write("    -Ваш вес, кг: ");
                    _ = double.TryParse(Console.ReadLine(),
                        out double tmpWeight);
                    runCalc.Weight = tmpWeight;
                }),
                new Action(() =>
                {
                    Console.Write("    -Расстояние, км: ");
                    _ = double.TryParse(Console.ReadLine(),
                        out double tmpDistance);
                    runCalc.Distance = tmpDistance;
                }),
                new Action(() =>
                {
                    Console.Write("    -Интенсивность бега (1 - спринт, " +
                        "2 - быстрый бег, 3 - умеренный бег, " +
                        "4 - лёгкий бег): ");

                    _ = int.TryParse(Console.ReadLine(),
                        out int tmpIntensity);

                    int[] allowedValues = {1, 2, 3, 4};

                    if (!allowedValues.Contains(tmpIntensity))
                    {
                        throw new IndexOutOfRangeException
                            ("Ожидалась цифра от 1 до 4.");
                    }

                    switch (tmpIntensity)
                    {      case 1: runCalc.Intensity
                            = Intensity.Sprinting;
                    break; case 2: runCalc.Intensity
                            = Intensity.FastRunning;
                    break; case 3: runCalc.Intensity
                            = Intensity.ModerateRunning;
                    break; case 4: runCalc.Intensity
                            = Intensity.LightJogging;
                    break; default: break; }
                }),
            };
            actions.ForEach(ShowException);
            return runCalc;
        }

        /// <summary>
        /// Метод расчёта затрачиваемых калорий для плавания.
        /// </summary>
        /// <returns>Количество сжигаемых калорий.</returns>
        /// <exception cref="IndexOutOfRangeException">Исключение
        /// на недопустимый ввод.</exception>
        public static SwimCalc SwimTraining()
        {
            Console.WriteLine("\n    Вы выбрали плавание, " +
                "перейдём к вводу данных:");
            var swimCalc = new SwimCalc();
            var actions = new List<Action>()
            {
                new Action(() =>
                {
                    Console.Write("    -Ваш вес, кг: ");
                    _ = double.TryParse(Console.ReadLine(),
                        out double tmpWeight);
                    swimCalc.Weight = tmpWeight;
                }),
                new Action(() =>
                {
                    Console.Write("    -Расстояние, км: ");
                    _ = double.TryParse(Console.ReadLine(),
                        out double tmpDistance);
                    swimCalc.Distance = tmpDistance;
                }),
                new Action(() =>
                {
                    Console.Write("    -Продолжительность, ч: ");
                    _ = double.TryParse(Console.ReadLine(),
                        out double tmpDuration);
                    swimCalc.Duration = tmpDuration;
                }),
                new Action(() =>
                {
                    Console.Write("    -Стиль плавания " +
                        "(1 - баттерфляй, 2 - брасс, " +
                        "3 - на спине, " +
                        "4 - свободный стиль): ");

                    _ = int.TryParse(Console.ReadLine(),
                        out int tmpIntensity);

                    int[] allowedValues = {1, 2, 3, 4};

                    if (!allowedValues.Contains(tmpIntensity))
                    {
                        throw new IndexOutOfRangeException
                            ("Ожидалась цифра от 1 до 4.");
                    }

                    switch (tmpIntensity)
                    {      case 1: swimCalc.Style
                            = Style.Butterfly;
                    break; case 2: swimCalc.Style
                            = Style.Breaststroke;
                    break; case 3: swimCalc.Style
                            = Style.Backstroke;
                    break; case 4: swimCalc.Style
                            = Style.Freestyle;
                    break; default: break; }
                }),
            };
            actions.ForEach(ShowException);
            return swimCalc;
        }

        /// <summary>
        /// Метод для обработки исключений.
        /// </summary>
        /// <param name="action">Дейсвтие.</param>
        /// пользователя.</param>
        private static void ShowException(Action action)
        {
            while (true)
            {
                try
                {
                    action.Invoke();
                    break;
                }
                catch (Exception exception)
                {
                    if (exception.GetType()
                        == typeof(IndexOutOfRangeException)
                        || exception.GetType() == typeof(FormatException)
                        || exception.GetType() == typeof(ArgumentException)
                        || exception.GetType() == typeof(ArgumentNullException))
                    {
                        Console.WriteLine($"    Обнаружена ошибка: " +
                            $"{exception.Message}");
                    }
                    else
                    {
                        throw exception;
                    }
                }
            }
        }

        /// <summary>
        /// Вывод полученной информации на консоль.
        /// </summary>
        /// <param name="value">заработная плата.</param>
        public static void PrintConsole(TrainingCalc value)
        {
            Console.WriteLine($"    Предположительное количество " +
                $"сжигаемых калорий, ккал/мин: " +
                $"{Math.Round(value.CalculateCalories(), 3)}.");
        }
    }
}
