using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    interface IListRanking
    {
        int GetPriceProductSimilarPoints();
        int GetCatalogProductSimilarPoints();
        List<Product> GetSimilarWithMetrics(List<Product> products);
    }
}
