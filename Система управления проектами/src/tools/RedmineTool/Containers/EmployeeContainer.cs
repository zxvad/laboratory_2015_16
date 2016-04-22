using System.Collections.Generic;
using RedmineTool.Models;
using Newtonsoft.Json;

namespace RedmineTool.Containers
{
    internal class EmployeeContainer
    {
        public RedmineEmployee Employee { get; set; }
    }

    internal class EmployeesContainer : CollectionContainer
    {
        [JsonProperty("users")]
        public IEnumerable<RedmineEmployee> Employees { get; set; } 
    }
}