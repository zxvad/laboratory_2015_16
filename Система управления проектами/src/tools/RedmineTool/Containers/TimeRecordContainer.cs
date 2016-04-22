using System.Collections.Generic;
using Newtonsoft.Json;
using RedmineTool.Models;

namespace RedmineTool.Containers
{
    internal class TimeRecordContainer
    {
        [JsonProperty("time_entry")]
        public RedmineTimeRecord TimeRecord { get; set; }
    }

    internal class TimeRecordsContainer : CollectionContainer
    {
        [JsonProperty("time_entries")]
        public IList<RedmineTimeRecord> TimeRecords { get; set; }
    }
}