using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    interface IProductMonitoring
    {
        List<Shop> GetAvalibleShopList();
        void ShowProductsInShops(List<Shop> shops);
        void SearchPricesInDate(DateTime date);
    }
}
