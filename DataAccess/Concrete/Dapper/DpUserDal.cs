using Dapper;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace DataAccess.Concrete.Dapper
{
    public class DpUserDal : IUserDal
    {
        public int Add(User entity)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.QuerySingle<int>("INSERT INTO users ( name, email, password, createdate, updatedate, status, surname)    VALUES(@name, @email, @password, @createdate, @updatedate, @status, @surname) RETURNING id;", new { name = entity.name, email = entity.email, password = entity.password, createdate = entity.createdate, updatedate = entity.updatedate, status = entity.status, surname = entity.surname });
                return result;
            }
        }

        public int Delete(User entity)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.Execute("DELETE FROM users WHERE id=@id;", new { id = entity.id });
                return result;
            }
        }

        public User Get(int id)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.QuerySingle<User>("SELECT * FROM users WHERE id=@id;", new { id = id });
                return result;
            }
        }

        public List<User> GetAll()
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.Query<User>("SELECT * FROM users;").AsList();
                return result;
            }

        }

        public List<DtoUser> GetByEmail(string email)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.Query<DtoUser>("SELECT * FROM users WHERE email LIKE CONCAT('%',@email,'%');", new
                {
                    email =
                    email
                }).AsList();
                return result;
            }
        }

        public DtoUser GetById(int id)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.QuerySingleOrDefault<DtoUser>("SELECT * FROM users WHERE id=@id;", new { id = id });
                return result;
            }
        }

        public List<DtoUser> GetDtoUsers()
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.Query<DtoUser>("SELECT * FROM users;").AsList();
                return result;
            }
        }

        public DtoUser GetExistEmail(string email)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.QuerySingleOrDefault<DtoUser>("SELECT * FROM users WHERE email=@email;", new { email = email });
                return result;
            }
        }

        public DtoUser GetLogin(string email, string password)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.QuerySingle<DtoUser>("SELECT * FROM users WHERE email=@email and password=@password;",new { email=email,password=password});
                return result;
            }
        }

        public int Update(User entity)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.Execute("UPDATE users SET name=@name , email =@email, password =@password , updatedate =@updatedate, surname =@surname WHERE id=@id; ", new
                {
                    id = entity.id,
                    name = entity.name,
                    surname = entity.surname,
                    email = entity.email,
                    password = entity.password,
                    updatedate = DateTime.UtcNow
                });
                return result;
            }
        }
    }
}
