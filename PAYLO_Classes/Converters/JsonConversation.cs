using System.Text.Json.Serialization;
using System.Text.Json;

namespace PAYLO_Classes
{
    public static class JsonConversation
    {
        public static string SerializeWithStringEnum(object obj)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new JsonStringEnumConverter());
            string value = JsonSerializer.Serialize(obj, options).TrimEnd('"').TrimStart('"');
            return value;
        }
    }
}
