using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new RentContext())
            {
                var result = from operationClaim in context.OperationClaim
                             join userOperationClaim in context.UserOperationClaim
                                 on operationClaim.OperationClaimId equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim { OperationClaimId = operationClaim.OperationClaimId, Name = operationClaim.Name };
                return result.ToList();

            }
        }

        public UserDetailDto GetUserDetail(Expression<Func<UserDetailDto, bool>> filter)
        {
            using (RentContext context = new RentContext())
            {
                var result = from u in context.User
                             join c in context.Customer
                             on u.UserId equals c.UserId
                             join r in context.Rental
                                 on c.CustomerId equals r.CustomerId
                             join home in context.Home on r.HomeId equals home.HomeId
                             join a in context.Amenity on home.AmenityId equals a.AmenityId
                             let x = context.User.Where(x => x.UserId == u.UserId).FirstOrDefault()
                             select new UserDetailDto()
                             {
                                 Name = u.FirstName,
                                 Surname = u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = (DateTime)r.ReturnDate,
                                 Email = u.Email,
                                 UserId = u.UserId,
                             };
                return result.SingleOrDefault(filter);
            }
        }

        public List<UserDetailDto> GetUserDetails(Expression<Func<User, bool>> filter = null)
        {
            using (RentContext context = new RentContext())
            {
                var result = from u in filter == null ? context.User : context.User.Where(filter)
                             join uoc in context.UserOperationClaim
                             on u.UserId equals uoc.UserId
                             join oc in context.OperationClaim
                             on uoc.OperationClaimId equals oc.OperationClaimId
                             join c in context.Customer
                              on u.UserId equals c.UserId
                             let x = context.User.Where(x => x.UserId == u.UserId).FirstOrDefault()
                             select new UserDetailDto
                             {
                                 
                                 Name = u.FirstName,
                                 Surname = u.LastName,
                                 Email = u.Email,
                                 UserId = u.UserId,


                             };
                return result.ToList();
            }

        }

    }
    }

