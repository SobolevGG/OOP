using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    // Класс для хранения данных
    [Serializable]
    public class ParametersHU
    {
        private string _HU;
        private double _load;
        private int _zone;
        private string _status;

        public string HU
        {
            get { return _HU; }
            set { _HU = !string.IsNullOrEmpty(value) ? value : "defaultHU"; }
        }

        public double Load
        {
            get { return _load; }
            set { _load = (value >= 0 && value <= 508) ? value : 0; }
        }

        public int Zone
        {
            get { return _zone; }
            set { _zone = (value == 1 || value == 3) ? value : 1; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = (value == "Выведен") ? "Выведен" : "В работе"; }
        }
    }
}
