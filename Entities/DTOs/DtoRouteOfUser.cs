

using Entities.Concrete;
using NetTopologySuite.Geometries;

namespace Entities.DTOs
{
    public class DtoRouteOfUser
    {
        public RouteOfUser NewRoute { get; set; }
        public List<RouteOfUserDetail> NewDetailRoute { get; set; }
    }
}
