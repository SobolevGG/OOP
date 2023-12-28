using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Пространство имён View.
/// </summary>
namespace View
{
    /// <summary>
    /// Класс аргумента для передачи данных о тренировке.
    /// </summary>
    public class TrainingEventArgs : EventArgs
    {
        /// <summary>
        /// Отправка значения.
        /// </summary>
        public Model.TrainingCalc Value { get; private set; }

        /// <summary>
        /// Конструктор для передачи значения.
        /// </summary>
        /// <param name="sendingValue">Передача.</param>
        public TrainingEventArgs(Model.TrainingCalc Value)
        {
            Value = Value;
        }
    }
}