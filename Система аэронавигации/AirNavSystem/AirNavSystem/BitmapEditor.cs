using System;
using System.Collections.Generic;
using System.Drawing;

namespace AirNavSystem
{
    class BitmapEditor : IBitmapEditor
    {
        private Bitmap _bitmap;

        public BitmapEditor(Bitmap bitmap)
        {
            _bitmap = bitmap;
        }

        public int[,] GetColorHistogram()
        {
            throw new NotImplementedException();
        }

        public void Contrast(double threshold)
        {
            throw new NotImplementedException();
        }

        public void Filter(int dimension)
        {
            throw new NotImplementedException();
        }

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
