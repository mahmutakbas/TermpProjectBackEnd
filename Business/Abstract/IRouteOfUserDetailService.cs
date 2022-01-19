using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRouteOfUserDetailService : IBaseService<RouteOfUserDetail>
    {
        IDataResult<int[]> AddList(List<RouteOfUserDetail> routesDetail);
        IDataResult<List<DtoRouteDetail>> GetRouteDetails(int routeId);
        IResult Delete(int routeId);
    }
}
