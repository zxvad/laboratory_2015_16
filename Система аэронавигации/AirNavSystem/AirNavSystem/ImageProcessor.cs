using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirNavSystem
{
    public class ImageProcessor
    {
        ImagePreProcessor PreProcessor;
        ContourDetector Detector;

        public Point[] GetTrajectory(params Bitmap[] images)
        {
            throw new NotImplementedException();
        }

        public Point GetCurrentLocatin(Bitmap image, Bitmap areaMap)
        {
            throw new NotImplementedException();
        }
    }
}