using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRouteOfUserService:IBaseService<RouteOfUser>
    {
        public IDataResult<List<DtoRoute>> GetRoutes(int userid);
        IResult Delete(RouteOfUser item);
    }
}
