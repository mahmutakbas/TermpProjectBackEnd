﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRouteOfUserService
    {
        IDataResult<RouteOfUser> Get(int id);
        IDataResult<List<RouteOfUser>> GetAll();
        IDataResult<int> Add(RouteOfUser routeOfUser);
        IResult Update(RouteOfUser routeOfUser);
        IDataResult<RouteOfUser> GetById(int id);
        IDataResult<List<DtoRoute>> GetRoutes(int userid);
        IDataResult<List<DtoRoute>> GetOtherUserRoutes(int userid);
        IResult Delete(RouteOfUser item);
    }
}
