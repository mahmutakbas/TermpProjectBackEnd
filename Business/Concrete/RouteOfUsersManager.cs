using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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

        [ValidationAspect(typeof(BrandValidator))]
        public IDataResult<int> Add(RouteOfUser route)
        {
            //bu kısmı fluent validator tarafına devrettim
            //if (brand.BrandName.Length <= 2)
            //{
            //    return new ErrorResult(Messages.BrandNameInvalid);
            //}
            //ValidationTool.Validate(new BrandValidator(), brand
            int result= _routesOfUsersDal.Add(route);
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

        [ValidationAspect(typeof(BrandValidator))]
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
         return new SuccessDataResult<RouteOfUser>(_routesOfUsersDal.Get( id));
           
        }

        public IDataResult<RouteOfUser> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<DtoRoute>> GetOtherUserRoutes(int userid)
        {
            return new SuccessDataResult<List<DtoRoute>>(_routesOfUsersDal.GetOtherUserRoutes(userid));
        }
    }
}
