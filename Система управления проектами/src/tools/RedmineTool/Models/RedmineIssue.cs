using System;
using Newtonsoft.Json;

namespace RedmineTool.Models
{
    public class RedmineIssue : RedmineBase
    {
        public RedmineIdNameObject Project { get; set; }
        public RedmineIdNameObject Priority { get; set; }
        public RedmineIdNameObject Status { get; set; }
        public RedmineIdNameObject Author { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }

        [JsonProperty("fixed_version")]
        public RedmineIdNameObject ProjectVersion { get; set; }

        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        [JsonProperty("closed_on")]
        public DateTime ClosedOn { get; set; }

        [JsonProperty("assigned_to")]
        public RedmineIdNameObject AssignedTo { get; set; }
    }
}