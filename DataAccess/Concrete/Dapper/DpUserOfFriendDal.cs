using Dapper;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Concrete.Dapper
{
    public class DpUserOfFriendDal : IUserofFriendDal
    {
        public int Add(UserofFriend entity)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.Execute("INSERT INTO useroffriends (userid, friendid)    VALUES(@userid, @friendid); ", new { userid = entity.userid, friendid = entity.friendid });
                return result;
            }
        }

        public int Delete(UserofFriend entity)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.Execute("DELETE FROM useroffriends WHERE id=@id;", new { id = entity.id });
                return result;
            }
        }

        public UserofFriend Get(int id)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.QuerySingle<UserofFriend>("SELECT * FROM useroffriends WHERE id=@id;", new { id = id });
                return result;
            }
        }

        public List<UserofFriend> GetAll()
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.Query<UserofFriend>("SELECT * FROM useroffriends;").AsList();
                return result;
            }
        }

        public UserofFriend GetFriend(int userId, int friendId)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.QuerySingleOrDefault<UserofFriend>("SELECT * FROM useroffriends WHERE userid=@userId and friendid=@friendId;", new { userId = userId, friendId = friendId });
                return result ;
            }
        }

        public List<DtoUserFriend> GetFriendList(int userId)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.Query<DtoUserFriend>("SELECT u.id,uf.friendid,u.name,u.surname,u.email FROM users as u INNER JOIN useroffriends as uf ON u.id=uf.userid WHERE uf.friendid = @userId;", new { userId = userId }).AsList();
                return result;
            }
        }

        public bool GetIsFriend(int userId, int friendId)
        {
            using (var con = DpTermpProcject.CreateConnection())
            {
                var result = con.QuerySingleOrDefault<DtoUserFriend>("SELECT * FROM useroffriends WHERE userid=@userId and friendid=@friendId;", new { userId = userId, friendId = friendId });
                return result != null ? false : true;
            }
        }

        public int Update(UserofFriend entity)
        {
            throw new System.NotImplementedException();
        }


    }
}
