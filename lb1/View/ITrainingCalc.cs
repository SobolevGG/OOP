using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace View
{
    /// <summary>
    /// Интерфейс для добавления тренировки.
    /// </summary>
    internal interface ITrainingCalc
    {
        /// <summary>
        /// Метод для добавления заработной платы.
        /// </summary>
        /// <returns></returns>
        public abstract Model.TrainingCalc AddingCalc();
    }
}