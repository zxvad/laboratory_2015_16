using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class ListRewiewNoFixed : IListRewiewNoFixed
    {
        public List<Shop> GetAvailableShops()
        {
            throw new NotImplementedException();
        }

        public List<Catalog> GetCatalogs(List<Shop> avalibleShop)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts(List<Shop> avalibleShop)
        {
            throw new NotImplementedException();
        }
    }
}
