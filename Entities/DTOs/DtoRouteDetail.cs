using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class DtoRouteDetail:IDto
    {
        public int id { get; set; }
        public int routeid { get; set; }
        public UserPoint route { get; set; }
        public string routetime { get; set; }
    }
}
