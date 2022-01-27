
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.Dapper;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {


            builder.RegisterType<RouteOfUsersManager>().As<IRouteOfUserService>().SingleInstance();
            builder.RegisterType<DpRouteOfUserDal>().As<IRouteOfUserDal>().SingleInstance();

            builder.RegisterType<RouteOfUserDetailManager>().As<IRouteOfUserDetailService>().SingleInstance();
            builder.RegisterType<DpRouteOfUserDetailDal>().As<IRouteOfUserDetailDal>().SingleInstance();

            builder.RegisterType<UserofFrinedManager>().As<IUserofFriendService>().SingleInstance();
            builder.RegisterType<DpUserOfFriendDal>().As<IUserofFriendDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<DpUserDal>().As<IUserDal>().SingleInstance();



            //builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
    }
}
