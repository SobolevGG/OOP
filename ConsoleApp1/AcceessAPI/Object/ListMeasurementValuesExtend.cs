using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using System;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AcceessAPI.Object
{
    public class ListMeasurementValuesExtend
    {
        private List<ValuesMeasurementExtend> _listMeasurement;

        /// <summary>
        /// Список измерений
        /// </summary>
        [Newtonsoft.Json.JsonProperty("value")]
        public List<ValuesMeasurementExtend> ListMeasurement
        {
            get { return _listMeasurement; }
            set { _listMeasurement = value; }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public ListMeasurementValuesExtend()
        {
            _listMeasurement = new List<ValuesMeasurementExtend>();
        }

        public List<string> ToListString()
        {
            List<string> listValues = [];

            foreach (ValuesMeasurementExtend value in ListMeasurement)
            {
                string valueString = value.ToString();
                // string valueString = value.ToStringDateAndValue();
                listValues.Add(valueString);
            }

            return listValues;
        }
    };

    [XmlRoot("RootElement", Namespace = "", IsNullable = false)]
    [Serializable]
    public class MeasureExtend
    {
        [XmlElement("Row")]
        public List<string> Strings { get; set; }
    }

}
