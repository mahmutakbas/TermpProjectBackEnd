using Core.DataAccess;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IRoutesOfUsersDal : IEntityRepository<RouteOfUser>
    {
        List<Entities.DTOs.DtoRoute> GetRoutes(int userId);
    }
}
