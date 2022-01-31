using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class DtoRouteList:IDto
    {
        private double _km;
        public int id { get; set; }
     

        public DateTime routestartdate { get; set; }
        public double km { get { return _km; } set { _km = value; }  }
        public TimeSpan rTime { get; set; }
    }
}
