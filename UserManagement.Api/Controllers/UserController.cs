
using UserManagement.BusinesLayer.Interface;
using UserManagement.DataAccesLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("ForUserCreate")]
        public IActionResult Creating([FromBody] Users user)
        {
      
            var result = _userService.UserCreate(user);
            if (result.state)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("ForUpdate")]
        public IActionResult Update([FromBody] ForUpdate user)
        {
            var result = _userService.UserUpdate(user);
            if (result.state)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete([FromBody] string str)
        {
            return Ok(str);
          /*  var result = _userService.UserDelete(model.name,model.lastname,model.gsm);
            if (result.state)
            {
                return Ok(result);
            }
            return BadRequest(result);*/
        }
        [HttpGet]
        public IActionResult Listing()
        {
            var result = _userService.UserListing();
            return Ok(result);
        }
    }
}
