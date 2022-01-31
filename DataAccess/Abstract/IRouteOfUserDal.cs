using Core.DataAccess;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IRouteOfUserDal : IDapperRepository<RouteOfUser>
    {
        List<Entities.DTOs.DtoRoute> GetRoutes(int userId);
        List<Entities.DTOs.DtoRoute> GetOtherUserRoutes(int userId);
        List<Entities.DTOs.DtoRouteList> GetRouteList(int userId);
        List<Entities.DTOs.DtoPolygonUser> GetDrawPolygon(GeoJSON.Net.Geometry.Polygon polygon);
    }
}
