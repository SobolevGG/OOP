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
            set { _HU = ValidateHU(value); }
        }

        public double Load
        {
            get { return _load; }
            set { _load = ValidateLoad(value); }
        }

        public int Zone
        {
            get { return _zone; }
            set { _zone = ValidateZone(value); }
        }

        public string Status
        {
            get { return _status; }
            set { _status = ValidateStatus(value); }
        }

        // Методы для проверки и установки значений по умолчанию
        private string ValidateHU(string value)
        {
            return !string.IsNullOrEmpty(value) ? value : "defaultHU";
        }

        private double ValidateLoad(double value)
        {
            return (value >= 0 && value <= 508) ? value : 0;
        }

        private int ValidateZone(int value)
        {
            return (value == 1 || value == 3) ? value : 1;
        }

        private string ValidateStatus(string value)
        {
            // Допустим, что "В работе" - это значение по умолчанию
            return value == "Выведен" ? "Выведен" : "В работе";
        }
    }
}
