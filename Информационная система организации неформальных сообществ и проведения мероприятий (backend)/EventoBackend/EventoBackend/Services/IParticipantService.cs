namespace EventoBackend.Services
{
    public interface IParticipantService
    {
        bool AddInNewGroup(long userId, long groupId);
        User GetAllUsersGroup(long groupId);
        User GetUsersInEvent(long eventId);
    }
}