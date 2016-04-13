using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Maps.GeoJSON
{
    public enum GeometryTypes : byte
    {
        Point = 1,
        MultiPoint = 2,
        LineString = 3,
        MultiLineString = 4,
        Polygon = 5,
        MultiPolygon = 6,
        GeometryCollection = 7
    }
}
