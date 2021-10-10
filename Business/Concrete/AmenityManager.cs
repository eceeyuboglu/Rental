using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AmenityManager :IAmenityService
    {
        IAmenityDal _amenityDal;

        public AmenityManager(IAmenityDal amenityDal)
        {
            _amenityDal = amenityDal;
        }

        public IResult Add(Amenity amenity)
        {
            _amenityDal.Add(amenity);
            return new SuccessResult(Messages.AmenityAdded);
        }

        public IResult Delete(Amenity amenity)
        {
            _amenityDal.Delete(amenity);
            return new SuccessResult(Messages.AmenityDeleted);
        }

        public IDataResult<List<Amenity>> GetAll()
        {
            return new SuccessDataResult<List<Amenity>>(_amenityDal.GetAll(), Messages.AmenityListed);
        }

        public IDataResult<Amenity> GetById(int amenityId)
        {
            return new SuccessDataResult<Amenity>(_amenityDal.Get(c => c.AmenityId == amenityId));
        }

        public IResult Update(Amenity amenity)
        {
            _amenityDal.Update(amenity);
            return new SuccessResult(Messages.AmenityUpdated);
        }
    }
}
