using Model;
using System.Xml.Serialization;

namespace ConsoleAppNew
{
    [Serializable]
    [XmlRoot("Generator")]
    public class Generator
    {
        /// <summary>
        /// Идентификатор генератора.
        /// </summary>
        public Guid UID { get; set; }

        /// <summary>
        /// Список пар времени и мощности для генератора.
        /// </summary>
        [XmlArray("GeneratorsLoadList")]
        [XmlArrayItem("GeneratorsLoad")]
        public List<GeneratorsLoad> GeneratorsLoadList { get; set; }

        public Generator()
        {
            GeneratorsLoadList = new List<GeneratorsLoad>();
        }


    }

    public class GeneratorsLoad
    {
        [XmlElement("TimeStamp")]
        public DateTime TimeStamp { get; set; }

        [XmlElement("Load")]
        public double Load { get; set; }
    }
}