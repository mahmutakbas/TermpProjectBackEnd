using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class UserofFrinedManager : IUserofFriendService
    {
        IUserofFriendDal _userofFriendsDal;
        public UserofFrinedManager(IUserofFriendDal userofFriendsDal)
        {
            _userofFriendsDal = userofFriendsDal;
        }

        public IDataResult<int> Add(UserofFriend item)
        {
            if (GetFriend(item.userid, item.friendid).Success) { 
            var getBool = _userofFriendsDal.GetIsFriend(item.userid ,item.friendid);
            if (getBool)
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
            }
            }
            return new ErrorDataResult<int>(0, Messages.FriendAdd);
        }

        public IResult Delete(UserofFriend item)
        {
            _userofFriendsDal.Delete(item);
            var result = _userofFriendsDal.GetFriend(item.friendid ,item.userid);
            _userofFriendsDal.Delete(result);
            return new SuccessResult();
        }

        public IDataResult<UserofFriend> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<UserofFriend>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<UserofFriend> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult GetFriend(int userId, int friendId)
        {
            var result = _userofFriendsDal.GetFriend(userId, friendId);
            if (result == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<DtoUserFriend>> GetUserFriends(int userId)
        {
            var result = _userofFriendsDal.GetFriendList(userId);
            return new SuccessDataResult<List<DtoUserFriend>>(result);
        }

        public IResult Update(UserofFriend item)
        {
            throw new NotImplementedException();
        }
    }
}
