using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService:IBaseService<User>
    {
        IDataResult<DtoUser> Login(User user);
        User GetByMail(string email);
        IDataResult<List<User>> GetUsers(string mail);
        IDataResult<User> GetLastUser();
        IResult Delete(User item);
        IDataResult<List<DtoUser>> GetAllDto();
    }
}
