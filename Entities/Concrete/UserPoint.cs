
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Entities.Concrete
{
  
    public class UserPoint : NetTopologySuite.Geometries.Point
    {
        const int GoogleMapsSRID = 4326;
        [JsonConstructor]
        public UserPoint(double latitude, double longitude)
            : base(x: longitude, y: latitude) =>
              base.SRID = GoogleMapsSRID;

      

    }
}
