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
        [DisplayName("ГА")]
        public string Name { get; set; }

        [DisplayName("Расход воды, м. куб/с")]
        public double WaterFlow { get; set; }

        [DisplayName("Загрузка, МВт")]
        public double PowerLoad { get; set; }

        [DisplayName("Статус")]
        public string Status { get; set; }
    }
}
