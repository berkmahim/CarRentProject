using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;
        //Car _car;
        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            if (result.Succeded)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _brandService.GetById(id);
            if (result.Succeded)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("addBrand")]
        public IActionResult AddBrand(Brand brand)
        {
            var result = _brandService.Add(brand);
            if (result.Succeded)
                return Ok(result.Message);

            return BadRequest(result);
        }

        [HttpDelete("deleteBrand")]
        public IActionResult DeleteBrand(int id)
        {
            var brand = _brandService.GetById(id).Data;
            var result = _brandService.Delete(brand);
            if (result.Succeded)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("updateBrand")]
        public IActionResult UpdateBrand(Brand brand)
        {
            var result = _brandService.Update(brand);
            if (result.Succeded)
                return Ok(result);
            return BadRequest(result);
        }

    }
}
