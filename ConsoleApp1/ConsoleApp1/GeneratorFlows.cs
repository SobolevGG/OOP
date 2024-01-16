using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HydroGeneratorOptimization
{
    [Serializable]
    public class GeneratorFlows
    {
        public string Name { get; set; }
        public double Flow { get; set; }
    }
}
