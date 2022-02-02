using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;


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

        [HttpGet("getuserroutes")]
        public IActionResult GetRoutes(int userId)
        {
            var result = _routeOfUsersService.GetRoutes(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getroutelist")]
        public IActionResult GetRouteList(int userId)
        {
            var result = _routeOfUsersService.GetRouteList(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getotheruserroutes")]
        public IActionResult GetOtherUserRoutes(int userId)
        {
            var result = _routeOfUsersService.GetOtherUserRoutes(userId);
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

        [HttpPost("getsearchdwithin")]
        public IActionResult GetSearchDWithin(DtoDrawPolygon route)
        {
          
            var result = _routeOfUsersService.GetSearchDWithin(route); 
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("getsearchcontains")]
        public IActionResult GetSearchContains(DtoDrawPolygon route)
        {
            var result = _routeOfUsersService.GetSearchContains(route);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("getsearchintersect")]
        public IActionResult GetSearchIntersect(DtoDrawPolygon route)
        {
            var result = _routeOfUsersService.GetSearchIntersect(route);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("getsearchdistance")]
        public IActionResult GetSearchDistance(DtoDrawPolygon route)
        {

            var result = _routeOfUsersService.GetSearchDistance(route);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("getsearchline")]
        public IActionResult GetSearchLine(DtoFilter route)
        {

            var result = _routeOfUsersService.GetSearchLine(route) ;
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(RouteOfUser route)
        {
            var result = _routeOfUsersService.Add(route); ;
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(DtoRouteDelete route)
        {
            var result = _routeOfUsersService.Delete(new RouteOfUser
            {
                id = route.id,
                userid = route.userid
            });
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(DtoRouteUpdate route)
        {
            var result = _routeOfUsersService.Update(new RouteOfUser
            {
                id = route.id,
                visibility = route.visibility,
            });
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
