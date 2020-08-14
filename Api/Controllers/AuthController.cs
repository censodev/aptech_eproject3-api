using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Common.Exceptions;
using Common.Requests;
using Common.ViewModels;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services;

namespace Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IUserService userService;

        public AuthController(
            IAuthService authService,
            IUserService userService)
        {
            this.authService = authService;
            this.userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public IActionResult Login([FromBody] AuthRequest login)
        {
            try
            {
                return Ok(authService.Login(login));
            }
            catch (AuthException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public IActionResult RegisterUser([FromBody] AuthRequest register)
        {
            try
            {
                register.UserRole = Policies.User;
                return Ok(authService.Register(register));
            }
            catch (AuthException ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Policy = Policies.Admin)]
        [Route("admin/register")]
        public IActionResult RegisterAdmin([FromBody] AuthRequest register)
        {
            try
            {
                register.UserRole = Policies.Admin;
                return Ok(authService.Register(register));
            }
            catch (AuthException ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
