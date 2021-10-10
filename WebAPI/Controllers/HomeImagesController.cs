using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeImagesController :ControllerBase
    {
        IHomeImageService _homeImageService;

        public HomeImagesController(IHomeImageService homeImageService)
        {
            _homeImageService = homeImageService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _homeImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById([FromForm(Name = ("Id"))] int ImageId)
        {
            var result = _homeImageService.Get(ImageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm] HomeImageDto homeImagesDto)
        {
            var result = _homeImageService.Add(homeImagesDto);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] HomeImageDto homeImagesDto)
        {
            var result = _homeImageService.Update(homeImagesDto);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(HomeImageDto homeImagesDto)
        {
            var result = _homeImageService.Delete(homeImagesDto);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getimagesbyhomeid")]
        public IActionResult GetImagesByHomeId(int homeId)
        {
            var result = _homeImageService.GetImagesByHomeId(homeId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
