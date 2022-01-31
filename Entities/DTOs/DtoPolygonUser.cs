using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class DtoPolygonUser:IDto
    {
        //   u.name,u.surname,u.email,rd.routetime,rd.route
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public TimeSpan routetime { get; set; }
        public DateTime routestartdate { get; set; }
        public GeoJSON.Net.Geometry.Point route { get; set; }
    }
}
