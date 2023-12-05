using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;
        //Car _car;
        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            if (result.Succeded)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _rentalService.GetById(id);
            if (result.Succeded)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("addRental")]
        public IActionResult AddUser(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Succeded)
                return Ok(result.Message);

            return BadRequest(result);
        }

        [HttpDelete("deleteRental")]
        public IActionResult DeleteRental(int id)
        {
            var rental = _rentalService.GetById(id).Data;
            var result = _rentalService.Delete(rental);
            if (result.Succeded)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("updateRental")]
        public IActionResult UpdateCustomer(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Succeded)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
