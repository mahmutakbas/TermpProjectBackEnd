using Core.Entities.Abstract;
using NetTopologySuite.Geometries;

namespace Entities.Concrete
{
    public class RouteOfUser : IEntity
    {
        public int id { get; set; }
        public int userid { get; set; }
        public DateTime routestartdate { get; set; } = DateTime.UtcNow;
        public Point firstpoint { get; set; }

        public Point lastpoint { get; set; }
        public bool visibility { get; set; }
    }
}
