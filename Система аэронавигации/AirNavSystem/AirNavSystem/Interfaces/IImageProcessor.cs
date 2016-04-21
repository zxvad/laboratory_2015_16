using System.Drawing;

namespace AirNavSystem
{
    public interface IImageProcessor
    {
        Point GetCurrentLocation(ContoursAlgorithmParams param, Bitmap image, Bitmap areaMap);
        Point[] GetTrajectory(PointsAlgorithmParams param, params Bitmap[] images);
    }
}