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
            if (result <= 0)
            {
                return new ErrorDataResult<int>(result);
            }
            return new SuccessDataResult<int>(result);
        }

        public IResult Delete(UserofFriend item)
        {
            _userofFriendsDal.Delete(item);
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

        public IDataResult< List<DtoUserFriends>> GetUserFriends(int userId)
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
