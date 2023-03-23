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
            try
            {
                // string.Empty - передача пустой строки
                Person person = new Person(string.Empty, "Test1", 23);
            }
            catch
            {
                Console.WriteLine("Name is empty!");
            }
            Console.ReadKey();
        }
    }
}