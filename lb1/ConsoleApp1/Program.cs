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
            var runningCalculator = new RunCalc(65, 1000, 5, Intensity.Sprinting);
            double runningCalories = runningCalculator.CalculateCalories();
            Console.WriteLine($"\n    Затрачиваемые калории при беге: {runningCalories}");

            var swimmingCalculator = new SwimCalc(65, 1000, 500, 4, Style.Butterfly);
            double swimmingCalories = swimmingCalculator.CalculateCalories();
            Console.WriteLine($"    Калории при плавании: {swimmingCalories}");
        }
    }
}
