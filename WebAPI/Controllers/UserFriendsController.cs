using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFriendsController : Controller
    {
        IUserofFriendService _friendService;
        public UserFriendsController(IUserofFriendService friendService)
        {
            _friendService = friendService;
        }

        [HttpGet("GetUserFriends")]
        public IActionResult GetUserFriends(int userId)
        {

            var result = _friendService.GetUserFriends(userId);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(UserofFriend friend)
        {
            var result = _friendService.Add(friend);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(UserofFriend friend)
        {
            var result = _friendService.Delete(friend);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
