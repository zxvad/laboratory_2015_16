using System.Collections.Generic;

namespace EventoBackend
{
    public class User
    {
        public string Name { get; set; }
        public IEnumerable<int> Groups { get; set; }
    }
}