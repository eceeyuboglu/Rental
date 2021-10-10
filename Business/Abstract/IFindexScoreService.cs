using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFindexScoreService
    {
        IDataResult<FindexScore> GetById(int id);

        IDataResult<FindexScore> GetByCustomerId(int customerId);

        IDataResult<List<FindexScore>> GetAll();

        IResult Add(FindexScore findexScore);

        IResult Update(FindexScore findexScore);

        IResult Delete(FindexScore findexScore);

        IDataResult<FindexScore> CalculateFindeksScore(FindexScore findexScore);
    }
}
