using System;
using System.Drawing;

namespace AirNavSystem
{
    public class ImageProcessor : IImageProcessor
    {
        ImagePreProcessor PreProcessor;
        ContourDetector ContourDetector;
        PointsDetector PointsDetector;

        public Point GetCurrentLocation(ContoursAlgorithmParams param, Bitmap image, Bitmap areaMap)
        {
            throw new NotImplementedException();
        }

        public Point[] GetTrajectory(PointsAlgorithmParams param, params Bitmap[] images)
        {
            throw new NotImplementedException();
        }
    }
}