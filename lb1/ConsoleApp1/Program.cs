using Model;

/// <summary>
/// Пространство имен ConsoleApp1.
/// </summary>
namespace ConsoleApp1
{
    /// <summary>
    /// Класс Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа приложения C#.
        /// </summary>
        public static void Main()
        {
            // Проверяем работоспособность
            Console.WriteLine("После нажатия любой клавиши " +
                "сгенерируется случайный пользователь.");
            _ = Console.ReadKey();

            Console.WriteLine("\nСлучайный пользователь: ");
            var randomPerson = Person.GetRandomPerson();
            Console.WriteLine(randomPerson.GetInfo());

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

            // Добавляем пользователей в 1-й список при помощи Add()
            actors.Add(robert);
            actors.Add(dwayne);
            actors.Add(matthew);
            actors.Add(jackie);

            // Добавляем пользователей в 2-й список при помощи Add()
            actresses.Add(ann);
            actresses.Add(emilia);
            actresses.Add(angelina);
            actresses.Add(emma);

            // Вывод в консоль 1-го списка
            Console.WriteLine("\nПосле нажатия любой клавиши " +
                "будет выведен список актёров.");
            _ = Console.ReadKey();
            Console.WriteLine("\nСписок актёров:");
            PrintConsole(actors);

            // Вывод в консоль 2-го списка
            Console.WriteLine("\nПосле нажатия любой клавиши " +
                "будет выведен список актрис.");
            _ = Console.ReadKey();
            Console.WriteLine("\nСписок актрис:");
            PrintConsole(actresses);

            // Добавим в 1-ый список пользователя
            Console.WriteLine("\nПосле нажатия любой клавиши " +
                "появится возможность добавления нового актёра " +
                "в список актёров.");
            _ = Console.ReadKey();
            var kit = new Person
                ("Кит", "Харингтон", 36, Gender.Male);
            actors.Add(kit);
            Console.WriteLine("\nНовый актёр успешно добавлен " +
                "в список актёров.\n");

            // Проверка корректного ввода в список
            Console.WriteLine("После нажатия любой клавиши " +
                "появится возможность просмотра списка актёров.");
            _ = Console.ReadKey();
            Console.WriteLine("\nСписок актрёров:");
            PrintConsole(actors);

            // Скопируем второго человека во 2-ой список
            Console.WriteLine("\nПосле нажатия любой клавиши " +
                "появится возможность копирования второго актёра " +
                "в список актрис :D (Да, так надо).");
            _ = Console.ReadKey();
            actresses.Add(actors.Search(1));

            Console.WriteLine("\nДа, мы действительно добавили актёра " +
                $"к актрисам. {actors.Search(1).Name} " +
                $"благодарит Вас :D");

            // Проверка корректного копирования из списка в список
            Console.WriteLine("\nПосле нажатия любой клавиши " +
                "появится возможность просмотра обоих списков.");
            _ = Console.ReadKey();
            Console.WriteLine("\nСписок актёров:");
            PrintConsole(actors);
            Console.WriteLine("\nСписок актрис:");
            PrintConsole(actresses);

            // Удалим второго человека из первого списка
            Console.WriteLine("\nПосле нажатия любой клавиши " +
                "появится \nвозможность удаления скопированного " +
                "человека из первого списка.\nС выводом обоих списков.");
            _ = Console.ReadKey();
            actors.Delete(1);
            Console.WriteLine("\nСписок актёров:");
            PrintConsole(actors);
            Console.WriteLine("\nСписок актрис:");
            PrintConsole(actresses);

            // Очистим 2-ой список
            Console.WriteLine("\nПосле нажатия любой клавиши " +
                "появится возможность удаления списка актрис.");
            _ = Console.ReadKey();
            actresses.Clear();
            Console.WriteLine("\nВторой список успешно очищен. " +
                "Весь список улетел на Бали :D");

            // Проверим возможность ввода с консоли
            Console.WriteLine("После нажатия любой клавиши " +
                "появится возможность ввода нового пользователя.");
            _ = Console.ReadKey();
            var inputPerson = ConsoleCreatePersons();
            Console.WriteLine(inputPerson.GetInfo());
        }

        /// <summary>
        /// Вывод в консoль.
        /// </summary>
        private static void PrintConsole(PersonList personList)
        {
            if (personList == null)
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

        /// <summary>
        /// Метод создания пользователей из консоли.
        /// </summary>
        /// <returns>Пользователь.</returns>
        /// <exception cref="IndexOutOfRangeException">Исключение
        /// на выход из диапазона.</exception>
        public static Person ConsoleCreatePersons()
        {
            var person = new Person();

            var actionList = new List<(Action<string>, string)>
            {
                (
                new Action<string>((string property) =>
                {
                    Console.Write($"\nПользовательское {property}: ");
                    person.Name = Console.ReadLine();
                }), "имя"),

                (new Action<string>((string property) =>
                {
                    Console.Write($"Пользовательская {property}: ");
                    person.Surname = Console.ReadLine();
                }), "фамилия"),

                (new Action<string>((string property) =>
                {
                    Console.Write($"Пользовательский {property}: ");
                    _ = int.TryParse(Console.ReadLine(), out int tmpAge);
                    person.Age = tmpAge;
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

                    var realGender = tmpGender == 1
                        ? Gender.Male
                        : Gender.Female;
                    person.Gender = realGender;
                }), "пол")
        };

            Console.WriteLine();

            foreach (var action in actionList)
            {
                ShowException(action.Item1, action.Item2);
            }

            return person;
        }
    }
}
