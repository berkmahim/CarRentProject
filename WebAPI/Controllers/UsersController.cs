using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        //Car _car;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Succeded)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);
            if (result.Succeded)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("addUser")]
        public IActionResult AddUser(User user)
        {
            var result = _userService.Add(user);
            if (result.Succeded)
                return Ok(result.Message);

            return BadRequest(result);
        }

        [HttpDelete("deleteUser")]
        public IActionResult DeleteUser(int id)
        {
            var user = _userService.GetById(id).Data;
            var result = _userService.Delete(user);
            if (result.Succeded)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("updateUser")]
        public IActionResult UpdateCustomer(User user)
        {
            var result = _userService.Update(user);
            if (result.Succeded)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
