using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<int> Add(User user);
        IResult Update(User user);
        IDataResult<DtoUser> GetById(int id);
        IDataResult<DtoUser> Login(User user);
        IDataResult<List<DtoUser>> GetUsers(string mail);
        IResult Delete(User item);
        IDataResult<List<DtoUser>> GetAllDto();
    }
}
