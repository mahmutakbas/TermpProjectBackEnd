using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IUserofFriendDal : IDapperRepository<UserofFriend>
    {
        List<DtoUserFriend> GetFriendList(int userId);
        bool GetIsFriend(int userId, int friendId);
        UserofFriend GetFriend(int userId, int friendId);
    }
}
