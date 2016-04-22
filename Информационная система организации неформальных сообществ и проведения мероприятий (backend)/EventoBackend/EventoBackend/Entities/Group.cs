using System;

namespace EventoBackend
{
    public class Group
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTIme { get; set; }
    }
}