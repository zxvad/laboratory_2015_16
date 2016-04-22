using System;
using Newtonsoft.Json;

namespace RedmineTool.Models
{
    public class RedmineTimeRecord : RedmineBase
    {
        public decimal Hours { get; set; }
        public string Comments { get; set; }

        public RedmineIdNameObject Project { get; set; }
        public RedmineIdNameObject User { get; set; }
        public RedmineIdNameObject Activity { get; set; }
        public RedmineIdNameObject Issue { get; set; }

        [JsonProperty("spent_on")]
        public DateTime SpentOn { get; set; }
    }
}