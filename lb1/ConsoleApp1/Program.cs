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
                            Console.WriteLine("    Плавание;");

                            // PrintConsole(RunTraining());
                            break;
                        }

                    case "2":
                        {
                            PrintConsole(RunTraining());
                            break;
                        }

                    case "3":
                        {
                            Console.WriteLine("    Жим штанги");

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
        /// Расчёт затрачиваемых калорий для бега.
        /// по тарифной ставке.
        /// </summary>
        /// <returns>данные о заработной плате.</returns>
        public static RunCalc RunTraining()
        {
            Console.WriteLine("\n    Вы выбрали бег, перейдём к вводу данных!");
            var runCalc = new RunCalc();
            var actions = new List<Action>()
            {
                new Action(() =>
                {
                    Console.Write("    Ваш вес, кг: ");
                    runCalc.Weight = double.Parse(Console.ReadLine());
                }),
                new Action(() =>
                {
                    Console.Write("    Расстояние, км: ");
                    runCalc.Distance = double.Parse(Console.ReadLine());
                }),
                new Action(() =>
                {
                    Console.Write("    Интенсивность бега (1 - спринт, " +
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
                $"сжигаемых калорий: " +
                $" {Math.Round(value.CalculateCalories(), 3)}.");
        }
    }
}
