using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using NetTopologySuite.Geometries;
using System.Collections.Generic;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfRoutesOfUsersDal : EfEntityRepositoryBase<RouteOfUser, TermProjectDbContext>, IRoutesOfUsersDal
    {
        public List<DtoRoute> GetRoutes(int userId)
        {
            using (TermProjectDbContext contex = new TermProjectDbContext())
            { 
                // TODO : Yarın distinc kodu ile mesafe bulacağız ve bunu line çevireceğiz.
                var routeList = (from r in contex.RouteOfUsers
                                 where r.userid == userId
                                 orderby r.routestartdate descending
                                 select new DtoRoute
                                 {
                                     id = r.id,
                                     userid = r.userid,
                                     routestartdate = r.routestartdate,
                                     firstpoint = new UserPoint(r.firstpoint.Coordinate.X, r.firstpoint.Coordinate.Y),
                                     lastpoint = new UserPoint(r.lastpoint.Coordinate.X, r.lastpoint.Coordinate.Y),
                                 }).ToList();
                return routeList;
            }

        }
    }
}
