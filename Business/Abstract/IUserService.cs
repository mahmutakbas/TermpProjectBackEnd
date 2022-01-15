using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService:IBaseService<User>
    {
        IDataResult<User> Login(User user);
        User GetByMail(string email);
        IDataResult<User> GetLastUser();
        IDataResult<List<DtoUser>> GetAllDto();
    }
}
