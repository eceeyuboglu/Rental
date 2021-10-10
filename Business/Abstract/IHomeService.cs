using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IHomeService
    {
        IDataResult<List<Home>> GetAll();
        IDataResult<List<HomeDetailDto>> GetHomeByLocation(int locationId);
        IDataResult<List<HomeDetailDto>> GetHomeByLocationId(int locationId);
        IDataResult<List<HomeDetailDto>> GetHomeByCategoryId(int categoryId);
        IDataResult<List<HomeDetailDto>> GetHomeByCategory(int categoryId);
        IDataResult<List<HomeDetailDto>> GetHomeByFindexScore(int findexScoreId);
        IDataResult<Home> GetById(int homeId);
        IDataResult<List<Home>> GetByDailyPrice(decimal min);
        IResult Add(Home home);
        IResult Update(Home home);
        IResult Delete(Home home);
        IDataResult<List<HomeDetailDto>> GetHomeDetails();
        IDataResult<List<HomeDetailDto>> GetHomeDetailsByHomeId(int homeId);
        IDataResult<List<HomeDetailDto>> GetHomeDetailByLocationAndCategory(int locationId, int categoryId);


    }
}
