using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostsControllers :ControllerBase
    {
        IHostService _hostService;
        public HostsControllers(IHostService hostService)
        {
            _hostService = hostService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _hostService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int hostId)
        {
            var result = _hostService.GetById(hostId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
       
        
        [HttpPost("add")]
        public IActionResult Add(Host host)
        {
            var result = _hostService.Add(host);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(Host host)
        {
            var result = _hostService.Update(host);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Host host)
        {
            var result = _hostService.Delete(host);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
       
    }
}
