using EventoBackend.Entities;

namespace EventoBackend.Services
{
    public interface IParticipantService
    {
        bool AddInGroup(long userId, long groupId);
        bool AddInEvent(long userId, long eventId);
        User GetAllUsersGroup(long groupId);
        User GetUsersInEvent(long eventId);
    }
}