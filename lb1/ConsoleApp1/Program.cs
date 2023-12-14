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
            PersonList personList;

            // Сколько персон случайным образом сгенерировать?
            int numPerson = 7;

            // Генерируем случайные персоны
            GetPerson(out personList, numPerson);

            // Уведомляем пользователя, что персоны готовы :D
            Console.WriteLine("\n    Был сформирован список " +
                $"из {numPerson} человек.\n");

            // Выводим наш список персон
            PrintConsole(personList);

            _ = Console.ReadKey();

            var person = personList.Search(3);
            Console.WriteLine("    Вы можете посмотреть " +
                "дополнительную информацию о человеке " +
                "в зависимости от его возраста: о взрослом " +
                "человеке вы можете узнать его зарплату, " +
                "а о ребёнке - его средний балл по программированию.\n" +
                "Введите номер человека в списке.");
            switch (person)
            {
                case Adult adult:
                    Console.WriteLine($"\n{adult.GetInfo()}");
                    break;
                case Child child:
                    Console.WriteLine($"\n{child.GetInfo()}" +
                        $"({child.GetShipCollection()}");
                    break;
                default:
                    break;
            }

            _ = Console.ReadKey();
        }

        private static void GetPerson(out PersonList personList, int numPerson)
        {
            personList = new PersonList();
            var random = new Random();

            // Генератор взрослых и детей
            for (var i = 0; i < numPerson; i++)
            {
                PersonBase randomPerson = random.Next(1, 3) == 1
                    ? Adult.GetRandomPerson()
                    : Child.GetRandomPerson();
                personList.Add(randomPerson);
            }
        }

        /// <summary>
        /// Вывод в консoль.
        /// </summary>
        private static void PrintConsole(PersonList personList)
        {
            if (personList.Count() == 0)
            {
                throw new NullReferenceException("Извините, " +
                    "но список пока пуст.");
            }

            else if (personList.Count() > 0)
            {
                for (int i = 0; i < personList.Count(); i++)
                {
                    var tmpPerson = personList.Search(i);
                    Console.WriteLine();
                    Console.WriteLine($"    {i}. " + tmpPerson.GetInfoBase());
                }
            }
        }
    }
}
