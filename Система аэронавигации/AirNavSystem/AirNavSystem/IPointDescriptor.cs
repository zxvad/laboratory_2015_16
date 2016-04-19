using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirNavSystem
{
    interface IPointDescriptor<T>
    {
        double [] Values { get; }
        double GetDistinctWith(T other);
    }
}
