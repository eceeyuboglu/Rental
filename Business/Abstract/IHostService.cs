using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IHostService
    {
        IDataResult<List<Host>> GetAll();
        IDataResult<Host> GetById(int customerId);
        IResult Add(Host customer);
        IResult Update(Host customer);
        IResult Delete(Host customer);
        
    }
}
