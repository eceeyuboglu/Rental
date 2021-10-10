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
    public class HostImageManager :IHostImageService
    {
        IHostImageDal _hostImageDal;
        public HostImageManager(IHostImageDal hostImageDal)
        {
            _hostImageDal = hostImageDal;
        }

        //[ValidationAspect(typeof(UserImageValidator))]
        //[CacheRemoveAspect("IUserImageService.Get")]
        public IResult Add(HostImageDto hostImagesDto)
        {
            var result = BusinessRules.Run(CheckUserImagesCount(hostImagesDto.HostId));
            if (result != null) return result;
            HostImage hostImage = new HostImage
            {
                HostId = hostImagesDto.HostId,
                ImagePath = FileHelper.Add(hostImagesDto.ImageFile),
                Date = DateTime.Now
            };
            _hostImageDal.Add(hostImage);
            return new SuccessResult("Host Image Added");
        }
        private IResult CheckUserImagesCount(int hostId)
        {
            var result = _hostImageDal.GetAll(ci => ci.HostId == hostId).Count < 2;
            if (!result) return new ErrorResult("Host Image Count Exceeded");
            return new SuccessResult();
        }
        public IResult Update(HostImageDto hostImagesDto)
        {
            var result = _hostImageDal.Get(ci => ci.HostId == hostImagesDto.HostId);
            if (result == null) return new ErrorResult("Host Image Not Found");
            FileHelper.Delete(result.ImagePath);
            result.ImagePath = FileHelper.Add(hostImagesDto.ImageFile);
            result.Date = DateTime.Now;
            _hostImageDal.Update(result);
            return new SuccessResult("Host Image Updated");
        }
        //[ValidationAspect(typeof(UserImageValidator))]
        //[CacheRemoveAspect("IUserImageService.Get")]
        public IResult Delete(HostImageDto hostImagesDto)
        {
            var result = _hostImageDal.Get(ci => ci.HostId == hostImagesDto.HostId);
            if (result == null) return new ErrorResult("Host Image Not Found");
            FileHelper.Delete(result.ImagePath);
            _hostImageDal.Delete(result);
            return new SuccessResult("Host Image Not Deleted");
        }
        //[ValidationAspect(typeof(UserImageValidator))]

        public IDataResult<HostImage> Get(int hostId)
        {
            return new SuccessDataResult<HostImage>(_hostImageDal.Get(c => c.HostId == hostId));

        }

        public IDataResult<List<HostImage>> GetAll()
        {
            return new SuccessDataResult<List<HostImage>>(_hostImageDal.GetAll());
        }

        public IDataResult<List<HostImage>> GetImagesByUserId(int userId)
        {
            IResult result = BusinessRules.Run(CheckIfUserImageNull(userId));
            if (result != null)
            {
                return new ErrorDataResult<List<HostImage>>(result.Message);
            }
            return new SuccessDataResult<List<HostImage>>(_hostImageDal.GetAll(i => i.HostId == userId));
        }
        //[ValidationAspect(typeof(UserImageValidator))]
        //[CacheRemoveAspect("IUserImageService.Get")]

        private IResult CheckImageLimitExceeded(int hostId)
        {
            var hostImageCount = _hostImageDal.GetAll(c => c.HostId == hostId).Count;
            if (hostImageCount > 1)
            {
                return new ErrorResult("Host Image Limit Exceeded");
            }
            return new SuccessResult();
        }
        private IDataResult<List<HostImage>> CheckIfUserImageNull(int imageId)
        {
            try
            {
                string path = @"\wwwroot\images\crop.jpg";
                var result = _hostImageDal.GetAll(c => c.HostId == imageId).Any();
                if (!result)
                {
                    List<HostImage> images = new List<HostImage>();


                    images.Add(new HostImage() { HostId = imageId, Date = DateTime.Now, ImagePath = path });
                    return new SuccessDataResult<List<HostImage>>(images);
                }

            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<HostImage>>(e.Message);
            }

            return new SuccessDataResult<List<HostImage>>(_hostImageDal.GetAll(i => i.HostId == imageId));
        }
        private IDataResult<List<HostImage>> CheckIfHostImageNull(int imageId)
        {
            try
            {
                string path = @"\wwwroot\images\crop.jpg";
                var result = _hostImageDal.GetAll(c => c.HostId == imageId).Any();
                if (!result)
                {
                    List<HostImage> images = new List<HostImage>();


                    images.Add(new HostImage() { HostId = imageId, Date = DateTime.Now, ImagePath = path });
                    return new SuccessDataResult<List<HostImage>>(images);
                }

            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<HostImage>>(e.Message);
            }

            return new SuccessDataResult<List<HostImage>>(_hostImageDal.GetAll(i => i.HostId == imageId));
        }
        public IResult DeleteByUserId(int userId)
        {
            var result = _hostImageDal.GetAll(ci => ci.HostId == userId);
            foreach (var item in result)
            {
                FileHelper.Delete(item.ImagePath);
                _hostImageDal.Delete(item);
            }
            return new SuccessResult("Host Images Deleted");
        }

        public IDataResult<List<HostImage>> GetImagesByHostId(int hostId)
        {
            IResult result = BusinessRules.Run(CheckIfHostImageNull(hostId));
            if (result != null)
            {
                return new ErrorDataResult<List<HostImage>>(result.Message);
            }
            return new SuccessDataResult<List<HostImage>>(_hostImageDal.GetAll(i => i.HostId == hostId));
        }

        public IResult DeleteByHostId(int hostId)
        {
            var result = _hostImageDal.GetAll(ci => ci.HostId == hostId);
            foreach (var item in result)
            {
                FileHelper.Delete(item.ImagePath);
                _hostImageDal.Delete(item);
            }
            return new SuccessResult("Host Images Deleted");
        }
    }
}
