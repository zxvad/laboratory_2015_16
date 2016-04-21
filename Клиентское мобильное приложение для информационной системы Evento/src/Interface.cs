using Evento.Client.Core;
using Evento.Client.EventoApiClient;

namespace Evento.Client
{
    public class Interface : IInterface
    {
        private readonly IAuthentificator authentificator;
        private readonly ICacheStorage cacheStorage;
        private readonly IEventoClient eventoClient;
        private readonly ISettingsLoader settingsLoader;

        public Interface(IAuthentificator authentificator, ICacheStorage cacheStorage, IEventoClient eventoClient, ISettingsLoader settingsLoader)
        {
            this.authentificator = authentificator;
            this.cacheStorage = cacheStorage;
            this.eventoClient = eventoClient;
			this.settingsLoader = settingsLoader;
        }
    }
}