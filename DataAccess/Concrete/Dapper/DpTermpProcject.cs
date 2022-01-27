

using Dapper;
using Npgsql;

namespace DataAccess.Concrete.Dapper
{
    public class DpTermpProcject
    {
        public static NpgsqlConnection CreateConnection()
        {
            NpgsqlConnection con=null;
            if (con == null)
            {
                con = new NpgsqlConnection("User ID=postgres;Password=12345;Server=localhost;Port=5432;Database=Term;Integrated Security=true;");
                con.Open();
               
            }
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            con.TypeMapper.UseGeoJson(geographyAsDefault: true);    
            return con;
        }

    }
}
