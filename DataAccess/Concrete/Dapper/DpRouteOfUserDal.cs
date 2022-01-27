using Dapper;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Npgsql;
using System.Collections.Generic;

namespace DataAccess.Concrete.Dapper
{
    public class DpRouteOfUserDal : IRouteOfUserDal
    {
        public int Add(RouteOfUser entity)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                using (var cmd = new NpgsqlCommand("INSERT INTO routesofusers (userid, routestartdate, firstpoint, lastpoint, visibility) VALUES ( @userid, @routestartdate, @firstpoint, @lastpoint, @visibility)", con))
                {
                    cmd.Parameters.AddWithValue("@userid", entity.userid);
                    cmd.Parameters.AddWithValue("@routestartdate", entity.routestartdate);
                    cmd.Parameters.AddWithValue("@firstpoint", entity.firstpoint);
                    cmd.Parameters.AddWithValue("@lastpoint", entity.lastpoint);
                    cmd.Parameters.AddWithValue("@visibility", true);
                    cmd.ExecuteNonQuery();
                }
                var result = con.QuerySingleOrDefault<int>("SELECT id FROM routesofusers WHERE routestartdate=@routestartdate AND userid=@userid ORDER BY id DESC  LIMIT 1", new
                {
                    userid = entity.userid,
                    routestartdate = entity.routestartdate
                });
                return result;
            }
        }
        public int Delete(RouteOfUser entity)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.Execute("DELETE FROM routesofusers WHERE id=@id;", new { id = entity.id });
                return result;
            }
        }
        public RouteOfUser Get(int id)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.QuerySingle<RouteOfUser>("SELECT * FROM routesofusers WHERE id=@id", new { id = id });
                return result;
            }
        }
        public List<RouteOfUser> GetAll()
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.Query<RouteOfUser>("SELECT * FROM routesofusers ").AsList();
                return result;
            }
        }

        public List<DtoRoute> GetOtherUserRoutes(int userId)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.Query<DtoRoute>("SELECT * FROM routesofusers WHERE userid=@userId AND visibility=true;", new { userId = userId }).AsList();
                return result;
            }
        }

        public List<DtoRoute> GetRoutes(int userId)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.Query<DtoRoute>("SELECT * FROM routesofusers WHERE userid=@userId;", new { userId=userId}).AsList();
                return result;
            }
        }
        public int Update(RouteOfUser entity)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.Execute("UPDATE routesofusers SET visibility=@visibility WHERE id=@id;", new { id = entity.id, visibility = entity.visibility });
                return result;
            }
        }
    }
}
