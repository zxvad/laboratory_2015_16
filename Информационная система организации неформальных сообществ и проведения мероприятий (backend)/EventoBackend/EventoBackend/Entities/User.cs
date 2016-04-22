using System.Collections.Generic;

namespace EventoBackend.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<int> GroupIds { get; set; }
        public IEnumerable<int> RegOnEventIds { get; set; } 
        public IEnumerable<int> CreatedEventId { get; set; } 
    }
}