using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomesController : ControllerBase
    {
        //IoC Container  -- Inversion of Control
        IHomeService _homeService;

        public HomesController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            //Depemdency chain
           // Thread.Sleep(300);
            var result = _homeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int homeId)
        {
            var result = _homeService.GetById(homeId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Home home)
        {
            var result = _homeService.Add(home);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Home home)
        {
            var result = _homeService.Update(home);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Home home)
        {
            var result = _homeService.Delete(home);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbydailyprice")]
        public IActionResult GetByDailyPrice(decimal price)
        {
            var result = _homeService.GetByDailyPrice(price);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("gethomedetailsbyhomeid")]
        public IActionResult GetHomeDetailsByHomeId(int homeId)
        {
            var result = _homeService.GetHomeDetailsByHomeId(homeId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        
        [HttpGet("gethomedetails")]
        public IActionResult GetHomeDetails()
        {

            var result = _homeService.GetHomeDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("gethomesbycategoryid")]
        public IActionResult GetHomeByCategoryId(int categoryId)
        {
            var result = _homeService.GetHomeByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcarsbylocationid")]
        public IActionResult GetHomeByLocationId(int categoryId)
        {
            var result = _homeService.GetHomeByLocationId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbylocationandcategory")]
        public IActionResult GetHomeDetailByLocationAndCategory(int categoryId, int location)
        {
            var result = _homeService.GetHomeDetailByLocationAndCategory(categoryId, location);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);

        }

    }
}
