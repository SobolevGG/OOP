using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    internal class TrainingEventArgs
    {
        /// <summary>
        /// Отправка значения.
        /// </summary>
        public TrainingCalc TrainingValue { get; private set; }

        /// <summary>
        /// Конструктор для передачи значения.
        /// </summary>
        /// <param name="sendingValue">Передача.</param>
        public TrainingEventArgs(TrainingCalc trainingValue)
        {
            TrainingValue = trainingValue;
        }
    }
}
