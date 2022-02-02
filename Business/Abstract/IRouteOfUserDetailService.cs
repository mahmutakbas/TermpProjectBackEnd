using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using GeoJSON.Net.Geometry;

namespace Business.Abstract
{
    public interface IRouteOfUserDetailService
    {
        IDataResult<RouteOfUserDetail> Get(int id);
        IDataResult<List<RouteOfUserDetail>> GetAll();
        IDataResult<int> Add(RouteOfUserDetail routeOfUserDetail);
        IResult Update(RouteOfUserDetail routeOfUserDetail);
        IDataResult<RouteOfUserDetail> GetById(int id);
        IDataResult<int[]> AddList(List<RouteOfUserDetail> routesDetail);
        IDataResult<List<RouteOfUserDetail>> GetRouteDetails(int routeId);
        IResult Delete(int routeId);
        IDataResult<DtoPointsLine> GetRouteLine(int routeId);
        IDataResult< List<DtoUserLine>> GetRouteDetailLines(int userId);
    }
}
