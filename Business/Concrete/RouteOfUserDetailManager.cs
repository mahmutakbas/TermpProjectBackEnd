using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using GeoJSON.Net.Geometry;

namespace Business.Concrete
{
    public class RouteOfUserDetailManager : IRouteOfUserDetailService
    {
        IRouteOfUserDetailDal _routeOfUserDetailDal;
        public RouteOfUserDetailManager(IRouteOfUserDetailDal routeOfDetailDal)
        {
            _routeOfUserDetailDal = routeOfDetailDal;
        }
        public IDataResult<int> Add(RouteOfUserDetail route)
        {
         var result= _routeOfUserDetailDal.Add(route);
            return new SuccessDataResult<int>(result);
        }

        public IDataResult<int[]> AddList(List<RouteOfUserDetail> routesDetail)
        {
            int[] result=new int[routesDetail.Count];
            for (int i = 0; i < routesDetail.Count; i++)
            {
                 result [i]= _routeOfUserDetailDal.Add(routesDetail[i]);
            }
            if(result.Where(i=> i<=0).Any())
            {
                return new ErrorDataResult<int[]>(result);
            }
            return new SuccessDataResult<int[]>(result);
        }

        public IResult Delete(int routeId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<RouteOfUserDetail> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<RouteOfUserDetail>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<RouteOfUserDetail> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<RouteOfUserDetail>> GetRouteDetails(int routeId)
        {
            var result = _routeOfUserDetailDal.GetRouteDetails(routeId);
            
            if (result.Count > 0) { return new SuccessDataResult<List<RouteOfUserDetail>>(result); }
            return new ErrorDataResult<List<RouteOfUserDetail>>();
        }

        public IDataResult<DtoPointsLine> GetRouteLine(int routeId)
        {
           return new SuccessDataResult<DtoPointsLine>(_routeOfUserDetailDal.GetRouteDetailLine(routeId));
        }

        public IResult Update(RouteOfUserDetail route)
        {
            throw new NotImplementedException();
        }
    }
}
