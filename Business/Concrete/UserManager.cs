using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class UserManager :IUserService
    {
        IUserDal _userDal;
        IUserOperationClaimService _userOperationClaimService;



        public UserManager(IUserDal userDal, IUserOperationClaimService userOperationClaimService)
        {
            _userDal = userDal;
            _userOperationClaimService = userOperationClaimService;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            IResult result = BusinessRules.Run(
                CheckIfUserExists(user.Email));
            if (result != null)
            {
                return result;
            }
            _userDal.Add(user);
            _userOperationClaimService.Add(new UserOperationClaim { UserId = user.UserId, OperationClaimId = 2 });
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId));
        }

        //[ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<List<string>> GetUserClaims(int userId)
        {
            var user = _userDal.GetAll().Where(x => x.UserId == userId).FirstOrDefault();
            return new SuccessDataResult<List<string>>(_userDal.GetClaims(user).Select(x => x.Name).ToList());
        }


        public IResult ProfileUpdate(User user)
        {
            var userToUpdate = GetById(user.UserId).Data;
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Email = user.Email;
            Update(userToUpdate);
            return new SuccessResult();
        }

        public IResult UpdateUserDto(UserForRegisterDto user, int userId)
        {
            var u = _userDal.GetAll().Where(x => x.UserId == userId).FirstOrDefault();
            if (user.FirstName != null && user.FirstName != "" && user.FirstName != " ")
            {
                u.FirstName = user.FirstName;
            }
            if (user.LastName != null && user.LastName != "" && user.LastName != " ")
            {
                u.LastName = user.LastName;
            }
            if (user.Email != null && user.Email != "" && user.Email != " ")
            {
                u.Email = user.Email;
            }
            if (user.Password != null && user.Password != "" && user.Password != " ")
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);
                u.PasswordHash = passwordHash;
                u.PasswordSalt = passwordSalt;
            }
            _userDal.Update(u);
            return new SuccessResult("User Info Updated");
        }
        private IResult CheckIfUserExists(string email)
        {
            var result = _userDal.GetAll(u => u.Email == email).Any();
            if (result)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<List<UserDetailDto>> GetUserDetail(int userId)
        {

            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetails(c => c.UserId == userId));

        }
        public IDataResult<List<UserDetailDto>> GetUserDetails()
        {
            List<UserDetailDto> userDetails = _userDal.GetUserDetails();
            if (userDetails == null)
            {
                return new ErrorDataResult<List<UserDetailDto>>();
            }
            else
            {
                return new SuccessDataResult<List<UserDetailDto>>(userDetails);
            }
        }
    }
}
