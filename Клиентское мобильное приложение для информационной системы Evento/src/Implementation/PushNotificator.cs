namespace Evento.Client.Implementation
{
    public class PushNotificator : IPushNotificator
    {
        public bool Push(string message)
        {
            //Call system method to show push notification;
            return true;
        }
    }
}