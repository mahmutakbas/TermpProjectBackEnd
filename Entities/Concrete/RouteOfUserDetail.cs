using Core.Entities.Abstract;
using NetTopologySuite.Geometries;

namespace Entities.Concrete
{
    public class RouteOfUserDetail : IEntity
    {
        public int id { get; set; }
        public int routeid { get; set; }

        //     [Column(TypeName = "geometry (point)")]
        public Geometry? route { get; set; }
        public DateTime routetime { get; set; }

    }
}
