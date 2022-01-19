
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Entities.Concrete
{
  
    public class UserPoint 
    {
        public const int GoogleMapsSRID = 4326;
        public double X { get; set; }
        public double Y { get; set; }
        public UserPoint(double x,double y)
        {
            X = x;
            Y = y;
        }
    }
}
