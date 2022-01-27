using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IDataResult<DtoUser> GetById(int id)
        {
            var result = _userDal.GetById(id);
            if (result != null)
            {
                return new SuccessDataResult<DtoUser>(result);
            }
            return new ErrorDataResult<DtoUser>();
        }
        public IDataResult<int> Add(User user)
        {
            var result = GetExistEmail(user.email, 0);
            if (!result.Success)
            {

                return new ErrorDataResult<int>(result.Message);
            }
            else
            {
                int getID = _userDal.Add(user);
                return new SuccessDataResult<int>(getID, Messages.UserAdded);
            }

        }
        public IResult Update(User user)
        {
            var result = GetExistEmail(user.email, user.id);
            if (!result.Success)
            { return new ErrorResult(result.Message); }
            else
            {
                int row = _userDal.Update(user);
                if (row > 0)
                {
                    return new SuccessResult(Messages.UserUpdated);
                }
                else
                {
                    return new ErrorResult(Messages.UserNotUpdated);
                }
            }
        }
        public IResult Delete(User user)
        {
         var result=   _userDal.Delete(user);
            if (result > 0)
            {
                return new SuccessResult(Messages.UserDeleted);
            }
            else
            {
                return new ErrorResult(Messages.UserNotDeleted);
            }
           
        }
        public IDataResult<User> GetLastUser()
        {
            var lastUser = _userDal.GetAll().LastOrDefault();
            return new SuccessDataResult<User>(lastUser);
        }
        public IDataResult<DtoUser> Login(User user)
        {
            var getUser = _userDal.GetLogin(user.email, user.password);
            if (getUser != null)
                return new SuccessDataResult<DtoUser>(getUser);
            else
                return new ErrorDataResult<DtoUser>();
        }
        private IResult GetExistEmail(string email, int id)
        {
            var getUser = _userDal.GetByEmail(email);
            if (getUser.Count == 0 || id == getUser[0].id)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.UserAlreadyExists);
        }
        public IDataResult<List<DtoUser>> GetAllDto()
        {
            var getAll = _userDal.GetDtoUsers();
            return new SuccessDataResult<List<DtoUser>>(getAll);
        }
        public IDataResult<List<User>> GetAll()
        {
            var getAll = _userDal.GetAll();
            return new SuccessDataResult<List<User>>(getAll);
        }
        public IDataResult<List<DtoUser>> GetUsers(string mail)
        {
            var getUsers = _userDal.GetByEmail(mail);
            if (getUsers.Count == 0)
            {
                return new ErrorDataResult<List<DtoUser>>();
            }
            return new SuccessDataResult<List<DtoUser>>(getUsers);
        }
        public IDataResult<User> Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
