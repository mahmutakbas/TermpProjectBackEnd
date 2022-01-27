using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class DtoRouteUpdate:IDto
    {
        public int id { get; set; }
        public bool visibility { get; set; }
    }
}
