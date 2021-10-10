using Business.Abstract;
using Business.BusinessAspect.AutoFac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Caching;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class HomeManager : IHomeService
    {
        IHomeDal _homeDal;
        public HomeManager(IHomeDal homeDal)
        {
            _homeDal = homeDal;
        }
        //Claim
        [SecuredOperation("home.add,admin")]
        [ValidationAspect(typeof(HomeValidator))]
        [CacheRemoveAspect("IHomeService.Get")]
        public IResult Add(Home home)
        {
            _homeDal.Add(home);
            return new SuccessResult("Home Added");
        }
        [SecuredOperation("admin")]
        public IResult Delete(Home home)
        {
            _homeDal.Delete(home);
            return new SuccessResult(Messages.HomeDeleted);
        }

        public IDataResult<List<Home>> GetAll()
        {
            if (DateTime.Now.Hour == 10)
            {
                return new ErrorDataResult<List<Home>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Home>>(_homeDal.GetAll(), Messages.HomeListed);
        }

        public IDataResult<List<Home>> GetByDailyPrice(decimal min)
        {
            return new SuccessDataResult<List<Home>>(_homeDal.GetAll(c => c.DailyPrice > min));
        }

        public IDataResult<Home> GetById(int homeId)
        {
            return new SuccessDataResult<Home>(_homeDal.Get(p => p.HomeId == homeId));
        }

        public IDataResult<List<HomeDetailDto>> GetHomeByCategory(int categoryId)
        {
            return new SuccessDataResult<List<HomeDetailDto>>(_homeDal.GetHomeDetails(c => c.CategoryId == categoryId));
        }

        public IDataResult<List<HomeDetailDto>> GetHomeByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<HomeDetailDto>>(_homeDal.GetHomeDetails(c => c.CategoryId == categoryId));
        }

        public IDataResult<List<HomeDetailDto>> GetHomeByFindexScore(int findexScoreId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<HomeDetailDto>> GetHomeByLocation(int locationId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<HomeDetailDto>> GetHomeByLocationId(int locationId)
        {
            return new SuccessDataResult<List<HomeDetailDto>>(_homeDal.GetHomeDetails(b => b.LocationId == locationId));
        }

        public IDataResult<List<HomeDetailDto>> GetHomeDetailsByHomeId(int homeId)
        {
            return new SuccessDataResult<List<HomeDetailDto>>(_homeDal.GetHomeDetails(c => c.HomeId == homeId));

        }

        public IDataResult<List<HomeDetailDto>> GetHomeDetailByLocationAndCategory(int locationId, int categoryId)
        {
            return new SuccessDataResult<List<HomeDetailDto>>(_homeDal.GetHomeDetails(p => p.LocationId == locationId && p.CategoryId == categoryId));
        }

        public IDataResult<List<HomeDetailDto>> GetHomeDetails()
        {
            List<HomeDetailDto> carDetails = _homeDal.GetHomeDetails();
            if (carDetails == null)
            {
                return new ErrorDataResult<List<HomeDetailDto>>();
            }
            else
            {
                return new SuccessDataResult<List<HomeDetailDto>>();
            }
        }
        [SecuredOperation("admin")]
        public IResult Update(Home home)
        {
            _homeDal.Update(home);
            return new SuccessResult(Messages.HomeUpdated);
        }
    }
}
