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

            var swimmingCalculator = new SwimCalc(65, 1000, 500, 500, Intensity.MaxLoad);
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
            public static TrainingCalc ConsoleCreateTraining()
            {
                var trainingCalc = new TrainingCalc();

                var actionList = new List<(Action<string>, string)>
                {
                    (
                    new Action<string>((string property) =>
                    {
                        Console.Write($"\nПользовательское {property}: ");
                        trainingCalc.Name = Console.ReadLine();
                    }), "имя"),

                    (new Action<string>((string property) =>
                    {
                        Console.Write($"Пользовательская {property}: ");
                        trainingCalc.Surname = Console.ReadLine();
                    }), "фамилия"),

                    (new Action<string>((string property) =>
                    {
                        Console.Write($"Пользовательский {property}: ");
                        _ = int.TryParse(Console.ReadLine(), out int tmpAge);
                        trainingCalc.Age = tmpAge;
                    }), "возраст"),

                    (new Action<string>((string property) =>
                    {
                        Console.Write
                            ($"Пользовательский {property} (1 - Мужчина, 2 - Женщина): ");
                        _ = int.TryParse(Console.ReadLine(), out int tmpGender);

                        if (tmpGender != 1 && tmpGender != 2)
                        {
                            throw new IndexOutOfRangeException
                                ("Пол вводится цифрами: *1* - мужчина, " +
                                "*2* - женщина.");
                        }

                        var realGender = tmpGender == 1;
                    }),
                };

                Console.WriteLine();

                foreach (var action in actionList)
                {
                    ShowException(action.Item1, action.Item2);
                }

                return trainingCalc;
            }















            // PersonList personList;
            // 
            // // Сколько персон случайным образом сгенерировать?
            // int amountPerson = 7;
            // 
            // // Генерируем случайные персоны
            // GetPerson(out personList, amountPerson);
            // 
            // // Уведомляем пользователя, что персоны готовы :D
            // Console.WriteLine("\n    Был сформирован список " +
            //     $"из {amountPerson} человек:");
            // 
            // // Выводим наш список персон
            // PrintConsole(personList);
            // 
            // Console.Write("    Вы можете посмотреть " +
            //     "дополнительную информацию о человеке.\n" +
            //     "    О взрослом человеке Вы можете узнать его зарплату,\n" +
            //     "    О ребёнке - его средний балл по программированию.\n" +
            //     $"    Введите номер человека в списке: ");
            // 
            // var personNum = Console.ReadLine();
            // 
            // // Минимальный обработчик ввода
            // if (!int.TryParse(personNum, out int tmpNum))
            // {
            //     throw new ArgumentException("Введите целочисленное " +
            //         "положительное значение");
            // }
            // 
            // var person = personList.Search(tmpNum - 1);
            // 
            // switch (person)
            // {
            //     case RunСalculation adult:
            //         Console.WriteLine($"\n    Заработная плата " +
            //             $"{person.Surname} {person.Name}: " +
            //             $"{adult.GetSalary()}");
            //         break;
            //     case SwimCalculation child:
            //         var tmpProgress = child.GetSchoolProgress();
            //         Console.WriteLine($"\n    {person.Surname} " +
            //             $"{person.Name} имеет успеваемость " +
            //             $"в школе (учреждении дошкольного " +
            //             $"образования) \"{tmpProgress}\";\n" +
            //             $"    Следовательно, карманные расходы " +
            //             $"составили: " +
            //             $"{child.GetPocketExpenses(tmpProgress)}.");
            //         break;
            //     default:
            //         break;
            // }
        }

        // /// <summary>
        // /// Метод для генерации персон.
        // /// </summary>
        // /// <param name="personList">Список персон.</param>
        // /// <param name="numPerson">Количество персон.</param>
        // private static void GetPerson(out PersonList personList, int numPerson)
        // {
        //     personList = new PersonList();
        //     var random = new Random();
        // 
        //     // Генератор взрослых и детей
        //     for (var i = 0; i < numPerson; i++)
        //     {
        //         CalculationBase randomPerson = random.Next(1, 3) == 1
        //             ? RunСalculation.GetRandomPerson()
        //             : SwimCalculation.GetRandomPerson();
        //         personList.Add(randomPerson);
        //     }
        // }
        // 
        // /// <summary>
        // /// Вывод в консoль.
        // /// </summary>
        // private static void PrintConsole(PersonList personList)
        // {
        //     if (personList.Count() == 0)
        //     {
        //         throw new NullReferenceException("Извините, " +
        //             "но список пока пуст.");
        //     }
        // 
        //     else if (personList.Count() > 0)
        //     {
        //         for (int i = 0; i < personList.Count(); i++)
        //         {
        //             var tmpPerson = personList.Search(i);
        //             Console.WriteLine($"    {i + 1}. "
        //                 + tmpPerson.GetInfoBase());
        //         }
        //     }
        // }
    }
}
