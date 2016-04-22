using EventoBackend.Entities;

namespace EventoBackend.Services.Interfaces
{
    public interface IParticipantService
    {
        bool AddInGroup(User user, Group group);
        bool AddInEvent(User user, Event @event);
        User GetAllUsersGroup(Group group);
        User GetUsersInEvent(Event @event);
        User GetById(int id);
    }
}