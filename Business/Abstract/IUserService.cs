using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);
        IDataResult<User> GetByMail(string email);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<List<string>> GetUserClaims(int userId);

        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IResult ProfileUpdate(User user);
        IResult UpdateUserDto(UserForRegisterDto user, int userId);
        IDataResult<List<UserDetailDto>> GetUserDetail(int userId);
        IDataResult<List<UserDetailDto>> GetUserDetails();
    }
}
