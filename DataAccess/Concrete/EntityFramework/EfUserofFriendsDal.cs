using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserofFriendsDal : EfEntityRepositoryBase<UserofFriend, TermProjectDbContext>
    {
        public List<User> GetFriendList(int userId)
        {
            using (TermProjectDbContext context = new TermProjectDbContext())
            {
                var list = (from u in context.Users
                            join f in context.UserofFriends on u.id equals f.userid
                            where f.friendid == userId
                            select new User
                            {
                                id = u.id,
                                name = u.name,
                                surname = u.surname,
                                email = u.email
                            }).ToList();
                return list;
            }

        }
    }
}
