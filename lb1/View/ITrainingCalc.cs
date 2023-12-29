using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

/// <summary> 
/// Пространство имён View.
/// </summary>
namespace View
{
    /// <summary>
    /// Интерфейс для добавления тренировки.
    /// </summary>
    internal interface ITrainingCalc
    {
        /// <summary>
        /// Метод для добавления тренировки.
        /// </summary>
        /// <returns></returns>
        public abstract Model.TrainingCalc AddingCalc();
    }
}