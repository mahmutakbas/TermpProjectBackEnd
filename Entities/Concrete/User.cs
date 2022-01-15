using Core.Entities.Abstract;
using System;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? surname { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public DateTime createdate { get; set; } = DateTime.UtcNow;
        public DateTime updatedate { get; set; }
        public short status { get; set; }
    }
}
