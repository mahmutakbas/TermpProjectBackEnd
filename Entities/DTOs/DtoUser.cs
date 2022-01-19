using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class DtoUser:IDto
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? surname { get; set; }
        public string? email { get; set; }
        public DateTime createdate { get; set; } = DateTime.UtcNow;
        public DateTime updatedate { get; set; }
        public short status { get; set; }
    }
}
