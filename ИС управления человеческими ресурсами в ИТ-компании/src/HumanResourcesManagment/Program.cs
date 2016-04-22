using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesManagment
{
    class Program
    {
        private static PrivaceOffice privaceOffice;
        private static WorkloadManager workManager;
        private static DBManager dbManager;

        static void Main(string[] args)
        { 
            privaceOffice.Authorization("admin", "1234");
            workManager.Event();
            dbManager.Add();
        }
    }
}
