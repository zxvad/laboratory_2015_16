using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.UserAuth
{
    interface IUserAuth
    {
        void userAuth(string username, string pass);
    }
}
