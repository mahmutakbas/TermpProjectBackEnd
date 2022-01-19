using Core.Entities.Abstract;
using Entities.Concrete;
using NetTopologySuite.Geometries;

namespace Entities.DTOs
{
    public class DtoRoute : IDto
    {
        public int id { get; set; }
        public int userid { get; set; }
        public DateTime routestartdate { get; set; } = DateTime.UtcNow;
        public UserPoint firstpoint { get; set; }

        public UserPoint lastpoint { get; set; }
    }
}
