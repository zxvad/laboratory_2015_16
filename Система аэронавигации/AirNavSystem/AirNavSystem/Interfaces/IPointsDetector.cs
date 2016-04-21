using System.Collections.Generic;
using System.Drawing;

namespace AirNavSystem
{
    interface IPointsDetector
    {
        Invariants GetInvariants(Rectangle where);
        List<MapObject> GetMapObjects(int minuendDimension, int subtrahendDimension, double threshold);
    }
}