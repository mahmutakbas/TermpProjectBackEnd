using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteofUsersController : ControllerBase
    {
        IRouteOfUserService _routeOfUsersService;
        public RouteofUsersController(IRouteOfUserService routeService)
        {
            _routeOfUsersService = routeService;
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var result = _routeOfUsersService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _routeOfUsersService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(dynamic route)
        {
            var result = _routeOfUsersService.Add(new RouteOfUser
            {
                userid = (int)route.userid.Value,
                routestartdate = DateTime.UtcNow,
                firstpoint = new GeometryFactory().CreatePoint(new Coordinate(route.firstpoint.x.Value, route.firstpoint.y.Value)),
                lastpoint = new GeometryFactory().CreatePoint(new Coordinate(route.lastpoint.x.Value, route.lastpoint.y.Value))
            });
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(RouteOfUser route)
        {
            var result = _routeOfUsersService.Delete(route);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(RouteOfUser route)
        {
            var result = _routeOfUsersService.Update(route);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
