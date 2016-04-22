using System.Collections.Generic;
using EventoBackend.API.Interfaces;
using EventoBackend.Models;
using EventoBackend.Services;
using EventoBackend.Services.Implementation;
using EventoBackend.Services.Interfaces;

namespace EventoBackend.API.Implementation
{
    public class EventController : IEventController
    {
        private IEventService _eventService;
        private IParticipantService _participantService;
        private IGroupService _groupService;

        public EventController(IEventService eventService, IParticipantService participantService, IGroupService groupService)
        {
            _eventService = eventService;
            _participantService = participantService;
            _groupService = groupService;
        }

        public Answer CreateEvent(EventModel model)
        {
            var user = _participantService.GetById(model.CreatedUserId);
            var group = _groupService.GetById(model.GroupId);
            var res = _eventService.CreateEvent(user, group, model);
            return new Answer() {Success = res != null};
        }

        public IEnumerable<Event> FindEvents(EventFilter filter)
        {
            return _eventService.GetEvents(filter);
        }

        public Answer RegistrationOnEvent(int userId, int eventId)
        {
            var user = _participantService.GetById(userId);
            var @event = _eventService.GetById(eventId);
            var res = _participantService.AddInEvent(user, @event);
            return new Answer() { Success = res};
        }

        public IEnumerable<Event> GetUserEvents(int userId)
        {
            return new List<Event>();
        }
    }
}