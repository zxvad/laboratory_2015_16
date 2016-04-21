using System;
using Evento.Client.EventoApiClient;

namespace Evento.Client.Implementation
{
    public class EventoClient : IEventoClient
    {
        private const int AttemptsCount = 3;

        public TObject SafeExecute<TObject>(Func<TObject> executeFunc) where TObject : class, new()
        {
            if (executeFunc == null)
            {
                throw new ArgumentNullException();
            }

            for (var i = 1; i <= AttemptsCount; i++)
            {
                try
                {
                    return executeFunc();
                }
                catch
                {
                    if (i < AttemptsCount)
                        continue;
                    return null;
                }
            }

            return null;
        }
    }
}