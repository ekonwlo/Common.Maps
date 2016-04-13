using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Maps.GeoJSON
{
    public interface IFeatureCollection
    {
        string Type { get; }
        IEnumerable<IFeature> Features { get; }
    }
}
