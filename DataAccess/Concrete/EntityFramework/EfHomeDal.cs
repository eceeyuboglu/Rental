using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfHomeDal : EfEntityRepositoryBase<Home, RentContext>, IHomeDal
    {
        
        public HomeDetailDto GetHomeDetail(Expression<Func<HomeDetailDto, bool>> filter)
        {
            using (RentContext context = new RentContext())
            {
                var result = from c in context.Home
                             join b in context.Amenity on c.AmenityId equals b.AmenityId
                             join r in context.Host on c.HostId equals r.HostId
                             join e in context.Category on c.CategoryId equals e.CategoryId
                             join l in context.Location
                            on c.LocationId equals l.LocationId
                             let i = context.HomeImage.Where(x => x.HomeId == c.HomeId).FirstOrDefault()
                             select new HomeDetailDto()
                             {
                                 
                                 HomeId = c.HomeId,
                                 AmenityId = b.AmenityId,
                                 DailyPrice = c.DailyPrice,
                                 HostId = r.HostId,
                                 Description = c.Description,
                                 HomeFindex = c.HomeFindex,
                                 LocationId = c.LocationId
                             };
                return result.SingleOrDefault(filter);
            }
        }

        public List<HomeDetailDto> GetHomeDetails(Expression<Func<Home, bool>> filter = null)
        {
            using (RentContext context = new RentContext())
            {
                var result = from p in filter == null ? context.Home : context.Home.Where(filter)
                             join c in context.Location on p.LocationId equals c.LocationId
                             join d in context.Host on p.HostId equals d.HostId
                             join a in context.Amenity on p.AmenityId equals a.AmenityId
                             join e in context.Category on p.CategoryId equals e.CategoryId
                             select new HomeDetailDto
                             {
                                 HomeId = p.HomeId,
                                 Year = p.Year,
                                 HostId = d.HostId,
                                 HostName = d.HostName,
                                 HostSurname = d.HostSurname,
                                 HostCity = d.HostCity,
                                 Email = d.Email,
                                 LocationId = c.LocationId,
                                 CategoryId = e.CategoryId,
                                 CategoryName = e.CategoryName,
                                 AmenityId = a.AmenityId,
                                 AmenityName = a.AmenityName,
                                 DailyPrice = p.DailyPrice,
                                 Description = p.Description,
                                 Area = c.Area,
                                 City = c.City,
                                 District = c.District,
                                 BedroomCount = p.BedroomCount,
                                 BathroomCount = p.BathroomCount,
                                 ImagePath = context.HomeImage.Where(x => x.HomeId == p.HomeId).FirstOrDefault().ImagePath,

                                 HomeFindex = p.HomeFindex


                             };
                return result.ToList();
            }
        }
    }
}
