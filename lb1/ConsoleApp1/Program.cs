// Подключение namespace *Model* к проекту
using Model;
using System.Diagnostics;

namespace ConsoleApp1
{
    /// <summary>
    /// Класс Program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Метод Main.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Согласно заданию создаём два логически разделённых списка
            var actors = new PersonList();
            var actresses = new PersonList();

            // Создаём пользователей для 1-го списка
            var robert = new Person("Роберт", "Дауни", 57, Gender.Male);
            var dwayne = new Person("Дуэйн", "Джонсон", 50, Gender.Male);
            var matthew = new Person("Мэттью", "Макконахи", 53, Gender.Male);
            var jackie = new Person("Джеки", "Чан", 68, Gender.Male);

            // Создаём пользователей для 2-го списка
            var ann = new Person("Энн", "Хэтэуэй", 40, Gender.Female);
            var emilia = new Person("Эмилия", "Кларк", 36, Gender.Female);
            var angelina = new Person("Анджелина", "Джоли", 47, Gender.Female);
            var emma = new Person("Эмма", "Стоун", 32, Gender.Female);

            // Добавляем пользователей в 1-й список при помощи AddPerson()
            actors.AddPerson(robert);
            actors.AddPerson(dwayne);
            actors.AddPerson(matthew);
            actors.AddPerson(jackie);

            // Добавляем пользователей в 2-й список при помощи AddPerson()
            actresses.AddPerson(ann);
            actresses.AddPerson(emilia);
            actresses.AddPerson(angelina);
            actresses.AddPerson(emma);

            // Вывод в консоль 1-го списка
            Console.WriteLine("После нажатия любой клавиши " +
                "будет выведен список актёров.");
            _ = Console.ReadKey();
            Console.WriteLine("Список актёров:");
            PrintConsole(actors);

            // Вывод в консоль 2-го списка
            Console.WriteLine("После нажатия любой клавиши " +
                "будет выведен список актрис.");
            _ = Console.ReadKey();
            Console.WriteLine("Список актрис:");
            PrintConsole(actresses);

            // Добавим в 1-ый список пользователя
            Console.WriteLine("После нажатия любой клавиши " +
                "появится возможность добавления нового актёра.");
            _ = Console.ReadKey();
            var kit = new Person
                ("Кит", "Харингтон", 36, Gender.Male);
            actors.AddPerson(kit);
            Console.WriteLine("Новый актёр успешно добавлен.");

            // Добавим во 2-ый список пользователя
            Console.WriteLine("После нажатия любой клавиши " +
                "появится возможность добавления новой актрисы.");
            _ = Console.ReadKey();
            var rose = new Person
                ("Роуз", "Лесли", 36, Gender.Female);
            actresses.AddPerson(rose);
            Console.WriteLine("Новая актриса успешно добавлена.");

            // Скопируем второго человека во 2-ой список
            Console.WriteLine("После нажатия любой клавиши " +
                "появится возможность копирования второго актёра" +
                "в список актрис :D \n(так надо).");
            _ = Console.ReadKey();
            actresses.AddPerson(actors.SearchPersons(1));

            Console.WriteLine("Да, мы действительно добавили актёра " +
                $"к актрисам.\n{actors.SearchPersons(1).Name} " +
                $"благодарит Вас :D");

            /// <summary>
            /// Вывод в консоль.
            /// </summary>
            private static void PrintConsole(PersonList personList)
            {
                if (personList == null)
                {
                    throw new NullReferenceException("Извините, но список пока пуст.");
                }

                if (personList.CountPersons() > 0)
                {
                    for (int i = 0; i < personList.CountPersons(); i++)
                    {
                        var tmpPerson = personList.SearchPersons(i);
                        Console.WriteLine(tmpPerson.ToString());
                    }
                }

                else
                {
                    Console.WriteLine("List is empty.");
                }
            }
        }
    }
}