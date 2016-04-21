namespace Evento.Client
{
    public interface IPushNotificator
    {
        bool Push(string message);
    }
}