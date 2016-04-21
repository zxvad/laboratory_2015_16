using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryManagementClient
{
    interface IConnection
    {
        bool Ping();

        void RegCompany(string companyName);

        void AuthCompany(string companyKey);
    }
}
