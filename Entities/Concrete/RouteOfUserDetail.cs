using Core.Entities.Abstract;


namespace Entities.Concrete
{
    public class RouteOfUserDetail : IEntity
    {
        public int id { get; set; }
        public int routeid { get; set; }
        public GeoJSON.Net.Geometry.Point? route { get; set; }
        public TimeSpan routetime { get; set; }

    }
}
