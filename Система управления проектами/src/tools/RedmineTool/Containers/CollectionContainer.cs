using Newtonsoft.Json;

namespace RedmineTool.Containers
{
    public class CollectionContainer
    {
        public int Offset { get; set; }
        public int Limit { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }
    }
}