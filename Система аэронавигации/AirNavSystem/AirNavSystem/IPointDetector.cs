using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirNavSystem
{
    interface IPointDetector<T>
        where T : IPointDetector<T>
    {
        double [] Values { get; }
        double GetDistinctWith(T other);
    }
}
