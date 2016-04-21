using System.Collections.Generic;

namespace EventoBackend.Services
{
    public interface IGroupService
    {
        Group CreateGroup(User user, GroupModel model);
        IEnumerable<Group> GetGroups(GroupFilter filter); 
        Group GetById(int id);
    }
}