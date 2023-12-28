using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Пространство имён View.
/// </summary>
namespace View
{
    /// <summary>
    /// Класс событий.
    /// </summary>
    internal class TrainingListEventArgs : EventArgs
    {
        /// <summary>
        /// Список тренировок.
        /// </summary>
        public BindingList<Model.TrainingCalc> TrainingListValue { get; private set; }

        /// <summary>
        /// Конструктор события добавления в список тренировок.
        /// </summary>
        /// <param name="trainings"></param>
        public TrainingListEventArgs(BindingList<Model.TrainingCalc> trainings)
        {
            TrainingListValue = trainings;
        }
    }
}