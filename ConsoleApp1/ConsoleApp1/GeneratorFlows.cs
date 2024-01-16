using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HydroGeneratorOptimization
{
    [Serializable]
    [XmlRoot("GeneratorFlows")]
    public class GeneratorFlows
    {
        [XmlElement("GeneratorFlow")]
        public List<GeneratorFlow> Flows { get; set; }
    }

    [Serializable]
    public class GeneratorFlow
    {
        [XmlElement("HU")]
        public string Name { get; set; }

        [XmlElement("Flow")]
        public double WaterFlow { get; set; }
    }
}
