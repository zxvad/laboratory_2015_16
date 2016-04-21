namespace Evento.Client.Core
{
    public interface IAuthentificator
    {
        bool Validate(string login, byte[] passwordHash);
        bool Authentificate(string login, byte[] passwordHash);
    }
}