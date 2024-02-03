using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    // Класс для хранения данных
    [Serializable]
    public class DataItem
    {
        public string GU { get; set; }
        public double Load { get; set; }
        public int Zone { get; set; }
        public string Status { get; set; }
    }
}
