using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class UserofFrinedManager : IUserofFriendService
    {
        IUserofFriendsDal _userofFriendsDal;
        public UserofFrinedManager(IUserofFriendsDal userofFriendsDal)
        {
            _userofFriendsDal = userofFriendsDal;
        }

        public IDataResult<int> Add(UserofFriend item)
        {
            var result = _userofFriendsDal.Add(item);

            if (result > 0)
            {
                var result1 = _userofFriendsDal.Add(new UserofFriend { userid = item.friendid, friendid = item.userid });
                if (result1 > 0)
                {
                    return new SuccessDataResult<int>(result);
                }
                else
                {
                    return new ErrorDataResult<int>(result1);

                }
            }
            return new ErrorDataResult<int>(result);

        }

        public IResult Delete(UserofFriend item)
        {
            _userofFriendsDal.Delete(item);
           var result= _userofFriendsDal.Get(f => f.userid == item.friendid && f.friendid == item.userid);
            _userofFriendsDal.Delete(result);
            return new SuccessResult();
        }

        public IDataResult<List<UserofFriend>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<UserofFriend> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<DtoUserFriends>> GetUserFriends(int userId)
        {
            var result = _userofFriendsDal.GetFriendList(userId);

            return new SuccessDataResult<List<DtoUserFriends>>(result);
        }

        public IResult Update(UserofFriend item)
        {
            throw new NotImplementedException();
        }
    }
}
