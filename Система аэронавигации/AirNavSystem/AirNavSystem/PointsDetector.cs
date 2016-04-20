using System;
using System.Collections.Generic;
using System.Drawing;

namespace AirNavSystem
{
    class PointsDetector : IPointsDetector
    {
        private Bitmap GetDifferenceBetweenFilters(int minuendDimension, int subtrahendDimension)
        {
            throw new NotImplementedException();
        }

        public List<MapObject> GetMapObjects(int minuendDimension, int subtrahendDimension, double threshold)
        {
            throw new NotImplementedException();
        }

        public Invariants GetInvariants(Rectangle where)
        {
            throw new NotImplementedException();
        }
    }
}