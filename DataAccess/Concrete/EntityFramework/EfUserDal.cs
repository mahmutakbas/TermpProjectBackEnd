using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, TermProjectDbContext>, IUserDal
    {
        public List<DtoUser> GetDtoUsers()
        {
            List<DtoUser> dtoUsers =(from user in GetAll()
                                                  select new DtoUser
                                                  {
                                                      id = user.id,
                                                      name = user.name,
                                                      updatedate = user.updatedate,
                                                      email = user.email,
                                                      createdate = user.createdate,
                                                      surname = user.surname,
                                                      status = user.status
                                                  }).ToList();
            return dtoUsers;
        }
    }
}
