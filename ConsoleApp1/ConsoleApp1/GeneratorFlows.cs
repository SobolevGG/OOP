using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
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

        public static double[] CheckWaterFlows(GeneratorFlows generatorFlows, int expectedGeneratorsCount)
        {
            if (generatorFlows == null || generatorFlows.Flows == null)
            {
                throw new Exception("Ошибка загрузки потоков генератора из XML.");
            }

            if (generatorFlows.Flows.Count != expectedGeneratorsCount)
            {
                throw new Exception($"Неверное количество гидрогенераторов. Ожидалось {generatorFlows.Flows.Count}, получено {expectedGeneratorsCount} из документа XML.");
            }

            double[] waterFlows = new double[expectedGeneratorsCount];

            for (int i = 0; i < expectedGeneratorsCount; i++)
            {
                var generatorFlow = generatorFlows.Flows[i];
                // Допускается, что значение расхода воды может быть равно 0
                if (generatorFlow == null || generatorFlow.WaterFlow < 0)
                {
                    throw new Exception($"Отсутствует или некорректное значение расхода воды для гидрогенератора {i + 1}.");
                }

                waterFlows[i] = generatorFlow.WaterFlow;
            }

            return waterFlows;
        }
    }
}
