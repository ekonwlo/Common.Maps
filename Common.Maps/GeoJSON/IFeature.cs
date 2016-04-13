﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Maps.GeoJSON
{
    public interface IFeature
    {
        string Type { get; }
        IGeometry Geometry { get; }

    }
}
