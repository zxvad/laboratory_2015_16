using System;

namespace Evento.Client.EventoApiClient
{
    public interface IEventoClient
    {
        TObject SafeExecute<TObject>(Func<TObject> executeFunc) where TObject : class, new();
    }
}