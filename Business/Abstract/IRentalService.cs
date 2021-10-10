using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<List<Rental>> GetAll();
        
        IDataResult<Rental> GetById(int rentalId);
        bool IsHomeAvailable(int homeId);
        
        IDataResult<Rental> Get(Rental entity);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        
        IDataResult<List<RentalDetailDto>> GetRentalDetailsByHomeId(int homeId);
        IDataResult<List<Rental>> GetByCustomerId(int customerId);
        
        IResult HomeIsReturned(int homeId);

        IResult CheckIfFindeks(int homeId, int customerId);
        
    }
}

        