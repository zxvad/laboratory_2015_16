using EventoBackend.Entities;
using EventoBackend.Services.Interfaces;

namespace EventoBackend.Services.Implementation
{
    public class ParticipantService : IParticipantService
    {
        public bool AddInGroup(User user, Group @group)
        {
            throw new System.NotImplementedException();
        }

        public bool AddInEvent(User user, Event @event)
        {
            throw new System.NotImplementedException();
        }

        public User GetAllUsersGroup(Group @group)
        {
            throw new System.NotImplementedException();
        }

        public User GetUsersInEvent(Event @event)
        {
            throw new System.NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}