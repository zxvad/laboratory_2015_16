using Newtonsoft.Json;

namespace RedmineTool.Models
{
    public class RedmineIssueStatus : RedmineBase
    {
        public string Name { get; set; }

        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }

        [JsonProperty("is_closed")]
        public bool IsClosed { get; set; }
    }
}