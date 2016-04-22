using System;
using System.Collections.Generic;
using System.Linq;
using EventoBackend.DB.Implementation;
using EventoBackend.Entities;

namespace EventoBackend.Services.Implementation
{
    public class GroupService : IGroupService
    {
        private GroupStorage _groupStorage;
        private GroupService _groupService;

        public GroupService(GroupStorage groupStorage, GroupService groupService)
        {
            _groupStorage = groupStorage;
            _groupService = groupService;
        }

        public Group CreateGroup(User user, GroupModel model)
        {
            var countGroupToday = user.CreatedEventId
                .Select(id => _groupService.GetById(id))
                .Count(e => e.CreatedTIme > DateTime.Today.AddDays(-1));

            if (countGroupToday >= 10) return null;

            var group = new Group() {Name = model.Name, Description = model.Description, CreatedTIme = DateTime.Now, OwnerId = user.Id, Picture = model.Picture};
            _groupStorage.Save(group);
            return group;
        }

        public IEnumerable<Group> GetGroups(GroupFilter filter)
        {
            return _groupService.GetGroups(filter);
        }

        public Group GetById(int id)
        {
            return _groupService.GetById(id);
        }
    }
}