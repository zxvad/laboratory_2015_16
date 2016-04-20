using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AirNavSystem
{
    class ImagePreProcessor : IImagePreProcessor
    {
        static Color ToMono(Color source)
        {
            int color = (int)(source.R * 0.3 + source.G * 0.6 + source.B * 0.1);
            return Color.FromArgb(color, color, color);
        }

        public Bitmap ToBlackAndWhite(Bitmap source)
        {
            throw new NotImplementedException();
        }

        public Bitmap EqualiseHistogram(Bitmap source)
        {
            throw new NotImplementedException();
        }

        public Bitmap StretchHistogram(Bitmap source, double lowThreshold, double highThreshold)
        {
            throw new NotImplementedException();
        }

        public Bitmap MedianFilter(Bitmap source, int windowSize)
        {
            throw new NotImplementedException();
        }

        public Bitmap LinearFilter(Bitmap source, int windowSize)
        {
            throw new NotImplementedException();
        }

        public Bitmap GaussFilter(Bitmap source, int windowSize)
        {
            throw new NotImplementedException();
        }
    }
}