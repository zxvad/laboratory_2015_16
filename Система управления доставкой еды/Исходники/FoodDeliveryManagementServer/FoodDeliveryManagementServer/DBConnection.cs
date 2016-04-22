using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryManagementServer
{
    class DBConnection : IDB
    {
        string IDB.GetDBInformation()
        {
            using (StreamReader sr = new StreamReader("db.cfg"))
            {
                return sr.ReadLine();
            }
        }
    }
}
