using System.Collections.Generic;
using System.Drawing;

namespace AirNavSystem
{
    interface IMapObject
    {
        List<Point> Points { get; }
        Point Middlepoint { get; }
        MapObjectType Type { get; }
        double GetDistanceTo(MapObject mapObject);
        double GetDistanceTo(Point point);
        double GetAngleTo(MapObject mapObject);
        double GetAngleTo(Point point);
    }
}
