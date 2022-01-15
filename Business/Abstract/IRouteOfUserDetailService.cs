using Core.Utilities.Results.Abstract;
using Entities.Concrete;
namespace Business.Abstract
{
    public interface IRouteOfUserDetailService : IBaseService<RouteOfUserDetail>
    {
        IDataResult<int[]> AddList(List<RouteOfUserDetail> routesDetail);
    }
}
