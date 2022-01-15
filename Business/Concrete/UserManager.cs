using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.email == email);
        }

        public IDataResult<User> GetById(int id)
        { var result = _userDal.Get(user => user.id == id);
            if (result != null)
            {
                return new SuccessDataResult<User>(result);
            }
            return new ErrorDataResult<User>();
           
        }

        public IDataResult<int> Add(User user)
        {
            var result = GetExistEmail(user.email);
            if (!result.Success)
            { return new ErrorDataResult<int>(result.Message); }
            else
            {
                _userDal.Add(user);
                return new SuccessDataResult<int>(Messages.UserAdded);
            }

        }

        public IResult Update(User user)
        {
            var result = GetExistEmail(user.email);
            if (!result.Success)
            { return new ErrorResult(result.Message); }
            else
            {
                _userDal.Update(user);
                return new SuccessResult(Messages.UserUpdated);
            }

        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<User> GetLastUser()
        {
            var lastUser = _userDal.GetAll().LastOrDefault();
            return new SuccessDataResult<User>(lastUser);
        }
        public IDataResult<User> Login(User user)
        {
            var getUser = _userDal.Get(u => u.email == user.email && u.password == user.password);
            if (getUser != null)
                return new SuccessDataResult<User>(getUser);
            else
                return new ErrorDataResult<User>();
        }
        private IResult GetExistEmail(string email)
        {
            var getUser = _userDal.GetAll(u => u.email == email);
            if (getUser.Count == 0)
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
    }
}
