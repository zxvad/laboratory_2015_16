using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Gui
{
    interface IGui
    {
        void ShowMainPage();
        void ShowUserPage(string auth_id);


    }
}
