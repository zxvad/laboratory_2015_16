using System.Collections.Generic;
using EventoBackend.Entities;
using EventoBackend.Models;

namespace EventoBackend.Services.Implementation
{
    public class EventService : IEventService
    {
        public Event CreateEvent(User user, Group @group, EventModel model)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Event> GetEvents(EventFilter filter)
        {
            throw new System.NotImplementedException();
        }

        public Event GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}