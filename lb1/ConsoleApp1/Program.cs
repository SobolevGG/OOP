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
            var egWeight = 65;
            var egMetCoef = 0.1;
            var egDuration = 10;
            var egDistance = 10;
            var egIntensity = Intensity.Sprinting;
            var egStyle = Style.Butterfly;

            Console.WriteLine($"    Пример расчёта калорий " +
                $"для человека:\n      " +
                $"с массой {egWeight} кг;\n      " +
                $"с интенсивностью тренировки: {egIntensity}");

            var runningCalculator = new RunCalc(egWeight,
                                                egMetCoef,
                                                egDistance,
                                                egIntensity);
            double runningCalories = runningCalculator.CalculateCalories();

            Console.WriteLine($"\n    Затрачиваемые калории при беге: {runningCalories}");

            var swimmingCalculator = new SwimCalc(egWeight,
                                                  egMetCoef,
                                                  egDuration,
                                                  egDistance,
                                                  egStyle);

            double swimmingCalories = swimmingCalculator.CalculateCalories();
            Console.WriteLine($"    Затрачиваемые калории при плавании: {swimmingCalories}");

            Console.WriteLine("\n    Для начала расчёта" +
                " сжигаемых калорий выберите тренировку:" +
                "\n      1 - Плавание;" +
                "\n      2 - Бег;" +
                "\n      3 - Жим штанги;" +
                "\n      4 - Отмена.");

            while (true)
            {
                Console.Write("\nВведите цифру из представленного " +
                    "списка: ");
                var consoleKey = Console.ReadLine();
                switch (consoleKey)
                {
                    case "1":
                        {
                            Console.WriteLine("\tОплата по окладу");

                            // PrintWages(WagesBySalary());
                            break;
                        }

                    case "2":
                        {
                            Console.WriteLine("\tОплата по часовой " +
                                "тарифной ставке");

                            // PrintWages(WagesAtTheHourlyTariffRate());
                            break;
                        }

                    case "3":
                        {
                            Console.WriteLine("\tОплата по тарифной " +
                                "ставке");

                            // PrintWages(WagesAtTheTariffRate());
                            break;
                        }

                    case "4":
                        {
                            Environment.Exit(4);
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Попробуйте еще раз");
                        }

                        break;
                }
            }
        }
    }
}
