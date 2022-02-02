using Core.Entities.Abstract;
using GeoJSON.Net.Geometry;

namespace Entities.DTOs
{
    public class DtoDrawPolygon : IDto
    {
        public Polygon PUser { get; set; }
        public string[] Dates { get; set; }
        public bool OnlyTime { get; set; }
        public bool OnlyDate { get; set; }
        public bool OnlyADate { get; set; }
        public int PointLength { get; set; }

    }
}
