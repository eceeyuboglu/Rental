using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (RentContext context = new RentContext())
            {
                var result = from rental in context.Rental
                             join home in context.Home on rental.HomeId equals home.HomeId
                             join customer in context.Customer on rental.CustomerId equals customer.CustomerId
                             join user in context.User on customer.UserId equals user.UserId
                             join amenity in context.Amenity on home.AmenityId equals amenity.AmenityId
                             join category in context.Category on home.CategoryId equals category.CategoryId
                             select new RentalDetailDto
                             {

                                 RentalId = rental.RentalId,
                                 DailyPrice = home.DailyPrice,
                                 Description = home.Description,
                                 CardId= rental.CardId,
                                 HomeId = rental.HomeId,
                                 Name = user.FirstName,
                                 Surname = user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,
                                 CustomerId = rental.CustomerId
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentContext context = new RentContext())
            {
                var result = from rental in context.Rental
                             join home in context.Home on rental.HomeId equals home.HomeId
                             join customer in context.Customer on rental.CustomerId equals customer.CustomerId
                             join user in context.User on customer.UserId equals user.UserId
                             join amenity in context.Amenity on home.AmenityId equals amenity.AmenityId
                             join category in context.Category on home.CategoryId equals category.CategoryId
                             select new RentalDetailDto
                             {
                                 RentalId = rental.RentalId,
                                 HomeId = rental.HomeId,
                                 Name = user.FirstName,
                                 Surname = user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,
                                 CustomerId = rental.CustomerId
                             };
                return result.ToList();
            }
        }
    }
}
