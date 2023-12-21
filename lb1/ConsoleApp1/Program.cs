using Model;
using System.Reflection;
using System;

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

            Console.WriteLine($"\n    Добрый день! Прежде, чем приступить к тренировке давайте рассчитаем сжигаемые калории.\n" +
                $"Ведите свой вес, выберите желаемую тренировку (бег, плавание, жим штанги).");

            var runningCalculator = new RunCalc(65, 1000, 5, 19);
            double runningCalories = runningCalculator.CalculateCalories();
            Console.WriteLine($"\n    Калории при беге: {runningCalories}");

            var swimmingCalculator = new SwimCalc(65, 1000, 500, 500, Intensity.Sprinting);
            double swimmingCalories = swimmingCalculator.CalculateCalories();
            Console.WriteLine($"    Калории при плавании: {swimmingCalories}");











            /// <summary>
            /// Метод для вывода исключений в консоль.
            /// </summary>
            /// <param name="action">Дейсвтие.</param>
            /// <param name="characteristic">Одна из характеристик
            /// пользователя.</param>
            private static void ShowException(Action<string> action,
                string property)
            {
                while (true)
                {
                    try
                    {
                        action.Invoke(property);
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
                            Console.WriteLine($"К сожалению, характеристика " +
                                $"*{property}* введена не верно." +
                            $"\nОшибка: {exception.Message}");
                        }
                        else
                        {
                            throw exception;
                        }
                    }
                }
            }

            /// <summary>
            /// Метод создания тренировок из консоли.
            /// </summary>
            /// <returns>Тренировка.</returns>
            /// <exception cref="IndexOutOfRangeException">Исключение
            /// на выход из диапазона.</exception>
            // public static TrainingCalc ConsoleCreateTraining()
            // {
            //     var trainingCalc = new TrainingCalc();
            // 
            //     var actionList = new List<(Action<string>, string)>
            //     {
            //         (
            //         new Action<string>((string property) =>
            //         {
            //             Console.Write($"\nПользовательский {property}: ");
            //             trainingCalc.Weight = Console.ReadLine();
            //         }), "вес"),
            // 
            //         (new Action<string>((string property) =>
            //         {
            //             Console.Write($"Пользовательская {property}: ");
            //             trainingCalc. = Console.ReadLine();
            //         }), "фамилия"),
            // 
            //         (new Action<string>((string property) =>
            //         {
            //             Console.Write($"Пользовательский {property}: ");
            //             _ = int.TryParse(Console.ReadLine(), out int tmpAge);
            //             trainingCalc.Age = tmpAge;
            //         }), "возраст"),
            // 
            //         (new Action<string>((string property) =>
            //         {
            //             Console.Write
            //                 ($"{property} (1 - максимальное ускорение, " +
            //                 $"2 - умеренная скорость, " +
            //                 $"3 - лёгкий бег): ");
            //             _ = int.TryParse(Console.ReadLine(), out int tmpIntensity);
            // 
            //             if (tmpIntensity != 1 && tmpIntensity != 2 && tmpIntensity != 3)
            //             {
            //                 throw new IndexOutOfRangeException
            //                     ("Интенсивность вводится цифрами: " +
            //                     "\n \"1\" - Максимальное ускорение;" +
            //                     "\n \"2\" - Умеренная скорость;" +
            //                     "\n \"3\" - Лёгкий бег.");
            //             }
            // 
            //             if (tmpIntensity == 1)
            //             {
            //                 trainingCalc.Intensity = Intensity.Sprinting;
            //             }
            //             else if (tmpIntensity == 2)
            //             {
            //                 trainingCalc.Intensity = Intensity.ModerateRunning;
            //             }
            //             else
            //             {
            //                 trainingCalc.Intensity = Intensity.LightJogging;
            //             }
            // 
            //             trainingCalc.Intensity = Intensity.Sprinting;
            //         }), "интенсивность бега")
            //     };
            // 
            //     Console.WriteLine();
            // 
            //     foreach (var action in actionList)
            //     {
            //         ShowException(action.Item1, action.Item2);
            //     }
            // 
            //     return trainingCalc;
            // }
        }
    }
}
