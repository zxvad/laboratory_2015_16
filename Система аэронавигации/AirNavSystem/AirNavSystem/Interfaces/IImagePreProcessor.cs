using System.Drawing;

namespace AirNavSystem
{
    interface IImagePreProcessor
    {
        Bitmap EqualiseHistogram(Bitmap source);
        Bitmap GaussFilter(Bitmap source, int windowSize);
        Bitmap LinearFilter(Bitmap source, int windowSize);
        Bitmap MedianFilter(Bitmap source, int windowSize);
        Bitmap StretchHistogram(Bitmap source, double lowThreshold, double highThreshold);
        Bitmap ToBlackAndWhite(Bitmap source);
    }
}