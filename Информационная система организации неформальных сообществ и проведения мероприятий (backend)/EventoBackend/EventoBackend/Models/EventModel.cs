using System;

namespace EventoBackend.Models
{
    public class EventModel
    {
        public int CreatedUserId { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string PlaceName { get; set; }
    }
}