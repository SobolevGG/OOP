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
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Значение не может быть пустым.", nameof(HU));
                }
                _HU = value;
            }
        }

        public double Load
        {
            get { return _load; }
            set
            {
                if (value < 0 || value > 508)
                {
                    throw new ArgumentOutOfRangeException(nameof(Load), "Значение должно быть в диапазоне от 0 до 508.");
                }
                _load = value;
            }
        }

        public int Zone
        {
            get { return _zone; }
            set
            {
                if (value != 1 && value != 3)
                {
                    throw new ArgumentException("Значение должно быть 1 или 3.", nameof(Zone));
                }
                _zone = value;
            }
        }

        public string Status
        {
            get { return _status; }
            set
            {
                if (value != "Выведен" && value != "В работе")
                {
                    throw new ArgumentException("Недопустимое значение для столбца 'Статус'.", nameof(Status));
                }
                _status = value;
            }
        }
    }
}
