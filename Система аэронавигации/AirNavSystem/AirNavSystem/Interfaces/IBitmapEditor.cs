using System.Collections.Generic;
using System.Drawing;

namespace AirNavSystem
{
    interface IBitmapEditor
    {
        int[,] GetColorHistogram();
        void Contrast(double threshold);
        void Filter(int dimension);
        List<MapObject> GetMapObjects(int minuendDimension, int subtrahendDimension, double threshold);
        Invariants GetInvariants(Rectangle where);
    }
}
