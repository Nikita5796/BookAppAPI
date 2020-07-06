using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demoAuthApp.Entities;
using demoAuthApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace demoAuthApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = _userService.Authenticate(userParam.UserName, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        //[HttpGet]
        //public IActionResult<IList<User>> Get()
        //{
        //    IList<User> _users = _userService.GetUsers();
        //    return _users;
        //    //return new string[] { "nikita", "thorat" };
        //}
    }
}