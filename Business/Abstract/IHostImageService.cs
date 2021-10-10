using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IHostImageService
    {
        IResult Add(HostImageDto hostImage);
        IResult Update(HostImageDto hostImage);
        IResult Delete(HostImageDto hostImage);
        IDataResult<HostImage> Get(int imageId);
        IDataResult<List<HostImage>> GetAll();
        IDataResult<List<HostImage>> GetImagesByHostId(int hostId);
        IResult DeleteByHostId(int hostId);
    }
}
