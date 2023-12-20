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
            int amountPerson = 7;

            // Генерируем случайные персоны
            GetPerson(out personList, amountPerson);

            // Уведомляем пользователя, что персоны готовы :D
            Console.WriteLine("\n    Был сформирован список " +
                $"из {amountPerson} человек:");

            // Выводим наш список персон
            PrintConsole(personList);

            Console.Write("    Вы можете посмотреть " +
                "дополнительную информацию о человеке.\n" +
                "    О взрослом человеке Вы можете узнать его зарплату,\n" +
                "    О ребёнке - его средний балл по программированию.\n" +
                $"    Введите номер человека в списке: ");

            var personNum = Console.ReadLine();

            // Минимальный обработчик ввода
            if (!int.TryParse(personNum, out int tmpNum))
            {
                throw new ArgumentException("Введите целочисленное " +
                    "положительное значение");
            }

            var person = personList.Search(tmpNum - 1);

            switch (person)
            {
                case Adult adult:
                    Console.WriteLine($"\n    {adult.GetSalary()}");
                    break;
                case Child child:
                    Console.WriteLine($"\n    {child.GetInfo()}" +
                        $"({child.GetShipCollection()}");
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Метод для генерации персон.
        /// </summary>
        /// <param name="personList">Список персон.</param>
        /// <param name="numPerson">Количество персон.</param>
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
                    Console.WriteLine($"    {i + 1}. "
                        + tmpPerson.GetInfoBase());
                }
            }
        }
    }
}
