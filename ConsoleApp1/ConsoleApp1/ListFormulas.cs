using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HydroGeneratorOptimization.Formulas;

namespace HydroGeneratorOptimization
{
    public class ListFormulas
    {
        /// <summary>
        /// Создание нового документа и ввод новой формулы.
        /// </summary>
        public static void CreateNewListAndAddForm(string formulaExpression, string nameFormula)
        {
            string newFormulaExpression = formulaExpression;

            var powerFormulaFileManager = new XmlFileManager<List<PowerFormula>>();

            // Создание нового списка формул
            List<PowerFormula> powerFormulas = new List<PowerFormula>();

            // Добавление новой формулы в список
            PowerFormula newFormula = new PowerFormula
            {
                Name = nameFormula, // Вы можете выбрать любое уникальное имя
                FormulaExpression = newFormulaExpression
            };

            powerFormulas.Add(newFormula);

            // Сохранение списка формул в XML-файл
            powerFormulaFileManager.Save("newFormulas.xml", powerFormulas);
        }

        /// <summary>
        /// Ввод новой формулы в список.
        /// </summary>
        public static void AddInListNewForm(string newFormulaExpression, string nameNewFormula)
        {
            // Создаем экземпляр XmlFileManager для List<PowerFormula>
            var powerFormulaFileManager = new XmlFileManager<List<PowerFormula>>();

            // Загрузка файла формул
            List<PowerFormula> powerFormulas = powerFormulaFileManager.Load("formulas.xml");

            // Добавление новой формулы в список
            PowerFormula newFormula = new PowerFormula
            {
                Name = nameNewFormula, // Вы можете выбрать любое уникальное имя
                FormulaExpression = newFormulaExpression
            };

            powerFormulas.Add(newFormula);

            // Сохранение обновленного списка формул в XML-файл
            powerFormulaFileManager.Save("formulas.xml", powerFormulas);
        }

        /// <summary>
        /// Метод удаления формулы из списка и последующего сохранения в XML-документ.
        /// </summary>
        /// <param name="powerFormulas">Список формул.</param>
        /// <param name="index">Номер формулы.</param>
        public static void RemoveFormByNum(List<PowerFormula> powerFormulas, int index)
        {
            if (powerFormulas != null && index > 0 && index <= powerFormulas.Count)
            {
                powerFormulas.RemoveAt(index - 1);

                // Сохранение обновленного списка формул в XML-файл
                var powerFormulaFileManager = new XmlFileManager<List<PowerFormula>>();
                powerFormulaFileManager.Save("formulas.xml", powerFormulas);
            }
            else
            {
                Console.WriteLine("Недопустимый индекс или список формул имеет значение null.");
            }
        }
    }
}
