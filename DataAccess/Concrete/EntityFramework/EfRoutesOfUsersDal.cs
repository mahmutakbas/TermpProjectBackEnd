using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfRoutesOfUsersDal : EfEntityRepositoryBase<RouteOfUser, TermProjectDbContext>//, IRouteOfUserDal
    {
        public List<DtoRoute> GetRoutes(int userId)
        {
            using (TermProjectDbContext contex = new TermProjectDbContext())
            {
                //  firstpoint = new UserPoint(r.firstpoint.Coordinate.X, r.firstpoint.Coordinate.Y),
             //   lastpoint = new UserPoint(r.lastpoint.Coordinate.X, r.lastpoint.Coordinate.Y),
                // TODO : Yarın distinc kodu ile mesafe bulacağız ve bunu line çevireceğiz.
                var routeList = (from r in contex.RouteOfUsers
                                 where r.userid == userId
                                 orderby r.routestartdate descending
                                 select new DtoRoute
                                 {
                                     id = r.id,
                                     userid = r.userid,
                                     routestartdate = r.routestartdate,
                                   
                                 }).ToList();
                return routeList;
            }
        }
    }
}
