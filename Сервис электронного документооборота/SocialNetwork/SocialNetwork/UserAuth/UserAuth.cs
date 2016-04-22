using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.UserAuth
{
    class UserAuth : IuserCheck, IUserAuth
    {
        void IuserCheck.checkData(string username, string pass)
        {
            throw new NotImplementedException();
        }
        void IUserAuth.userAuth(string username, string pass)
        {
            throw new NotImplementedException();
        }
  
    }
}
