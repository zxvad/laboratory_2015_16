using System.Collections.Generic;
using EventoBackend.API.Interfaces;
using EventoBackend.Services;
using EventoBackend.Services.Interfaces;

namespace EventoBackend.API.Implementation
{
    public class GroupController : IGroupController
    {
        private IEventService _eventService;
        private IParticipantService _participantService;
        private IGroupService _groupService;

        public GroupController(IEventService eventService, IParticipantService participantService, IGroupService groupService)
        {
            _eventService = eventService;
            _participantService = participantService;
            _groupService = groupService;
        }

        public Answer CreateGroup(GroupModel model)
        {
            var user = _participantService.GetById(model.UserId);
            var entity = _groupService.CreateGroup(user, model);
            return new Answer() {Success = entity != null};
        }

        public IEnumerable<Group> FindGroups(GroupFilter filter)
        {
            return _groupService.GetGroups(filter);
        }

        public IEnumerable<Group> GetUserGroups(int userId)
        {
            return new List<Group>();
        }
    }
}