using System.Collections.Generic;

namespace EventoBackend.Entities
{
    public class User
    {
        public string Name { get; set; }
        public IEnumerable<int> GroupIds { get; set; }
        public IEnumerable<int> RegOnEventIds { get; set; } 
    }
}