
using BusinesLayer.Interface;
using DataAccesLayer.Models;
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
        public IActionResult Creating(Users user)
        {
            var result = _userService.UserCreate(user);
            return StatusCode(result.status,result.message);
        }
        [HttpPut]
        public IActionResult Update(ForUpdate user)
        {
            var result = _userService.UserUpdate(user);
            return StatusCode(result.status, result.message);
        }
        [HttpPatch]
        public IActionResult Delete(string name,string lastname,string gsm)
        {
            var result = _userService.UserDelete(name,lastname,gsm);
            return StatusCode(result.status, result.message);
        }
        [HttpGet]
        public IActionResult Listing()
        {
            var result = _userService.UserListing();
            return Ok(result);
        }
    }
}
