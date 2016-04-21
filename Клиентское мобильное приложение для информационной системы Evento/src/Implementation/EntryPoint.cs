using System;
using System.Threading;
using System.Threading.Tasks;

namespace Evento.Client.Implementation
{
    public class EntryPoint : IEntryPoint
    {
        private readonly IServerPushMessageObserver serverPushMessageObserver;

        public EntryPoint(IServerPushMessageObserver serverPushMessageObserver, IPushNotificator notificator)
        {
            this.serverPushMessageObserver = serverPushMessageObserver;
        }

        public void Start()
        {
            Task.Factory.StartNew(Work);
        }

        private void Work()
        {
            while (true)
            {
                serverPushMessageObserver.LookForMessages();
                Thread.Sleep(TimeSpan.FromSeconds(30));
            }
        }
    }
}