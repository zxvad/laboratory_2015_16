using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PlayList
{
    interface IWorker
    {
        void AddWorker(string name);
        void DeleteWorker(string name);
        void ChangePassword(string name);

        
    }
}
