using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;
        //Car _car;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAll();
            if (result.Succeded)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _customerService.GetById(id);
            if (result.Succeded)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("addCustomer")]
        public IActionResult AddCustomer(Customer customer)
        {
            var result = _customerService.Add(customer);
            if (result.Succeded)
                return Ok(result.Message);

            return BadRequest(result);
        }

        [HttpDelete("deleteCustomer")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _customerService.GetById(id).Data;
            var result = _customerService.Delete(customer);
            if (result.Succeded)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("updateCustomer")]
        public IActionResult UpdateCustomer(Customer customer)
        {
            var result = _customerService.Update(customer);
            if (result.Succeded)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
