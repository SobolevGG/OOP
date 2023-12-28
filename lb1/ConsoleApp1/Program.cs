// Формулы расчёта и MET:
// https://en.wikipedia.org/wiki/Metabolic_equivalent_of_task
// https://calculator.academy/mets-metabolic-equivalent-calculator/
// https://calculator.academy/bench-press-calories-calculator/

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
        /// Метод Main.
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
                Console.Write("\n    Выберите " +
                    "вариант тренировки: ");
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
                            PrintConsole(PressTraining());
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
                    runCalc.Weight = CheckInput();
                }),
                new Action(() =>
                {
                    Console.Write("    -Расстояние, км: ");
                    runCalc.Distance = CheckInput();
                }),
                new Action(() =>
                {
                    Console.Write("    -Интенсивность бега " +
                        "(1 - спринт, " +
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
                    swimCalc.Weight = CheckInput();
                }),
                new Action(() =>
                {
                    Console.Write("    -Расстояние, км: ");
                    swimCalc.Distance = CheckInput();
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
        /// Метод расчёта затрачиваемых калорий для жима штанги.
        /// </summary>
        /// <returns>Количество сжигаемых калорий.</returns>
        /// <exception cref="IndexOutOfRangeException">Исключение
        /// на недопустимый ввод.</exception>
        public static PressCalc PressTraining()
        {
            Console.WriteLine("\n    Вы выбрали жим штанги, " +
                "перейдём к вводу данных:");
            var pressCalc = new PressCalc();
            var actions = new List<Action>()
            {
                new Action(() =>
                {
                    Console.Write("    -Поднимаемый вес, кг: ");
                    pressCalc.Weight = CheckInput();
                }),
                new Action(() =>
                {
                    Console.Write("    -Количество повторений: ");
                    if (!int.TryParse(Console.ReadLine(),
                        out int tmpRepetitions))
                    {
                        throw new Exception("количество повторений " +
                            "должно быть задано целым числом!");
                    }

                    pressCalc.Repetitions = tmpRepetitions;
                }),
            };
            actions.ForEach(ShowException);
            return pressCalc;
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
                        || exception.GetType() == typeof(ArgumentNullException)
                        || exception.GetType() == typeof(Exception))
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
        /// Метод вывода результатов расчёта в консоль.
        /// </summary>
        /// <param name="value">Рассчитанные калории.</param>
        public static void PrintConsole(TrainingCalc value)
        {
            Console.WriteLine($"    Предположительное количество " +
                $"сжигаемых калорий, ккал: " +
                $"{Math.Round(value.CalculateCalories(), 3)}.");
        }

        /// <summary>
        /// Метод замены точки на запятую.
        /// </summary>
        /// <returns>Скорректированное значение.</returns>
        public static double CheckInput()
        {
            string tmpValue = Console.ReadLine().Replace(".", ",");

            return !double.TryParse(tmpValue, out _)
                ? throw new Exception("введено " +
                "нечисловое значение!")
                : double.Parse(tmpValue);
        }
    }
}
