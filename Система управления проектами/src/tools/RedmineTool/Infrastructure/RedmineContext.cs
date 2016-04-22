using System;

namespace RedmineTool.Infrastructure
{
    public class RedmineContext
    {
        public Uri HostUri { get; set; }
        public string ApiKey { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}