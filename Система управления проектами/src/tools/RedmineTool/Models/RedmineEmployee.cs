using System;
using Newtonsoft.Json;

namespace RedmineTool.Models
{
    public class RedmineEmployee : RedmineBase
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Status { get; set; }

        [JsonProperty("created_on")]
        public DateTime CreatedOn { get; set; }

        [JsonProperty("last_login_on")]
        public DateTime LastLoginOn { get; set; }

        [JsonProperty("api_key")]
        public string ApiKey { get; set; }

        [JsonProperty("mail")]
        public string Email { get; set; }
    }
}