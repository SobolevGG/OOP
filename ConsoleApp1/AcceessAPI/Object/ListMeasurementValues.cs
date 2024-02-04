using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using System;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AcceessAPI.Object
{
    public class ListMeasurementValues
    {
        private List<ValuesMeasurement> _listMeasurement;

        /// <summary>
        /// Список измерений
        /// </summary>
        [Newtonsoft.Json.JsonProperty("value")]
        public List<ValuesMeasurement> ListMeasurement
        {
            get { return _listMeasurement; }
            set { _listMeasurement = value; }
        }

        public List<string> ToListString()
        {
            List<string> listValues = new List<string>();

            foreach (ValuesMeasurement value in ListMeasurement)
            {
                string valueString = value.ToStringDateAndValue();
                listValues.Add(valueString);
            }
            return listValues;
        }
    };

    [XmlRoot("RootElement", Namespace = "", IsNullable = false)]
    [Serializable]
    public class Measure
    {
        [XmlElement("Row")]
        public List<string> Strings { get; set; }
    }

}
