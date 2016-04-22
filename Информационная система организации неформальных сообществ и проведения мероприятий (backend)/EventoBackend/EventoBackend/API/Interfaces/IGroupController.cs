using System.Collections.Generic;
using EventoBackend.API.Implementation;

namespace EventoBackend.API.Interfaces
{
    public interface IGroupController
    {
        Answer CreateGroup(GroupModel model);
        IEnumerable<Group> FindGroups(GroupFilter filter);
        IEnumerable<Group> GetUserGroups(int userId);
    }
}