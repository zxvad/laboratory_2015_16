using EventoBackend.API.Interfaces;

namespace EventoBackend.API.Implementation
{
    public class Api
    {
        public IGroupController GroupController { get; set; }
        public IEventController EventController { get; set; }
    }
}