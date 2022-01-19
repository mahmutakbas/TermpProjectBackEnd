using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRouteOfUserDetailDal : EfEntityRepositoryBase<RouteOfUserDetail, TermProjectDbContext>, IRouteOfUserDetailDal
    {
        public List<DtoRouteDetail> GetRouteDetails(int routeId)
        {
            using (TermProjectDbContext contex = new TermProjectDbContext())
            {
                var routeDetailList = (from rd in contex.RouteOfUserDetails
                                       where rd.routeid == routeId
                                       select new DtoRouteDetail
                                       {
                                           routeid = routeId,
                                           id = rd.id,
                                           route = new UserPoint(rd.route.Coordinate.X, rd.route.Coordinate.Y),
                                           routetime = rd.routetime.ToString("HH:mm:ss")
                                       }).ToList();
                return routeDetailList;
            }
        }
    }
}
