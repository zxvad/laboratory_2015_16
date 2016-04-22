using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace FoodDeliveryManagementClient
{
    class DBConnection : IDBConnection
    {
        string IDBConnection.GetDBConnectionParameters()
        {
            using (StreamReader sr = new StreamReader("db.cfg"))
            {
                return sr.ReadLine();
            }
        }
    }
}
