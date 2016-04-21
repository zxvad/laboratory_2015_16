using System.Collections.Generic;

namespace EventoBackend.Services
{
    public interface IEventService
    {
        Event CreateEvent(User user, Group @group, EventModel model);
        IEnumerable<Event> GetEvents(EventFilter filter);
        Event GetById(int id);
    }
}