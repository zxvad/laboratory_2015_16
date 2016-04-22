using System;
using Newtonsoft.Json;

namespace RedmineTool.Models
{
    public class RedmineProject : RedmineBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonProperty("created_on")]
        public DateTime CreatedOn { get; set; }
    }
}