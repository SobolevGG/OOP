using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System;
using System.IO;

namespace Model
{
    public class XmlFileManager<T>
    {
        public void Save(string fileName, T data)
        {
            try
            {
                using (var streamWriter = new StreamWriter(fileName))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(streamWriter, data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data to {fileName}: {ex.Message}");
            }
        }

        public T Load(string fileName)
        {
            T data;

            try
            {
                using (var streamReader = new StreamReader(fileName))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    data = (T)serializer.Deserialize(streamReader);
                }
            }
            catch
            {
                data = default(T);
            }

            return data;
        }
    }
}
