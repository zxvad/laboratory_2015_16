using Evento.Client.Core;
using Evento.Client.EventoApiClient;

namespace Evento.Client
{
    public interface IInterface
    {
    }

    class Interface : IInterface
    {
        private readonly IAuthentificator authentificator;
        private readonly ICacheStorage cacheStorage;
        private readonly IEventoClient eventoClient;

        public Interface(IAuthentificator authentificator, ICacheStorage cacheStorage, IEventoClient eventoClient)
        {
            this.authentificator = authentificator;
            this.cacheStorage = cacheStorage;
            this.eventoClient = eventoClient;
        }
    }
}