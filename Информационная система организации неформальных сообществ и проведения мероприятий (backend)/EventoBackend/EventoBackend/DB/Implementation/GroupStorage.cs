using System.Collections.Generic;
using EventoBackend.DB.Interfaces;

namespace EventoBackend.DB.Implementation
{
    public class GroupStorage : IDataStorage<Group>
    {
        public IEnumerable<Group> Load()
        {
            throw new System.NotImplementedException();
        }

        public void Save(Group obj)
        {
            throw new System.NotImplementedException();
        }

        public void MakeBackup()
        {
            throw new System.NotImplementedException();
        }
    }
}