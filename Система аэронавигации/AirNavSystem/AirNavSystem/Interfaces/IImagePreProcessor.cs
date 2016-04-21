using System.Drawing;

namespace AirNavSystem
{
    interface IImagePreProcessor
    {
        int[,] GetColorHistogram(Bitmap source);
        Bitmap Contrast(Bitmap source, double threshold);
        Bitmap Filter(Bitmap source, int dimension);
        Bitmap EqualiseHistogram(Bitmap source);
        Bitmap GaussFilter(Bitmap source, int windowSize);
        Bitmap LinearFilter(Bitmap source, int windowSize);
        Bitmap MedianFilter(Bitmap source, int windowSize);
        Bitmap StretchHistogram(Bitmap source, double lowThreshold, double highThreshold);
        Bitmap ToBlackAndWhite(Bitmap source);
    }
}