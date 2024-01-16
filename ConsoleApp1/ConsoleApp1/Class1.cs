using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HydroGeneratorOptimization
{
    public class Class1
    {
        static void CreateListAndSaveToXML()
        {
            List<GeneratorFlow> generatorFlows = new List<GeneratorFlow>();

            // Заполнение списка
            for (int i = 1; i <= 12; i++)
            {
                generatorFlows.Add(new GeneratorFlow($"{i}", 555));
            }

            // Сохранение в XML-документ
            SaveXmlDocument("generatorFlows.xml", generatorFlows);

            Console.WriteLine("XML-документ успешно создан.");
        }

        static void SaveXmlDocument(string fileName, List<GeneratorFlow> generatorFlows)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();

                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDoc.AppendChild(xmlDeclaration);

                XmlNode root = xmlDoc.CreateElement("GeneratorFlows");
                xmlDoc.AppendChild(root);

                foreach (var generatorFlow in generatorFlows)
                {
                    XmlNode generatorNode = xmlDoc.CreateElement("GeneratorFlow");

                    XmlNode nameNode = xmlDoc.CreateElement("HU");
                    nameNode.InnerText = generatorFlow.Name;
                    generatorNode.AppendChild(nameNode);

                    XmlNode flowNode = xmlDoc.CreateElement("Flow");
                    flowNode.InnerText = generatorFlow.WaterFlow.ToString();
                    generatorNode.AppendChild(flowNode);

                    root.AppendChild(generatorNode);
                }

                xmlDoc.Save(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении XML: {ex.Message}");
            }
        }

        static List<GeneratorFlow> ReadXmlDocument(string fileName)
        {
            List<GeneratorFlow> readGeneratorFlows = new List<GeneratorFlow>();

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);

                XmlNodeList generatorNodes = xmlDoc.SelectNodes("//GeneratorFlow");

                foreach (XmlNode generatorNode in generatorNodes)
                {
                    XmlNode nameNode = generatorNode.SelectSingleNode("HU");
                    XmlNode flowNode = generatorNode.SelectSingleNode("Flow");

                    if (nameNode != null && flowNode != null)
                    {
                        string name = nameNode.InnerText;
                        double flow = double.Parse(flowNode.InnerText);

                        GeneratorFlow generatorFlow = new GeneratorFlow(name, flow);
                        readGeneratorFlows.Add(generatorFlow);
                    }
                    else
                    {
                        Console.WriteLine("XML-документ не содержит необходимых узлов 'HU' или 'Flow'.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении XML: {ex.Message}");
            }

            return readGeneratorFlows;
        }

        static void CheckXmlDocument(List<GeneratorFlow> generatorFlows, int expectedCount)
        {
            if (generatorFlows.Count != expectedCount)
            {
                throw new Exception($"Количество гидрогенераторов не соответствует ожидаемому. Ожидается: {expectedCount}, Фактическое: {generatorFlows.Count}");
            }
        }

        class GeneratorFlow
        {
            public string Name { get; set; }
            public double WaterFlow { get; set; }

            public GeneratorFlow(string name, double waterFlow)
            {
                Name = name;
                WaterFlow = waterFlow;
            }
        }
    }
}
