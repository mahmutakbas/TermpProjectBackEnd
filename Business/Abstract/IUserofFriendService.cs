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
    public interface IUserofFriendService:IBaseService<UserofFriend>
    {
       IDataResult<List<DtoUserFriends>> GetUserFriends(int userId);
        IResult Delete(UserofFriend item);
    }
}
