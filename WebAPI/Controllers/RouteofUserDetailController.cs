using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using GeoJSON.Net.Geometry;
using Microsoft.AspNetCore.Mvc;


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

        [HttpGet("getroutedetailline")]
        public IActionResult GetRouteDetailLine(int routeid)
        {
            var result = _routeOfUserDetailService.GetRouteLine(routeid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getroutedetaillines")]
        public IActionResult GetRouteDetailLines(int userId)
        {
            var result = _routeOfUserDetailService.GetRouteDetailLines(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(DtoRouteOfUser routeDetail)
        {
            var result = _routeOfUserDetailService.AddList(routeDetail.data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }




    }
}
