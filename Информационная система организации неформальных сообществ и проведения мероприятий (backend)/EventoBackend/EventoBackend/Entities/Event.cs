using System;

namespace EventoBackend
{
    public class Event
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreatedTIme { get; set; }
        public string PlaceName { get; set; }
        public int GroupId { get; set; }
    }
}