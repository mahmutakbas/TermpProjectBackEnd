using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IUserDal : IDapperRepository<User>
    {
        List<DtoUser> GetDtoUsers();
        DtoUser GetLogin(string email,string password);
        List<DtoUser> GetByEmail(string email);
        DtoUser GetById(int id);
        DtoUser GetExistEmail(string email);
    }
}
