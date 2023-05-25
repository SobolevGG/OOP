using Model;

// TODO: Включить линтеры
// TODO: gitignore
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
            var personList = new PersonList();
            var random = new Random();

            // Генератор взрослых и детей
            for (var i = 0; i < 7; i++)
            {
                PersonBase randomPerson = random.Next(1, 3) == 1
                    ? Adult.GetRandomPerson()
                    : Child.GetRandomPerson();
                personList.Add(randomPerson);
            }

            Console.WriteLine("Список из 7 человек:");
            PrintConsole(personList);

            _ = Console.ReadKey();

            var person = personList.Search(3);
            switch (person)
            {
                case Adult adult:
                    Console.WriteLine($"\n{adult.Surname} {adult.Name}" +
                        $"({adult.Age} age) prefers {adult.GetFavoriteDrink()}");
                    break;
                case Child child:
                    Console.WriteLine($"\n{child.GetNameSurname()}" +
                        $"({child.Age} age) has a model of {child.GetShipCollection()}");
                    break;
                default:
                    break;
            }

            _ = Console.ReadKey();
        }

        /// <summary>
        /// Вывод в консoль.
        /// </summary>
        private static void PrintConsole(PersonList personList)
        {
            if (personList.Length == 0)
            {
                throw new NullReferenceException("Извините, " +
                    "но список пока пуст.");
            }

            else if (personList.Count() > 0)
            {
                for (int i = 0; i < personList.Count(); i++)
                {
                    var tmpPerson = personList.Search(i);
                    Console.WriteLine(tmpPerson.GetInfo());
                }
            }
        }

        /// <summary>
        /// Метод для вывода исключений в консоль.
        /// </summary>
        /// <param name="action">Дейсвтие.</param>
        /// <param name="characteristic">Одна из характеристик
        /// пользователя.</param>
        private static void ShowException(Action<string> action,
            string characteristic)
        {
            while (true)
            {
                try
                {
                    action.Invoke(characteristic);
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
                            $"*{characteristic}* введена не верно." +
                        $"\nОшибка: {exception.Message}");
                    }
                    else
                    {
                        throw exception;
                    }
                }
            }
        }
    }
}
