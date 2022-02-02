using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class DtoFilter:IDto
    {
        public string[] Dates { get; set; }
        public bool OnlyTime { get; set; }
        public bool OnlyDate { get; set; }
        public bool OnlyADate { get; set; }
    }
}
