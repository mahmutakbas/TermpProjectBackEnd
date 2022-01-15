using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RouteOfUsersManager : IRouteOfUserService
    {
        IRoutesOfUsersDal _routesOfUsersDal;

        public RouteOfUsersManager(IRoutesOfUsersDal routesOfUsersDal)
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


        // [PerformanceAspect(5)]
        public IDataResult<RouteOfUser> GetById(int id)
        {
            return new SuccessDataResult<RouteOfUser>(_routesOfUsersDal.Get(b => b.id == id));
        }


    }
}
