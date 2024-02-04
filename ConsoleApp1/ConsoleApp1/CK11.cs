using Model;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Xml.Serialization;
using AcceessAPI.AccessAPI_CK11;
using AcceessAPI.Object;

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

    public class RequestGenerator
    {
        private string[] Uids;
        private string VersionAccess;
        private string VersionMeasure;
        private string TypeMeasurement;
        private string NameServer;

        public void GenerateRequests()
        {
            string fileName = "RequestGenLoad.json";
            string jsonString = File.ReadAllText(fileName);
            MyProperties? properties = JsonConvert.DeserializeObject<MyProperties>(jsonString);

            Uids = properties.UIDs;
            VersionAccess = properties.VersionAccess;
            VersionMeasure = properties.VersionMeasure;
            TypeMeasurement = properties.TypeMeasure;
            NameServer = properties.NameServer;

            SettingAccessAPI setting = new(NameServer, VersionAccess);
            SettingMeasurementAPI settingMeasure = new(NameServer, VersionMeasure);

            AccessMesuremetValues measure = new(Uids, setting, settingMeasure, TypeMeasurement);

            AccessRequestToken accessToken = new AccessRequestToken(setting);
            AccessAddressesAPI accessAdresses = new(setting);
            accessAdresses.GetAddressesAPI();
            AcceessAPI.Object.Token _token = accessToken.GetToken().Result;

            // ListMeasurementValues a = measure.ListMeasurementValues;
            ListMeasurementValuesExtend a = measure.ListMeasurementValuesExtend;

            List<string> list = a.ToListString();

            // Создание экземпляра XmlFileManager для List<Generator>
            var generatorDataFileManager = new XmlFileManager<List<Generator>>();

            // Создание нового списка Generator
            List<Generator> generatorsDataList = new List<Generator>();

            foreach (var value in a.ListMeasurement)
            {
                // Создание нового объекта Generator
                var generatorData = new Generator
                {
                    UID = value.UID,
                    GeneratorsLoadList = new List<GeneratorsLoad>()
                };

                foreach (var item in value.Value)
                {
                    // Внесение пары времени и мощности для текущего генератора
                    generatorData.GeneratorsLoadList.Add(new GeneratorsLoad
                    {
                        TimeStamp = item.TimeStamp,
                        Load = item.Value
                    });
                }

                generatorsDataList.Add(generatorData);
            }

            // Метод Save для сохранения данных в XML-документ
            generatorDataFileManager.Save("generatorsLoad.xml", generatorsDataList);
        }
    }
}