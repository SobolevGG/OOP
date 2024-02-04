using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcceessAPI.Object
{
    public class ValuesMeasurementExtend
    {
        private Guid _uid = Guid.Empty;
        private List<ValuesMeasurement> _value;

        /// <summary>
        /// UID
        /// </summary>
        [Newtonsoft.Json.JsonProperty("uid")]
        public Guid UID
        {
            get { return _uid; }
            set { _uid = value; }
        }

        /// <summary>
        /// Значение
        /// </summary>
        [Newtonsoft.Json.JsonProperty("value")]
        public List<ValuesMeasurement> Value
        {
            get { return _value; }
            set { _value = value; }
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="uid">UID.</param>
        /// <param name="value">Значение.</param>
        public ValuesMeasurementExtend()
        {
            _value = new List<ValuesMeasurement>();
        }

        //public override string ToString()
        //{
        //    return UID + " | " + TimeStamp.ToString("yyyy.MM.dd HH:mm:ss") + " | " + Value;
        //}

        //public string ToStringDateAndValue()
        //{
        //    DateTime newTime = TimeStamp.Add(new TimeSpan(0, 7, 0, 0));
        //    return $"DATETIME_GMT=\"{newTime}\" POTR_AO=\"{Value}\"";
        //}
    }
}
