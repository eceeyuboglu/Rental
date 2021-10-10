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
    public class HostImageControllers :ControllerBase
    {
        IHostImageService _hostImageService;

        public HostImageControllers(IHostImageService hostImageService)
        {
            _hostImageService = hostImageService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _hostImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById([FromForm(Name = ("Id"))] int ImageId)
        {
            var result = _hostImageService.Get(ImageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm] HostImageDto hostImagesDto)
        {
            var result = _hostImageService.Add(hostImagesDto);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] HostImageDto hostImagesDto)
        {
            var result = _hostImageService.Update(hostImagesDto);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(HostImageDto hostImagesDto)
        {
            var result = _hostImageService.Delete(hostImagesDto);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getimagesbyhostid")]
        public IActionResult GetImagesByHostId(int hostId)
        {
            var result = _hostImageService.GetImagesByHostId(hostId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
