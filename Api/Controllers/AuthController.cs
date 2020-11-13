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
                return Ok(new RestResponse(true, null, authService.Login(login)));
            }
            catch (AuthException ex)
            {
                return Unauthorized(new RestResponse(false, ex.Message));
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public IActionResult Register([FromBody] AuthRequest register)
        {
            try
            {
                return Ok(new RestResponse(true, "Register successfully", authService.Register(register)));
            }
            catch (AuthException ex)
            {
                return Ok(new RestResponse(false, ex.Message));
            }
        }
    }
}
