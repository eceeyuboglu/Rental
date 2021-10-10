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
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        IUserOperationClaimDal _userOperationClaimDal;
        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public IResult Add(UserOperationClaim entity)
        {
            _userOperationClaimDal.Add(entity);
            return new SuccessResult("UserOperationClaim Added");
        }

        public IResult Delete(UserOperationClaim userOperationClaim)
        {

            _userOperationClaimDal.Delete(userOperationClaim);
            return new SuccessResult("UserOperationClaim Deleted");
        }

        public IDataResult<List<UserOperationClaim>> GetAll()
        {

            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll(), "UserOperationClaim Listed");
        }

        public IDataResult<UserOperationClaim> GetById(int id)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(b => b.Id == id));
        }


        public IResult Update(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Update(userOperationClaim);
            return new SuccessResult("OperationClaim Updated");
        }
    }
}
