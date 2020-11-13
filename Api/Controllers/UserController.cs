using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Common.ViewModels;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;


namespace Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Authorize(Policy = Policies.Admin)]
        public IActionResult Get()
        {
            return Ok(new RestResponse(true, null, userService.FindAll().ToList()));
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(long id)
        {
            return Ok(new RestResponse(true, null, userService.FindById(id)));
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            userService.Add(user);
            return Ok(new RestResponse(true, "Add user successfully"));
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] User user)
        {
            user.Id = id;
            userService.Update(user);
            return Ok(new RestResponse(true, "Update user successfully"));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            userService.Remove(id);
            return Ok(new RestResponse(true, "Delete user successfully"));
        }
    }
}
