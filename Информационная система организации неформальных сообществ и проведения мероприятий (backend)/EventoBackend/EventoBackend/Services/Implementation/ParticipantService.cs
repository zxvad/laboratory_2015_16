using System;
using System.Linq;
using EventoBackend.DB.Implementation;
using EventoBackend.Entities;
using EventoBackend.Services.Interfaces;

namespace EventoBackend.Services.Implementation
{
    public class ParticipantService : IParticipantService
    {
        private UserStorage _userStorage;
        private IGroupService _groupService;
        private IParticipantService _participantService;

        public ParticipantService(UserStorage userStorage, IParticipantService participantService, IGroupService groupService)
        {
            _userStorage = userStorage;
            _participantService = participantService;
            _groupService = groupService;
        }

        public bool AddInGroup(User user, Group @group)
        {
            var count = user.GroupIds
                .Select(id => _groupService.GetById(id))
                .Count(g => g.CreatedTIme > DateTime.Today.AddDays(-1));
            return count <= 10;
        }

        public bool AddInEvent(User user, Event @event)
        {
            user.CreatedEventId.ToList().Add(@event.Id);
            return true;
        }

        public User GetAllUsersGroup(Group @group)
        {
           return _participantService.GetAllUsersGroup(group);
        }

        public User GetUsersInEvent(Event @event)
        {
            return _participantService.GetUsersInEvent(@event);
        }

        public User GetById(int id)
        {
            return _participantService.GetById(id);
        }
    }
}