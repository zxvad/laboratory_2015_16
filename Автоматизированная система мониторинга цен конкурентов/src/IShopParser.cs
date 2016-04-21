using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    interface IShopParser
    {
        void StartCatalogParsing();
        void InsertOrUpdateCatalog(Catalog catalogs);
        void InsertOrUpdateProduct(Product products);
        string RequestInvoker(Uri url, Headers header, Cookei cookei);
    }
}
