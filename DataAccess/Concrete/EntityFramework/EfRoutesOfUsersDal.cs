using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRoutesOfUsersDal : EfEntityRepositoryBase<RouteOfUser, TermProjectDbContext>, IRoutesOfUsersDal
    {

    }
}
