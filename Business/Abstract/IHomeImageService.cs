using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

using System.Text;

namespace Business.Abstract
{
    public interface IHomeImageService
    {
        IResult Add(HomeImageDto homeImage);
        IResult Update(HomeImageDto homeImage);
        IResult Delete(HomeImageDto homeImage);
        IDataResult<HomeImage> Get(int imageId);
        IDataResult<List<HomeImage>> GetAll();
        IDataResult<List<HomeImage>> GetImagesByHomeId(int homeId);
        IResult DeleteByHomeId(int carId);
    }
}
