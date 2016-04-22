namespace Evento.Client.Implementation
{
    public class ServerPushMessageObserver : IServerPushMessageObserver
    {
        private readonly IPushNotificator pushNotificator;

        public ServerPushMessageObserver(IPushNotificator pushNotificator)
        {
            this.pushNotificator = pushNotificator;
        }

        public void LookForMessages()
        {
            //load message from server
            var message = string.Empty;

            pushNotificator.Push(message);
        }
    }
}