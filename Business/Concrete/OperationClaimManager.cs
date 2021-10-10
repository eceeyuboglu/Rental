using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OperationClaimManager :IOperationClaimService
    {

        IOperationClaimDal _operationClaimDal;
        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        public IResult Add(OperationClaim operationClaim)
        {
            _operationClaimDal.Add(operationClaim);
            return new SuccessResult("OperationClaim Added");
        }

        public IResult Delete(OperationClaim operationClaim)
        {

            _operationClaimDal.Delete(operationClaim);
            return new SuccessResult("OperationClaim Deleted");
        }

        public IDataResult<List<OperationClaim>> GetAll()
        {

            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll(), "OperationClaim Listed");
        }

        public IDataResult<OperationClaim> GetById(int operationClaimId)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(b => b.OperationClaimId == operationClaimId));
        }


        public IResult Update(OperationClaim operationClaim)
        {
            _operationClaimDal.Update(operationClaim);
            return new SuccessResult("OperationClaim Updated");
        }
    }
}
