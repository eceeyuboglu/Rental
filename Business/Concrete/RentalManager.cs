using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        IHomeService _homeService;
        ICustomerService _customerService;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        
        public IResult Add(Rental rental)
        {
            if (!IsHomeAvailable(rental.HomeId)) return new ErrorResult(Messages.HomeIsntAvailable);
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult CheckIfFindeks(int homeId, int customerId)
        {
            var customer = _customerService.GetById(customerId).Data;
            var car = _homeService.GetById(homeId).Data;
            if (customer.CustomerFindex < car.HomeFindex)
            {
                return new ErrorResult("NotEngouhFindeks");
            }
            return new SuccessResult("EngouhFindeks");
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<Rental> Get(Rental entity)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(x => x.RentalId == entity.RentalId));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<List<Rental>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CustomerId == customerId));

        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            Rental r = new Rental();
            if (_rentalDal.GetAll().Any(x => x.RentalId == rentalId))
            {
                r = _rentalDal.GetAll().FirstOrDefault(x => x.RentalId == rentalId);
            }
            else Console.WriteLine("NotExist" + "rental");
            return new SuccessDataResult<Rental>(r);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());

        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsByHomeId(int homeId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetail(r => r.HomeId == homeId), Messages.RentalListed);

        }

        public IResult HomeIsReturned(int homeId)
        {
            Rental result = _rentalDal.Get(r => r.HomeId == homeId && r.ReturnDate == null);
            result.ReturnDate = DateTime.Now;
            _rentalDal.Update(result);
            return new SuccessResult(Messages.RentalUpdated);

        }

        public bool IsHomeAvailable(int homeId)
        {
            Rental result = _rentalDal.Get(r => r.HomeId == homeId && r.ReturnDate == null);
            return result == null ? true : false;
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
