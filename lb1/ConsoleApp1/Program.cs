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
            var actors = new PersonList();
            var actresses = new PersonList();

            var Robert = new Person("Роберт", "Дауни", 57, Gender.Male);
            var Dwayne = new Person("Дуэйн", "Джонсон", 50, Gender.Male);
            var Matthew = new Person("Мэттью", "Макконахи", 53, Gender.Male);
            var Jackie = new Person("Джеки", "Чан", 68, Gender.Male);

            var Ann = new Person("Энн", "Хэтэуэй", 40, Gender.Female);
            var Emilia = new Person("Эмилия", "Кларк", 36, Gender.Female);
            var Angelina = new Person("Анджелина", "Джоли", 47, Gender.Female);
            var Emma = new Person("Эмма", "Стоун", 32, Gender.Female);

            actors.AddPerson(Robert);
            actors.AddPerson(Dwayne);
            actors.AddPerson(Matthew);
            actors.AddPerson(Jackie);

            actresses.AddPerson(Ann);
            actresses.AddPerson(Emilia);
            actresses.AddPerson(Angelina);
            actresses.AddPerson(Emma);


        }
    }
}