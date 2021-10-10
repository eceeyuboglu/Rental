using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ILocationService
    {
        IDataResult<List<Location>> GetAll();
        IDataResult<Location> GetById(int locationId);
        IResult Add(Location location);
        IResult Update(Location location);
        IResult Delete(Location location);
    }
}
