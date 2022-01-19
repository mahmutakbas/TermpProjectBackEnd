using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteofUserDetailController : ControllerBase
    {
        IRouteOfUserDetailService _routeOfUserDetailService;
        public RouteofUserDetailController(IRouteOfUserDetailService routeDetailService)
        {
            _routeOfUserDetailService = routeDetailService;
        }
        [HttpGet()]
        public IActionResult GetAll()
        {
            var result = _routeOfUserDetailService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _routeOfUserDetailService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getroutedetail")]
        public IActionResult GetRouteDetails(int routeid)
        {
            var result = _routeOfUserDetailService.GetRouteDetails(routeid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(dynamic routeDetail)
        {
            var items= routeDetail.data;
            List<RouteOfUserDetail> routeOfUserDetails=new List<RouteOfUserDetail>();
            for (int i = 0; i < items.Count; i++)
            {
                routeOfUserDetails.Add(
                new RouteOfUserDetail
                {
                    routeid = Convert.ToInt32(items[i].routeId.Value),
                    routetime = DateTime.Parse(items[i].routetime.Value).ToUniversalTime(),
                    route = new GeometryFactory().CreatePoint(new Coordinate(items[i].route.x.Value, items[i].route.y.Value))
                });
            }
            var result = _routeOfUserDetailService.AddList(routeOfUserDetails);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


       

    }
}
