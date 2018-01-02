using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace xyj.core.Utility
{
    public class XmlUtility
    {
        public static string Serialize<T>(T obj)
        {
            using (var memoryStream = new MemoryStream())
            {
                var xmlSerializer = new XmlSerializer(typeof (T));
                var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8);
                xmlSerializer.Serialize(streamWriter, obj);

                memoryStream.Position = 0;
                var streamReader = new StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
        }

        public static T Deserialize<T>(string xmlString)
        {
            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xmlString)))
            {
                var xmlSerializer = new XmlSerializer(typeof (T));
                return (T) xmlSerializer.Deserialize(memoryStream);
            }
        }
    }
}