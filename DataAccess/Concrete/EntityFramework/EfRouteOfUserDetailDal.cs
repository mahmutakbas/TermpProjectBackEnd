using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRouteOfUserDetailDal : EfEntityRepositoryBase<RouteOfUserDetail, TermProjectDbContext>//, IRouteOfUserDetailDal
    {
        public List<RouteOfUserDetail> GetRouteDetails(int routeId)
        {
            using (TermProjectDbContext contex = new TermProjectDbContext())
            {
                //   route = new UserPoint(rd.route.Coordinate.X, rd.route.Coordinate.Y),

                var routeDetailList = (from rd in contex.RouteOfUserDetails
                                       where rd.routeid == routeId
                                       select new RouteOfUserDetail
                                       {
                                           routeid = routeId,
                                           id = rd.id,

                                           routetime = rd.routetime
                                       }).ToList();
                return routeDetailList;
            }
        }
    }
}
