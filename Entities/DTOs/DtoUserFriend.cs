using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class DtoUserFriend : IDto
    {
       
        public int id { get; set; }
        public int friendid { get; set; }
        public string? name { get; set; }
        public string? surname { get; set; }
        public string? email { get; set; }
    }
}
