using System.Collections.Generic;

namespace EventoBackend.DB.Interfaces
{
    public interface IDataStorage<T>
    {
        IEnumerable<T> Load();
        void Save(T obj);
        void MakeBackup();
    }
}