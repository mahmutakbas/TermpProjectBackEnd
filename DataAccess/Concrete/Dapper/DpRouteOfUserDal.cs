using Dapper;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using GeoJSON.Net.Geometry;
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
                using (var cmd = new NpgsqlCommand("INSERT INTO routesofusers (userid, routestartdate, firstpoint, lastpoint, visibility,routeenddate) VALUES ( @userid, @routestartdate, @firstpoint, @lastpoint, @visibility,@routeenddate)", con))
                {
                    cmd.Parameters.AddWithValue("@userid", entity.userid);
                    cmd.Parameters.AddWithValue("@routestartdate", entity.routestartdate);
                    cmd.Parameters.AddWithValue("@routeenddate", entity.routeenddate);
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
        public List<DtoPolygonUser> GetSearchDWithin(Polygon item,string query)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                using (var cmd = new NpgsqlCommand("SELECT u.name,u.surname,u.email,rd.routetime,r.routestartdate,rd.route FROM public.routeofuserdetails as rd INNER JOIN public.routesofusers as r ON rd.routeid = r.id INNER JOIN public.users as u ON u.id = r.userid WHERE ST_DWithin(@polygon, rd.route,  "+query, con))
                {
                    cmd.Parameters.AddWithValue("@polygon", item);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        List<DtoPolygonUser> users = new List<DtoPolygonUser>();
                        while (reader.Read())
                        {
                            users.Add(new DtoPolygonUser
                            {
                                name = reader.GetString(0),
                                surname = reader.GetString(1),
                                email = reader.GetString(2),
                                routetime = reader.GetTimeSpan(3),
                                route = (Point)reader.GetValue(5),
                                routestartdate = reader.GetDateTime(4).ToUniversalTime()
                            });
                        }
                        return users;
                    }
                }
                return null;
            }
        }
        public List<DtoPolygonUser> GetSearchContains(Polygon item, string query)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                using (var cmd = new NpgsqlCommand("SELECT u.name,u.surname,u.email,rd.routetime,r.routestartdate,rd.route FROM public.routeofuserdetails as rd INNER JOIN public.routesofusers as r ON rd.routeid = r.id INNER JOIN public.users as u ON u.id = r.userid WHERE ST_Contains(@polygon::geometry,rd.route::geometry)  " + query, con))
                {
                    cmd.Parameters.AddWithValue("@polygon", item);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        List<DtoPolygonUser> users = new List<DtoPolygonUser>();
                        while (reader.Read())
                        {
                            users.Add(new DtoPolygonUser
                            {
                                name = reader.GetString(0),
                                surname = reader.GetString(1),
                                email = reader.GetString(2),
                                routetime = reader.GetTimeSpan(3),
                                route = (Point)reader.GetValue(5),
                                routestartdate = reader.GetDateTime(4).ToUniversalTime()
                            });
                        }
                        return users;
                    }
                }
                return null;
            }
        }
        public List<DtoPolygonUser> GetSearchIntersect(Polygon item, string query)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                using (var cmd = new NpgsqlCommand("SELECT u.name,u.surname,u.email,rd.routetime,r.routestartdate,rd.route FROM public.routeofuserdetails as rd INNER JOIN public.routesofusers as r ON rd.routeid = r.id INNER JOIN public.users as u ON u.id = r.userid WHERE ST_Intersects(@polygon, rd.route) " + query, con))
                {
                    cmd.Parameters.AddWithValue("@polygon", item);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        List<DtoPolygonUser> users = new List<DtoPolygonUser>();
                        while (reader.Read())
                        {
                            users.Add(new DtoPolygonUser
                            {
                                name = reader.GetString(0),
                                surname = reader.GetString(1),
                                email = reader.GetString(2),
                                routetime = reader.GetTimeSpan(3),
                                route = (Point)reader.GetValue(5),
                                routestartdate = reader.GetDateTime(4).ToUniversalTime()
                            });
                        }
                        return users;
                    }
                }
                return null;
            }
        }

        public List<DtoPolygonUser> GetSearchDistance(Polygon item, string query)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                using (var cmd = new NpgsqlCommand("SELECT u.name,u.surname,u.email,rd.routetime,r.routestartdate,rd.route FROM public.routeofuserdetails as rd INNER JOIN public.routesofusers as r ON rd.routeid = r.id INNER JOIN public.users as u ON u.id = r.userid WHERE ST_DISTANCE(@polygon::geometry,rd.route::geometry)*1000>  " + query, con))
                {
                    cmd.Parameters.AddWithValue("@polygon", item);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        List<DtoPolygonUser> users = new List<DtoPolygonUser>();
                        while (reader.Read())
                        {
                            users.Add(new DtoPolygonUser
                            {
                                name = reader.GetString(0),
                                surname = reader.GetString(1),
                                email = reader.GetString(2),
                                routetime = reader.GetTimeSpan(3),
                                route = (Point)reader.GetValue(5),
                                routestartdate = reader.GetDateTime(4).ToUniversalTime()
                            });
                        }
                        return users;
                    }
                }
                return null;
            }
        }

        public List<DtoUserLine> GetSearchLine(string filter)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                string query = $"SELECT rd.routeid as id,s.name AS Name,s.surname AS Surname ,s.email AS Email,r.firstpoint AS FirstPoint,r.lastpoint AS LastPoint,r.routestartdate AS RouteStartDate,ST_MakeLine(rd.route::geometry) As Yol FROM public.routeofuserdetails As rd  inner join public.routesofusers as r on rd.routeid = r.id inner join public.users As s on r.userid = s.id  {filter}  GROUP BY rd.routeid,s.name,s.surname,s.email,r.firstpoint,r.lastpoint,r.routestartdate; ";
                var result = con.Query<DtoUserLine>(query).AsList();
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

        public List<DtoRouteList> GetRouteList(int userId)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.Query<DtoRouteList>("SELECT  r.id ,r.routestartdate , (max(rd.routetime)-min(rd.routetime)) as rTime,ST_Length(st_makeline(Array(Select  rd.route::geometry from public.routeofuserdetails as rd where rd.routeid=r.id)),false)/1000 as Km FROM public.routesofusers AS r INNER JOIN public.routeofuserdetails AS rd ON r.id = rd.routeid  where r.userid=@userId group by r.id;", new { userId = userId }).AsList();
                return result;
            }
        }

        public List<DtoRoute> GetRoutes(int userId)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.Query<DtoRoute>("SELECT * FROM routesofusers WHERE userid=@userId;", new { userId = userId }).AsList();
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
