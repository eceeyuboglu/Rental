﻿using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IDataResult<List<UserOperationClaim>> GetAll();
        IDataResult<UserOperationClaim> GetById(int id);
        IResult Add(UserOperationClaim userOperationClaim);
        IResult Delete(UserOperationClaim userOperationClaim);
        IResult Update(UserOperationClaim userOperationClaim);
    }
}
