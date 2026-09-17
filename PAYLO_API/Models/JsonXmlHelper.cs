using System.Text.Json;
using System.Xml.Serialization;

namespace PAYLO_API.Models
{
    public static class JsonXmlHelper
    {
        public static string ObjectToXml<T>(T obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, obj);
                return textWriter.ToString();
            }
        }
        public static string ObjectToJson<T>(T obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        public static string XmlToJson<T>(string xmlData)
        {
            T returnValue = default(T);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringReader textReader = new StringReader(xmlData))
            {
                returnValue = (T)xmlSerializer.Deserialize(textReader);
            }
            return XmlToJson(returnValue);
        }

        public static string XmlToJson<T>(T obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        public static List<T> JsonToList<T>(string jsonData)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(jsonData);
        }
    }
}
