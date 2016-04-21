using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    interface IProductParser
    {
        void StartProductParsing();
        void InsertOrUpdateProduct(Product products);
        void ProductRequestInvoker(Uri url, Headers header, Cookei cookei);
    }
}
