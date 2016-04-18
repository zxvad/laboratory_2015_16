using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AirNavSystem
{
    class MapObject
    {
        public List<Point> Points { get; }
        public Point Middlepoint { get; }
        public MapObjectType Type { get; }
        public MapObject(List<Point> points, MapObjectType type)
        {
            Points = points;
            Type = type;
            Middlepoint = new Point((int)Math.Round(points.Sum(x => (double)x.X) / points.Count),
                (int)Math.Round(points.Sum(y => (double)y.Y) / points.Count));
        }

        public double GetDistanceTo(MapObject mapObject)
        {
            return GetDistanceTo(mapObject.Middlepoint);
        }

        public double GetDistanceTo(Point point)
        {
            return Math.Sqrt((point.X - Middlepoint.X) * (point.X - Middlepoint.X) +
                (point.Y - Middlepoint.Y) * (point.Y - Middlepoint.Y));
        }

        public double GetAngleTo(MapObject mapObject)
        {
            return GetAngleTo(mapObject.Middlepoint);
        }

        public double GetAngleTo(Point point)
        {
            Point vector = new Point(point.X - Middlepoint.X, point.Y - Middlepoint.Y);
            return Math.Atan2(vector.Y, vector.X);
        }

    }
}
