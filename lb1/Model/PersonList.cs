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
    public class PersonList
    {
        /// <summary>
        /// Массив пользователей.
        /// </summary>
        private Person[] _personsArray = new Person[0];

        //TODO: rename
        /// <summary>
        /// Метод добавления пользователей.
        /// </summary>
        /// <param name="person">//TODO: xml</param>
        public void AddPerson(Person person) 
        {
            var newPersonsIndex = _personsArray.Length;
            Array.Resize(ref _personsArray, newPersonsIndex + 1);
            _personsArray[newPersonsIndex] = person;
        }

        /// <summary>
        /// Метод проверки допустимости значения индекса.
        /// </summary>
        /// <param name="index">//TODO: xml</param>
        /// <exception cref="IndexOutOfRangeException">//TODO: xml</exception>
        private void CheckIndex(int index)
        {
            if (index < 0 || index >= _personsArray.Length)
            { 
                throw new IndexOutOfRangeException("Ошибка: " +
                    "индекс вне допустимого диапазона!");
            }
        }

        //TODO: rename
        /// <summary>
        /// Метод удаления пользователей по индексу.
        /// </summary>
        /// <param name="index">//TODO: xml</param>
        public void DeletePerson(int index) 
        { 
            CheckIndex(index);

            for (int i = index; i < _personsArray.Length - 1; i++)
            { 
                _personsArray[i] = _personsArray[i + 1];
            }

            Array.Resize(ref _personsArray, _personsArray.Length - 1);
        }

        //TODO: rename
        /// <summary>
        /// Метод удаления пользователя по переданной персоне.
        /// </summary>
        /// <param name="person"></param>
        public void DeletePerson(Person person) 
        {
            // Определяем индекс первого вхождения пользователя в массиве
            int index = Array.IndexOf(_personsArray, person);
            if (index == -1) 
            {
                throw new ArgumentException("Переданная персона " +
                    "отсутствует в массиве!");
            }
            DeletePerson(index);
        }

        //TODO: rename
        /// <summary>
        /// Метод поиска пользователей.
        /// </summary>
        /// <param name="index">//TODO: xml</param>
        /// <returns>//TODO: xml</returns>
        public Person SearchPerson(int index)
        {
            CheckIndex(index);
            return _personsArray[index];
        }

        /// <summary>
        /// Метод поиска индекса по пользователю.
        /// </summary>
        /// <param name="person">//TODO: xml</param>
        /// <returns>//TODO: xml</returns>
        public int SearchIndex(Person person) 
        {
            var index = -1;
            for (var i = 0; i < _personsArray.Length; i++) 
            {
                if (_personsArray[i] == person) 
                {
                    index = i;
                }
            }

            return index;
        }

        /// <summary>
        /// Метод очистки PersonList.
        /// </summary>
        public void ClearList()
        {
            Array.Resize(ref _personsArray, 0);
        }

        //TODO: rename
        /// <summary>
        /// Метод по подсчёту количества пользователей.
        /// </summary>
        /// <returns>//TODO: xml</returns>
        public int CountPersons() => _personsArray.Length;

    }
}
