using Core.Entities.Abstract;
using GeoJSON.Net.Geometry;

namespace Entities.DTOs
{
    public class DtoRoute : IDto
    {
        public int id { get; set; }
        public int userid { get; set; }
        public DateTime routestartdate { get; set; } = DateTime.UtcNow;
        public Point firstpoint { get; set; }
        public Point lastpoint { get; set; }
    }
}
