using System.Collections.Generic;
using EventoBackend.DB.Interfaces;

namespace EventoBackend.DB.Implementation
{
    public class EventStorage : IDataStorage<Event>
    {
        public IEnumerable<Event> Load()
        {
            throw new System.NotImplementedException();
        }

        public void Save(Event obj)
        {
            throw new System.NotImplementedException();
        }

        public void MakeBackup()
        {
            throw new System.NotImplementedException();
        }
    }
}