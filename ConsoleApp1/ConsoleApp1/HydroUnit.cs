using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class HydroUnit
    {
        private string name;
        private double waterFlow;
        private double powerLoad;
        private string status;

        [DisplayName("ГА")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DisplayName("Расход воды, м. куб/с")]
        public double WaterFlow
        {
            get { return waterFlow; }
            set
            {
                if (value >= 0)
                {
                    waterFlow = value;
                }
                else
                {
                    throw new ArgumentException("Расход воды не может быть отрицательным.");
                }
            }
        }

        [DisplayName("Загрузка, МВт")]
        public double PowerLoad
        {
            get { return powerLoad; }
            set
            {
                if (value >= 0 && value <= 508)
                {
                    powerLoad = value;
                }
                else
                {
                    throw new ArgumentException("Загрузка должна быть в диапазоне от 0 до 508 МВт.");
                }
            }
        }

        [DisplayName("Статус")]
        public string Status
        {
            get { return status; }
            set
            {
                if (value == "В работе" || value == "Выведен")
                {
                    status = value;
                }
                else
                {
                    throw new ArgumentException("Статус должен быть 'В работе' или 'Выведен'.");
                }
            }
        }
    }
}
