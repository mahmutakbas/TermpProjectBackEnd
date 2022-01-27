using Core.Entities.Abstract;
using Entities.Concrete;


namespace Entities.DTOs
{
    public class DtoRouteOfUser:IDto
    {
        public List<RouteOfUserDetail> data { get; set; }
    }
}
