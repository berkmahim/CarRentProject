using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        IColorService _colorService;
        //Car _car;
        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _colorService.GetAll();
            if (result.Succeded)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _colorService.GetById(id);
            if (result.Succeded)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("addColor")]
        public IActionResult AddColor(Color color)
        {
            var result = _colorService.Add(color);
            if (result.Succeded)
                return Ok(result.Message);

            return BadRequest(result);
        }

        [HttpDelete("deleteColor")]
        public IActionResult DeleteColor(int id)
        {
            var color = _colorService.GetById(id).Data;
            var result = _colorService.Delete(color);
            if (result.Succeded)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("updateColor")]
        public IActionResult UpdateColor(Color color)
        {
            var result = _colorService.Update(color);
            if (result.Succeded)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
