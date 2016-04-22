using System.Collections.Generic;
using EventoBackend.DB.Interfaces;
using EventoBackend.Entities;

namespace EventoBackend.DB.Implementation
{
    public class UserStorage : IDataStorage<User>
    {
        public IEnumerable<User> Load()
        {
            throw new System.NotImplementedException();
        }

        public void Save(User obj)
        {
            throw new System.NotImplementedException();
        }

        public void MakeBackup()
        {
            throw new System.NotImplementedException();
        }
    }
}