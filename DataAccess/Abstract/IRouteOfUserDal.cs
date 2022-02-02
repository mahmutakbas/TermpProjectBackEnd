using Core.DataAccess;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IRouteOfUserDal : IDapperRepository<Entities.Concrete.RouteOfUser>
    {
        List<Entities.DTOs.DtoRoute> GetRoutes(int userId);
        List<Entities.DTOs.DtoRoute> GetOtherUserRoutes(int userId);
        List<Entities.DTOs.DtoRouteList> GetRouteList(int userId);
        List<Entities.DTOs.DtoPolygonUser> GetSearchDWithin(GeoJSON.Net.Geometry.Polygon item, string query);
        List<Entities.DTOs.DtoPolygonUser> GetSearchContains(GeoJSON.Net.Geometry.Polygon item, string query);
        List<Entities.DTOs.DtoPolygonUser> GetSearchIntersect(GeoJSON.Net.Geometry.Polygon item, string query);
        List<Entities.DTOs.DtoPolygonUser> GetSearchDistance(GeoJSON.Net.Geometry.Polygon item, string query);
        List<Entities.DTOs.DtoUserLine> GetSearchLine(string query);
    }
}
