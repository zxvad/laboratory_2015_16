using System.Collections.Generic;

namespace EventoBackend.Interfaces
{
    public interface IController
    {
        Answer CreateGroup(GroupModel model);
        Answer CreateEvent(EventModel model);
        IEnumerable<Group> FindGroups(GroupFilter filter);
        IEnumerable<Event> FindEvents(EventFilter filter);
        Answer RegistrationOnEvent(int userId);
        IEnumerable<Event> GetUserEvents(int userId);
        IEnumerable<Group> GetUserGroups(int userId);
        
    }

    public class Answer
    {
        public bool Success { get; set; }
        public bool Description { get; set; }
    }
}