using Core.DataAccess;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IUserofFriendsDal : IEntityRepository<UserofFriend>
    {
        List<Entities.DTOs.DtoUserFriends> GetFriendList(int userId);
    }
}
