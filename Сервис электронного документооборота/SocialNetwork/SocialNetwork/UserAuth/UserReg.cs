using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.UserAuth
{
    class UserReg : IuserCheck, IUserReg
    {
        void IuserCheck.checkData(string username, string pass, string name, string email)
        {
            throw new NotImplementedException();
     
        }

        void IUserReg.userRegisration(string username, string pass, string name, string email)
        {
            throw new NotImplementedException();
     
        }
    }
}
