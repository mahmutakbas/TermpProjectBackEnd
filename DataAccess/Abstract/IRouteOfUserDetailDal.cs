using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IRouteOfUserDetailDal : IEntityRepository<RouteOfUserDetail>
    {
        List<DtoRouteDetail> GetRouteDetails(int routeId);
    }
}
