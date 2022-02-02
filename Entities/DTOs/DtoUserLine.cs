using Core.Entities.Abstract;
using GeoJSON.Net.Geometry;

namespace Entities.DTOs
{
    public class DtoUserLine : IDto
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Point FirstPoint { get; set; }
        public Point LastPoint { get; set; }
        public DateTime RouteStartDate { get; set; }
        public LineString Yol { get; set; }
    }
}
