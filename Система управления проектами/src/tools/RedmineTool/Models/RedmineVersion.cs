using System;
using Newtonsoft.Json;

namespace RedmineTool.Models
{
    public class RedmineVersion : RedmineBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public RedmineIdNameObject Project { get; set; }

        [JsonProperty("created_on")]
        public DateTime CreatedOn { get; set; }
    }
}