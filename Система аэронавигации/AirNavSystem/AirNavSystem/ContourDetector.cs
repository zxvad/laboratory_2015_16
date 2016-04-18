using System;
using System.Drawing;

namespace AirNavSystem
{
    class ContourDetector : IContourDetector
    {
        PreProcessor preProcessor;
        const int directionsCount = 8;
        static int[] offsetX = { 1, 1, 0, -1, -1, -1, 0, 1 };
        static int[] offsetY = { 0, 1, 1, 1, 0, -1, -1, -1 };
        static int[,] nextDirections = {    {1, 0, 7, 9, 9, 9 },
                                            {3, 2, 1, 0, 7, 9 },
                                            {3, 2, 1, 9, 9, 9 },
                                            {5, 4, 3, 2, 1, 9 },
                                            {5, 4, 3, 9, 9, 9 },
                                            {7, 6, 5, 4, 3, 9 },
                                            {7, 6, 5, 9, 9, 9 },
                                            {1, 0, 7, 6, 5, 9 }
        };

        static bool checkCoordinats(int x, int y, int width, int height)
        {
            return x >= 0 && x < width && y >= 0 && y < height;
        }

        static int GetDirectionNumber(double angle)
        {
            int direction = (int)Math.Round(4 * angle / Math.PI);
            return direction != 8 ? direction : 0;
        }

        static int GetDirectionNumber(int dx, int dy)
        {
            double angle = Math.Atan2(dy, dx);
            if (dy == -1)
                angle += 2 * Math.PI;
            return GetDirectionNumber(angle);
        }

        static int GetOutlinePixelsCount(int x, int y, bool[,] edges, int width, int height)
        {
            int result = 0;
            for (int i = 0; i < directionsCount; i++)
            {
                int tmpX = x + offsetX[i];
                int tmpY = y + offsetY[i];
                if (!checkCoordinats(tmpX, tmpY, width, height))
                    continue;
                if (edges[tmpX, tmpY])
                    result++;
            }
            return result;
        }

        static void BuildOutline(int startX, int startY, Bitmap gradient, bool[,] edges, int[,] angles)
        {
            throw new NotImplementedException();
        }

        public Bitmap Gradient(Bitmap source, out Bitmap gradientMagnitude, out Bitmap gradientAngle, out Bitmap gradientDirection)
        {
            throw new NotImplementedException();
        }

        public static Bitmap Outlines(Bitmap gradient, int threshold)
        {
            throw new NotImplementedException();
        }

        public Bitmap GetContours(Bitmap image, ContoursAlgorithmParams param)
        {
            throw new NotImplementedException();
        }
    }
}