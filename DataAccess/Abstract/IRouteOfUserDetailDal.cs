using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using GeoJSON.Net.Geometry;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IRouteOfUserDetailDal : IDapperRepository<RouteOfUserDetail>
    {
        List<RouteOfUserDetail> GetRouteDetails(int routeId);
        DtoPointsLine GetRouteDetailLine(int routeId);
    }
}
