using Dapper;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using GeoJSON.Net.Geometry;
using Npgsql;
using System;
using System.Collections.Generic;

namespace DataAccess.Concrete.Dapper
{
    public class DpRouteOfUserDetailDal : IRouteOfUserDetailDal
    {
        public int Add(RouteOfUserDetail entity)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                using (var cmd = new NpgsqlCommand("INSERT INTO routeofuserdetails(routeid, routetime, route)VALUES (@routeid, @routetime, @route);", con))
                {
                    cmd.Parameters.AddWithValue("@routeid", entity.routeid);
                    cmd.Parameters.AddWithValue("@routetime", entity.routetime);
                    cmd.Parameters.AddWithValue("@route", entity.route);
                    cmd.ExecuteNonQuery();
                }
                return 1;
            }
        }

        public int Delete(RouteOfUserDetail entity)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.Execute("DELETE FROM routeofuserdetails WHERE id=@id;", new { id = entity.id });
                return result;
            }
        }

        public RouteOfUserDetail Get(int id)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.QuerySingle<RouteOfUserDetail>("SELECT * FROM routeofuserdetails WHERE id=@id;", new { id = id });
                return result;
            }
        }

        public List<RouteOfUserDetail> GetAll()
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.Query<RouteOfUserDetail>("SELECT * FROM routeofuserdetails;").AsList();
                return result;
            }
        }

        public DtoPointsLine GetRouteDetailLine(int routeId)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.QuerySingleOrDefault<DtoPointsLine>("SELECT ST_Length(geom::geography)/1000 as Km,geom as Yol FROM st_makeline(ARRAY(SELECT route::geometry FROM public.routeofuserdetails as rd where rd.routeid=@routeId ORDER BY routetime)) AS geom;", new { routeId = routeId });
                return result;
            }
        }
        public List<RouteOfUserDetail> GetRouteDetails(int routeId)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.Query<RouteOfUserDetail>("SELECT * FROM routeofuserdetails WHERE routeid=@routeId;", new { routeId = routeId }).AsList();
                return result;
            }
        }

        public int Update(RouteOfUserDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
