using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Maps.GeoJSON
{
    public interface IGeometry
    {
        GeometryTypes Type { get; }
        ICoordinates Coordinates { get; }
    }

}
