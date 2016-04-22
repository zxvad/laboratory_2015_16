using System;
using System.Collections.Generic;
using System.Linq;
using EventoBackend.DB.Implementation;
using EventoBackend.Entities;
using EventoBackend.Models;

namespace EventoBackend.Services.Implementation
{
    public class EventService : IEventService
    {
        private IEventService _eventService;
        private EventStorage _eventStorage;

        public EventService(IEventService eventService, EventStorage eventStorage)
        {
            _eventService = eventService;
            _eventStorage = eventStorage;
        }

        public Event CreateEvent(User user, Group @group, EventModel model)
        {
            var countEventToday = user.CreatedEventId
                .Select(id => _eventService.GetById(id))
                .Count(e => e.CreatedTIme > DateTime.Today.AddDays(-1));
            if (countEventToday >= 10) return null;
            var @event = new Event()
            {
                Name = model.Name,
                CreatedTIme = DateTime.Now,
                Description = model.Description,
                EndTime = model.EndTime,
                PlaceName = model.PlaceName,
                StartTime = model.StartTime
            };
            _eventStorage.Save(@event);
            return @event;
        }

        public IEnumerable<Event> GetEvents(EventFilter filter)
        {
            return _eventService.GetEvents(filter);
        }

        public Event GetById(int id)
        {
            return _eventService.GetById(id);
        }
    }
}