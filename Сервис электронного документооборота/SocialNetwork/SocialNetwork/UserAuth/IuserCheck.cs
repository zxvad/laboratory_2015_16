using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.UserAuth
{
    interface IuserCheck
    {
        void checkData(string username, string pass, string name, string email);
        void RetrievePass(string email);
    }
}
