using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAmenityService
    {
        IDataResult<List<Amenity>> GetAll();
        IDataResult<Amenity> GetById(int amenityId);
        IResult Add(Amenity amenity);
        IResult Update(Amenity amenity);
        IResult Delete(Amenity amenity);
    }
}
