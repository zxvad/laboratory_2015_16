using Newtonsoft.Json;
using RedmineTool.Interfaces;

namespace RedmineTool.Serializers
{
    public class JsonSerializer : ISerializer
    {
        public string Serialize(object source)
        {
            return JsonConvert.SerializeObject(source);
        }

        public T Deserialize<T>(string source)
        {
            return JsonConvert.DeserializeObject<T>(source);
        }
    }
}