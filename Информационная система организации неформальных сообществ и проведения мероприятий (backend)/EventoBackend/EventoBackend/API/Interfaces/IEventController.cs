using System.Collections.Generic;
using EventoBackend.API.Implementation;
using EventoBackend.Interfaces;
using EventoBackend.Models;

namespace EventoBackend.API.Interfaces
{
    public interface IEventController
    {
        Answer CreateEvent(EventModel model);
        IEnumerable<Event> FindEvents(EventFilter filter);
        Answer RegistrationOnEvent(int userId, int eventId);
        IEnumerable<Event> GetUserEvents(int userId);
    }
}