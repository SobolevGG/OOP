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

        //TODO(+): rename
        /// <summary>
        /// Метод добавления пользователей.
        /// </summary>
        /// <param name="person">Пользователь.</param>
        public void Add(Person person) 
        {
            var newPersonsIndex = _personsArray.Length;
            Array.Resize(ref _personsArray, newPersonsIndex + 1);
            _personsArray[newPersonsIndex] = person;
        }

        /// <summary>
        /// Метод проверки допустимости значения индекса.
        /// </summary>
        /// <param name="index">Индекс пользователя.</param>
        /// <exception cref="IndexOutOfRangeException">Исключение по допустимому диапазону.</exception>
        private void CheckIndex(int index)
        {
            if (index < 0 || index >= _personsArray.Length)
            { 
                throw new IndexOutOfRangeException("Ошибка: " +
                    "индекс вне допустимого диапазона!");
            }
        }

        // TODO(+): rename
        /// <summary>
        /// Метод удаления пользователей по индексу.
        /// </summary>
        /// <param name="index">Индекс пользователя.</param>
        public void Delete(int index) 
        { 
            CheckIndex(index);

            for (int i = index; i < _personsArray.Length - 1; i++)
            { 
                _personsArray[i] = _personsArray[i + 1];
            }

            Array.Resize(ref _personsArray, _personsArray.Length - 1);
        }

        // TODO(+): rename
        /// <summary>
        /// Метод удаления пользователя по переданной персоне.
        /// </summary>
        /// <param name="person">Пользователь.</param>
        public void DeletePerson(Person person) 
        {
            // Определяем индекс первого вхождения пользователя в массиве
            int index = Array.IndexOf(_personsArray, person);
            if (index == -1) 
            {
                throw new ArgumentException("Переданная персона " +
                    "отсутствует в массиве!");
            }
            Delete(index);
        }

        // TODO(+): rename
        /// <summary>
        /// Метод поиска пользователей.
        /// </summary>
        /// <param name="index">Индекс пользователя.</param>
        /// <returns>Пользователь по индексу.</returns>
        public Person Search(int index)
        {
            CheckIndex(index);
            return _personsArray[index];
        }

        /// <summary>
        /// Метод поиска индекса по пользователю.
        /// </summary>
        /// <param name="person">Пользователь.</param>
        /// <returns>Индекс пользователя.</returns>
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
        public void Clear()
        {
            Array.Resize(ref _personsArray, 0);
        }

        // TODO(+): rename
        /// <summary>
        /// Метод по подсчёту количества пользователей.
        /// </summary>
        /// <returns>Количество пользователей.</returns>
        public int Count() => _personsArray.Length;

    }
}
