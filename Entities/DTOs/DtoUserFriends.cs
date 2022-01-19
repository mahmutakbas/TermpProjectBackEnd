using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class DtoUserFriends : IDto
    {
       
        public int id { get; set; }
        public int friendId { get; set; }
        public string? name { get; set; }
        public string? surname { get; set; }
        public string? email { get; set; }
    }
}
