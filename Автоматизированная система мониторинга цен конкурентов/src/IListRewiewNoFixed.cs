using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    interface IListRewiewNoFixed
    {
        List<Shop> GetAvailableShops();
        List<Catalog> GetCatalogs(List<Shop> avalibleShop);
        List<Product> GetProducts(List<Shop> avalibleShop);
    }
}
