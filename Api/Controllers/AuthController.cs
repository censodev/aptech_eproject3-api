using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Providers;
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
        private readonly JwtProvider jwtProvider;
        private readonly BCryptProvider bCryptProvider;
        private readonly IUserService userService;

        public AuthController(
            JwtProvider jwtProvider,
            BCryptProvider bCryptProvider,
            IUserService userService)
        {
            this.bCryptProvider = bCryptProvider;
            this.jwtProvider = jwtProvider;
            this.userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public IActionResult Login([FromBody] User login)
        {
            User user = userService.GetByUsername(login.Username);
            if (user != null && bCryptProvider.Check(login.Password, user.Password))
            {
                var tokenString = jwtProvider.GenerateJWTToken(user);
                return Ok(new
                {
                    token = tokenString,
                    userDetails = user,
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public IActionResult Register([FromBody] User register)
        {
            register.Password = bCryptProvider.Hash(register.Password);

            string res = "Ok";

            if (userService.GetByUsername(register.Username) != null)
                res = "Username is already exists";
            else if (!userService.AddUser(register))
                res = "Can't register account";

            return Ok(res);
        }
    }
}
