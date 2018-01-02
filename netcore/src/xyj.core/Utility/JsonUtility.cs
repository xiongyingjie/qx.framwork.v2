using Newtonsoft.Json;

namespace xyj.core.Utility
{
    public class JsonUtility
    {
        public static string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T Deserialize<T>(string jsonString)
        {
            if (string.IsNullOrEmpty(jsonString))
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static T Deserialize<T>(string jsonString, JsonSerializerSettings jsonSerializerSettings)
        {
            if (string.IsNullOrEmpty(jsonString))
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(jsonString, jsonSerializerSettings);
        }
    }
}