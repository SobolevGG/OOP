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
        /// Массив пользователей.
        /// </summary>
        private Peson[] _personsArray = new Person[0];

        /// <summary>
        /// Метод добавления пользователей.
        /// </summary>
        /// <param name="person"></param>
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
        private void CheckIndex(int index)
        {
            if (index < 0 || index >= _personsArray.Length)
            { 
                throw new IndexOutOfRangeException("Ошибка: индекс вне допустимого диапазона!");
            }
        }

        /// <summary>
        /// Метод удаления пользователей по индексу.
        /// </summary>
        /// <param name="index"></param>
        public void DeletePersonByIndex(int index) 
        { 
            CheckIndex(index);

            for (int i = index; i < _personsArray.Length - 1; i++)
            { 
                _personsArray[i] = _personsArray[i + 1];
            }

            Array.Resize(ref _personsArray, _personsArray.Length - 1);
        }

        /// <summary>
        /// Метод удаления пользователя по переданной персоне.
        /// </summary>
        /// <param name="person"></param>
        public void DeletePersonByPerson(Person person) 
        {
            // Определяем индекс первого вхождения пользователя в массиве
            int index = Array.IndexOf(_personsArray, person);

            DeletePersonByIndex(index);
        }

        /// <summary>
        /// Метод поиска пользователей.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Person SearchPersons(int index) 
        {
            CheckIndex(index);
            return _personsArray[index];
        }

        /// <summary>
        /// Метод поиска индекса по пользователю.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Метод по подсчёту количества пользователей.
        /// </summary>
        /// <returns></returns>
        public int CountPersons() => _personsArray.Length;

    }
}
