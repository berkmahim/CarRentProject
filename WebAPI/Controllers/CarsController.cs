using Business.Abstract;
using Core.Utilities.Reuslts;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;
        //Car _car;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Succeded)
                return Ok(result);
            
            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Succeded)
                return Ok(result);
            
            return BadRequest(result);
        }

        [HttpPost("addCar")]
        public IActionResult AddCar(Car car)
        {
            var result = _carService.Add(car);
            if (result.Succeded)           
                return Ok(result.Message);
            
            return BadRequest(result);
        }

        [HttpDelete("deleteCar")]
        public IActionResult DeleteCar(int id)
        {
            var car = _carService.GetById(id).Data;
            var result = _carService.Delete(car);
            if(result.Succeded)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("updateCar")]
        public IActionResult UpdateCar(Car car)
        {
            var result = _carService.Update(car);
            if (result.Succeded)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("getCarDetails")]
        public IActionResult GetCarDetails() { 
        
            var result = _carService.GetCarDetails();
            if (result.Succeded)
                return Ok(result);
            
            return BadRequest(result.Message);
        }
       
        [HttpGet("getAllByBrandId")]
        public IActionResult GetAllByBrandId(int id)
        {

            var result = _carService.GetAllByBrandId(id);
            if (result.Succeded)
                return Ok(result);

            return BadRequest(result.Message);
        }
        
        [HttpGet("getAllByUnitPrice")]
        public IActionResult GetAllByUnitPrice(int min, int max)
        {

            var result = _carService.GetAllByUnitPrice(min, max);
            if (result.Succeded)
                return Ok(result);

            return BadRequest(result.Message);
        }

        [HttpGet("getAllByColorId")]
        public IActionResult GetAllByColorId(int id)
        {

            var result = _carService.GetAllByColorId(id);
            if (result.Succeded)
                return Ok(result);

            return BadRequest(result.Message);
        }
    }
}
