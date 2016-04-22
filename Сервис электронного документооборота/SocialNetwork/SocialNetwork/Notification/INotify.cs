using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.NewsImporter
{
    interface INotify {
        void GetNotification(int material);
        void SendNotification();
        void NotificationSettings();
    }
}
