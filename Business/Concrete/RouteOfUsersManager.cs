using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RouteOfUsersManager : IRouteOfUserService
    {
        IRouteOfUserDal _routesOfUsersDal;

        public RouteOfUsersManager(IRouteOfUserDal routesOfUsersDal)
        {
            _routesOfUsersDal = routesOfUsersDal;
        }

        public IDataResult<int> Add(RouteOfUser route)
        {
            int result = _routesOfUsersDal.Add(route);
            if (result <= 0)
            {
                return new ErrorDataResult<int>(-1);

            }
            return new SuccessDataResult<int>(result);

        }


        public IResult Delete(RouteOfUser route)
        {
            _routesOfUsersDal.Delete(route);
            return new SuccessResult();
        }

        public IResult Update(RouteOfUser route)
        {
            _routesOfUsersDal.Update(route);
            return new SuccessResult();
        }


        // [PerformanceAspect(10)]
        public IDataResult<List<RouteOfUser>> GetAll()
        {
            return new SuccessDataResult<List<RouteOfUser>>(_routesOfUsersDal.GetAll());
        }

        public IDataResult<List<DtoRoute>> GetRoutes(int userId)
        {
            return new SuccessDataResult<List<DtoRoute>>(_routesOfUsersDal.GetRoutes(userId));
        }
        // [PerformanceAspect(5)]
        public IDataResult<RouteOfUser> GetById(int id)
        {
            return new SuccessDataResult<RouteOfUser>(_routesOfUsersDal.Get(id));

        }

        public IDataResult<RouteOfUser> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<DtoRoute>> GetOtherUserRoutes(int userid)
        {
            return new SuccessDataResult<List<DtoRoute>>(_routesOfUsersDal.GetOtherUserRoutes(userid));
        }

        public IDataResult<List<DtoRouteList>> GetRouteList(int userid)
        {
            return new SuccessDataResult<List<DtoRouteList>>(_routesOfUsersDal.GetRouteList(userid));
        }
        private string stringSub(string item, string add)
        {
            var newitem = item.Substring(0, item!.Length - 2);

            return newitem + add;
        }

        public IDataResult<List<DtoPolygonUser>> GetSearchDWithin(DtoDrawPolygon item)
        {
            var result = _routesOfUsersDal.GetSearchDWithin(item.PUser, item.PointLength + ",true) " + QueryTime(item));
            if (result != null)
            {
                return new SuccessDataResult<List<DtoPolygonUser>>(result);
            }
            return new ErrorDataResult<List<DtoPolygonUser>>();
        }

        public IDataResult<List<DtoPolygonUser>> GetSearchContains(DtoDrawPolygon item)
        {
            var result = _routesOfUsersDal.GetSearchContains(item.PUser, QueryTime(item));
            if (result != null)
            {
                return new SuccessDataResult<List<DtoPolygonUser>>(result);
            }
            return new ErrorDataResult<List<DtoPolygonUser>>();
        }

        public IDataResult<List<DtoPolygonUser>> GetSearchIntersect(DtoDrawPolygon item)
        {
            var result = _routesOfUsersDal.GetSearchIntersect(item.PUser, QueryTime(item));
            if (result != null)
            {
                return new SuccessDataResult<List<DtoPolygonUser>>(result);
            }
            return new ErrorDataResult<List<DtoPolygonUser>>();
        }
        public IDataResult<List<DtoPolygonUser>> GetSearchDistance(DtoDrawPolygon item)
        {
            var result = _routesOfUsersDal.GetSearchDistance(item.PUser, item.PointLength + QueryTime(item));
            if (result != null)
            {
                return new SuccessDataResult<List<DtoPolygonUser>>(result);
            }
            return new ErrorDataResult<List<DtoPolygonUser>>();
        }
        private string QueryTime(DtoDrawPolygon item)
        {
            string query = "";
            if (item.Dates.Length > 0 && item.Dates[0] != "")
            {
                if (item.OnlyTime)
                {
                    if (item.OnlyADate)
                    {
                        query = string.Format(" AND (rd.routetime BETWEEN '{0}' AND '{1}') order by rd.route asc", TimeSpan.Parse(item.Dates[0] + ":00"), TimeSpan.Parse(item.Dates[0] + ":59"));
                    }
                    else
                    {
                        query = string.Format(" AND (rd.routetime BETWEEN '{0}' AND '{1}') order by rd.route asc", TimeSpan.Parse(item.Dates[0] + ":00"), TimeSpan.Parse(item.Dates[1] + ":59"));
                    }

                }
                if (item.OnlyDate)
                {
                    if (item.OnlyADate)
                    {
                        query = $" AND (r.routestartdate BETWEEN '{DateTime.Parse(item.Dates[0] + " 00:00:00")}' AND '{DateTime.Parse(item.Dates[0] + " 23:59:59")}' OR r.routeenddate BETWEEN '{DateTime.Parse(item.Dates[0] + " 00:00:00")}' AND '{DateTime.Parse(item.Dates[0] + " 23:59:59")}') ";
                    }
                    else
                    {
                        query = $" AND (r.routestartdate BETWEEN '{DateTime.Parse(item.Dates[0] + " 00:00:00")}' AND '{DateTime.Parse(item.Dates[1] + " 23:59:59")}' OR r.routeenddate BETWEEN '{DateTime.Parse(item.Dates[0] + " 00:00:00")}' AND '{DateTime.Parse(item.Dates[1] + " 23:59:59")}') ";
                    }
                }
                if (!item.OnlyTime && !item.OnlyDate)
                {
                    if (item.OnlyADate)
                    {
                        query = $" AND (r.routestartdate BETWEEN '{DateTime.Parse(stringSub(item.Dates[0], "00"))}' AND  '{DateTime.Parse(stringSub(item.Dates[0], "59"))}' OR r.routeenddate BETWEEN '{DateTime.Parse(stringSub(item.Dates[0], "00"))}' AND  '{DateTime.Parse(stringSub(item.Dates[0], "59"))}') ";
                    }
                    else
                    {
                        query = $" AND (r.routestartdate BETWEEN '{DateTime.Parse(stringSub(item.Dates[0], "00"))}' AND  '{DateTime.Parse(stringSub(item.Dates[1], "59"))}' OR r.routeenddate BETWEEN '{DateTime.Parse(stringSub(item.Dates[0], "00"))}' AND  '{DateTime.Parse(stringSub(item.Dates[1], "59"))}') ";
                    }
                }
            }
            return query;
        }

        public IDataResult<List<DtoUserLine>> GetSearchLine(DtoFilter item)
        {
            string query = QueryTime(new DtoDrawPolygon { Dates = item.Dates, OnlyTime = item.OnlyTime, OnlyADate = item.OnlyADate, OnlyDate = item.OnlyDate });
            List<DtoUserLine> result;
            if (query.Length > 4)
            {
                result = _routesOfUsersDal.GetSearchLine(" WHERE "+query.Remove(0,4));
            }
            else
            {
                result = _routesOfUsersDal.GetSearchLine("");
            }

            if (result != null)
            {
                return new SuccessDataResult<List<DtoUserLine>>(result);
            }
            return new ErrorDataResult<List<DtoUserLine>>();
        }
    }
}
