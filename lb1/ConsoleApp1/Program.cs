// Подключение namespace *Model* к проекту
using Model;

using System.Diagnostics;
namespace ConsoleApp1
{
    class Program
    {
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