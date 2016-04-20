using System.Drawing;

namespace AirNavSystem
{
    interface IContourDetector
    {
        Bitmap Gradient(Bitmap source, out Bitmap gradientMagnitude, out Bitmap gradientAngle, out Bitmap gradientDirection);
        Bitmap GetContours(Bitmap image, ContoursAlgorithmParams param);
        ChainCode[] DescribeContours(Bitmap Contours);
        TopologicalGraph BuildGraphFromChainCode(ChainCode chainCode);
    }
}