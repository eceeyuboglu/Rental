using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
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
    public class HomeImageManager :IHomeImageService
    {
        IHomeImageDal _homeImageDal;
       
        public HomeImageManager(IHomeImageDal homeImageDal)
        {
            _homeImageDal = homeImageDal;
        }

        //[ValidationAspect(typeof(UserImageValidator))]
        //[CacheRemoveAspect("IUserImageService.Get")]
        public IResult Add(HomeImageDto homeImagesDto)
        {
            var result = BusinessRules.Run(CheckUserImagesCount(homeImagesDto.HomeId));
            if (result != null) return result;
            HomeImage homeImage = new HomeImage
            {
                HomeId = homeImagesDto.HomeId,
                ImagePath = FileHelper.Add(homeImagesDto.ImageFile),
                HomeImageDate = DateTime.Now
            };
            _homeImageDal.Add(homeImage);
            return new SuccessResult("Home Image Added");
        }
        private IResult CheckUserImagesCount(int homeId)
        {
            var result = _homeImageDal.GetAll(ci => ci.HomeId == homeId).Count < 2;
            if (!result) return new ErrorResult("Home Image Count Exceeded");
            return new SuccessResult();
        }
        public IResult Update(HomeImageDto homeImagesDto)
        {
            var result = _homeImageDal.Get(ci => ci.HomeId == homeImagesDto.HomeId);
            if (result == null) return new ErrorResult("Home Image Not Found");
            FileHelper.Delete(result.ImagePath);
            result.ImagePath = FileHelper.Add(homeImagesDto.ImageFile);
            result.HomeImageDate = DateTime.Now;
            _homeImageDal.Update(result);
            return new SuccessResult("Home Image Updated");
        }
        //[ValidationAspect(typeof(UserImageValidator))]
        //[CacheRemoveAspect("IUserImageService.Get")]
        public IResult Delete(HomeImageDto homeImagesDto)
        {
            var result = _homeImageDal.Get(ci => ci.HomeId == homeImagesDto.HomeId);
            if (result == null) return new ErrorResult("Home Image Not Found");
            FileHelper.Delete(result.ImagePath);
            _homeImageDal.Delete(result);
            return new SuccessResult("Home Image Not Deleted");
        }
        //[ValidationAspect(typeof(UserImageValidator))]

        public IDataResult<HomeImage> Get(int homeId)
        {
            return new SuccessDataResult<HomeImage>(_homeImageDal.Get(c => c.HomeId == homeId));

        }

        public IDataResult<List<HomeImage>> GetAll()
        {
            return new SuccessDataResult<List<HomeImage>>(_homeImageDal.GetAll());
        }

        public IDataResult<List<HomeImage>> GetImagesByHomeId(int homeId)
        {
            IResult result = BusinessRules.Run(CheckIfUserImageNull(homeId));
            if (result != null)
            {
                return new ErrorDataResult<List<HomeImage>>(result.Message);
            }
            return new SuccessDataResult<List<HomeImage>>(_homeImageDal.GetAll(i => i.HomeId == homeId));
        }
        //[ValidationAspect(typeof(UserImageValidator))]
        //[CacheRemoveAspect("IUserImageService.Get")]

        private IResult CheckImageLimitExceeded(int homeId)
        {
            var homeImageCount = _homeImageDal.GetAll(c => c.HomeId == homeId).Count;
            if (homeImageCount > 1)
            {
                return new ErrorResult("Home Image Limit Exceeded");
            }
            return new SuccessResult();
        }
        private IDataResult<List<HomeImage>> CheckIfUserImageNull(int imageId)
        {
            try
            {
                string path = @"\wwwroot\images\crop.jpg";
                var result = _homeImageDal.GetAll(c => c.HomeId == imageId).Any();
                if (!result)
                {
                    List<HomeImage> images = new List<HomeImage>();


                    images.Add(new HomeImage() { HomeId = imageId, HomeImageDate = DateTime.Now, ImagePath = path });
                    return new SuccessDataResult<List<HomeImage>>(images);
                }

            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<HomeImage>>(e.Message);
            }

            return new SuccessDataResult<List<HomeImage>>(_homeImageDal.GetAll(i => i.HomeId == imageId));
        }
        

        public IResult DeleteByHomeId(int homeId)
        {
            var result = _homeImageDal.GetAll(ci => ci.HomeId == homeId);
            foreach (var item in result)
            {
                FileHelper.Delete(item.ImagePath);
                _homeImageDal.Delete(item);
            }
            return new SuccessResult("Home Images Deleted");
        }
    }
}
