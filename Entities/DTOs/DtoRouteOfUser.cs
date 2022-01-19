

using Core.Entities.Abstract;
using Entities.Concrete;
using NetTopologySuite.Geometries;

namespace Entities.DTOs
{
    public class DtoRouteOfUser:IDto
    {
        public RouteOfUser NewRoute { get; set; }
        public List<RouteOfUserDetail> NewDetailRoute { get; set; }
    }
}
