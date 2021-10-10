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
    public class FindexScoreManager :IFindexScoreService
    {
        IFindexScoreDal _findexScoreDal;

        public FindexScoreManager(IFindexScoreDal findexScoreDal)
        {
            _findexScoreDal = findexScoreDal;
        }

        public IResult Add(FindexScore findexScore)
        {
            _findexScoreDal.Add(findexScore);
            return new SuccessResult(Messages.FindexScoreAdded);
        }

        public IDataResult<FindexScore> CalculateFindeksScore(FindexScore findexScore)
        {
            findexScore.Score = new Random().Next(900, 1900);

            return new SuccessDataResult<FindexScore>(findexScore);
        }

        public IResult Delete(FindexScore findexScore)
        {
            _findexScoreDal.Delete(findexScore);

            return new SuccessResult(Messages.FindexScoreDeleted);
        }

        public IDataResult<List<FindexScore>> GetAll()
        {
            return new SuccessDataResult<List<FindexScore>>(_findexScoreDal.GetAll());
        }

        public IDataResult<FindexScore> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<FindexScore>(_findexScoreDal.Get(f => f.CustomerId == customerId));
        }

        public IDataResult<FindexScore> GetById(int findexScoreId)
        {
            return new SuccessDataResult<FindexScore>(_findexScoreDal.Get(f => f.FindexScoreId == findexScoreId));
        }

        public IResult Update(FindexScore findeksScore)
        {
            _findexScoreDal.Update(findeksScore);

            return new SuccessResult(Messages.FindexScoreUpdated);
        }
    }
}
