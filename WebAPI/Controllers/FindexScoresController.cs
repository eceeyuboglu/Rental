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
    public class FindexScoresController : ControllerBase
    {
        IFindexScoreService _findexScoreService;

        public FindexScoresController(IFindexScoreService findexScoreService)
        {
            _findexScoreService = findexScoreService;
        }

        [HttpGet("getbyfindexscoreid")]
        public IActionResult GetById(int findexScoreId)
        {
            var result = _findexScoreService.GetById(findexScoreId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var result = _findexScoreService.GetByCustomerId(customerId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _findexScoreService.GetAll();
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(FindexScore findexScore)
        {
            var result = _findexScoreService.Add(findexScore);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(FindexScore findexScore)
        {
            var result = _findexScoreService.Update(findexScore);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(FindexScore findexScore)
        {
            var result = _findexScoreService.Delete(findexScore);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

    }
}
