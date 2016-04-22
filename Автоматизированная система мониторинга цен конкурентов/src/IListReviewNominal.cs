using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    interface IListReviewNominal
    {
        List<Product> GetSimilarProducts();
        List<Product> RankingProducts(List<Product> products);
    }
}
