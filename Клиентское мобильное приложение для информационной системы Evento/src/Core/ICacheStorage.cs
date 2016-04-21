namespace Evento.Client.Core
{
    public interface ICacheStorage
    {
        void ResetCache();
        T Get<T>(byte[] objectHash);
        bool Store<T>(T obj);
    }
}