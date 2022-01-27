using Core.Entities.Abstract;
using GeoJSON.Net.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class DtoPointsLine:IDto
    {
        public LineString Yol { get; set; }
        public double Km { get; set; }
    }
 
}
