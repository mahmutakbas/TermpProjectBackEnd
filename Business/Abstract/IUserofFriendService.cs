using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserofFriendService
    {
        IDataResult<UserofFriend> Get(int id);
        IDataResult<List<UserofFriend>> GetAll();
        IDataResult<int> Add(UserofFriend userofFriend);
        IResult Update(UserofFriend userofFriend);
        IDataResult<List<DtoUserFriend>> GetUserFriends(int userId);
        IResult Delete(UserofFriend item);
        IResult GetFriend(int userId, int friendId);
    }
}
