using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class UserofFriend : IEntity
    {
        public int id { get; set; }
        public int userid { get; set; }
        public int friendid { get; set; }
    }
}
