using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
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
        public ActionResult<IEnumerable<User>> Get()
        {
            return userService.GetAllUsers().ToList();
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<User> Get(long id)
        {
            return userService.GetUserById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            userService.AddUser(user);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] User user)
        {
            user.Id = id;
            userService.UpdateUser(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            userService.RemoveUser(id);
            return Ok();
        }
    }
}
