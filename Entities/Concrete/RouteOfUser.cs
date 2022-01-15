using Core.Entities.Abstract;
using NetTopologySuite.Geometries;

namespace Entities.Concrete
{
    public class RouteOfUser : IEntity
    {
        public int id { get; set; }
        public int userid { get; set; }
        public DateTime routestartdate { get; set; } = DateTime.UtcNow;
        public Geometry firstpoint { get; set; }

        public Geometry lastpoint { get; set; }
    }
}
