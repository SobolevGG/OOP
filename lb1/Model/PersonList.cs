using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс PersonList.
    /// </summary>
    internal class PersonList
    {
        /// <summary>
        /// Массив персон.
        /// </summary>
        private Peson[] _personsArray = new Person[0];
        public void AddPerson(Person person) 
        {
            var newPersonsIndex = newPersonsIndex.Length;
            Array.Resize(ref _personsArray, newPersonsIndex + 1);
            _personsArray[newPersonsIndex] = person;
        }

        /// <summary>
        /// Метод проверки допустимости значения индекса.
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        private void IndexInArray(int index)
        {
            if (index < 0 || index >= _personsArray.Length)
            { 
                throw new IndexOutOfRangeException("Ошибка: индекс вне допустимого диапазона!");
            }
        }
    }
}
