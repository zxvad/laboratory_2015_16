using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    interface IParser
    {
        void StartParsing();
        void UpdateNominal();
        void InsertNominalCatalog(List<Catalog> catalogs);
        void InsertNominalProducts(List<Product> products);
    }
}
