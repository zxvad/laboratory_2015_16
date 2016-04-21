using Evento.Client.Core;

namespace Evento.Client.Implementation
{
    public class Authentificator : IAuthentificator
    {
        public bool Validate(string login, byte[] passwordHash)
        {
            return login != null && passwordHash?.Length > 0;
        }

        public bool Authentificate(string login, byte[] passwordHash)
        {
            return true;
        }
    }
}