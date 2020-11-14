using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Common.ViewModels;
using Data.Models;
using Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository userRepository;
        private readonly string getMessageOk = "Get user successfully";
        private readonly string getMessageErr = "User not found";
        private readonly string addMessageOk = "Add user successfully";
        private readonly string addMessageErr = "Add user failed";
        private readonly string updateMessageOk = "Update user successfully";
        private readonly string updateMessageErr = "Update user failed";
        private readonly string deleteMessageOk = "Delete user successfully";
        private readonly string deleteMessageErr = "Delete user failed";

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        [Authorize(Policy = Policies.Admin)]
        public IActionResult Get()
        {
            return Ok(new RestResponse(true, getMessageOk, userRepository.FindAll()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var rs = userRepository.Find(id);

            if (rs == null)
            {
                return NotFound(new RestResponse(false, getMessageErr));
            }

            return Ok(new RestResponse(true, getMessageOk, rs));
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(long id, User rqBody)
        {
            rqBody.Id = id;
            if (userRepository.Update(rqBody))
                return Ok(new RestResponse(true, updateMessageOk));
            return Ok(new RestResponse(false, updateMessageErr));
        }

        [HttpPost]
        [Authorize(Policy = Policies.Admin)]
        public IActionResult Post(User rqBody)
        {
            if (userRepository.Add(rqBody))
                return Ok(new RestResponse(true, addMessageOk));
            return Ok(new RestResponse(false, addMessageErr));
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.Admin)]
        public IActionResult Delete(long id)
        {
            if (userRepository.Delete(id))
                return Ok(new RestResponse(true, deleteMessageOk));
            return Ok(new RestResponse(false, deleteMessageErr));
        }
    }
}
