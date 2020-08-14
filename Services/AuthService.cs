using Common.Exceptions;
using Common.Requests;
using Common.ViewModels;
using Data.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration config;
        private readonly IUserService userService;

        public AuthService(IConfiguration config, IUserService userService)
        {
            this.config = config;
            this.userService = userService;
        }

        public string HashPassword(string input)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            return BCrypt.Net.BCrypt.HashPassword(input, salt);
        }

        public bool CheckPassword(string input, string hash) => BCrypt.Net.BCrypt.Verify(input, hash);

        public string GenerateJWTToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                new Claim("fullName", userInfo.Name.ToString()),
                new Claim("role", userInfo.UserRole),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string Register(AuthRequest register)
        {
            User user = new User()
            {
                Name = register.Name,
                Username = register.Username,
                Password = HashPassword(register.Password),
                Email = register.Email,
                UserRole = register.UserRole
            };

            if (userService.FindByUsername(register.Username) != null)
                throw new AuthException(AuthException.USERNAME_EXISTS);
            else if (!userService.Add(user))
                throw new AuthException(AuthException.UNDEFINED);

            return "Register successfully";
        }

        public AuthViewModel Login(AuthRequest login)
        {
            User user = userService.FindByUsername(login.Username);

            if (user == null)
                throw new AuthException(AuthException.USERNAME_DOES_NOT_EXIST);

            if (!CheckPassword(login.Password, user.Password))
                throw new AuthException(AuthException.WRONG_PASSWORD);

            return new AuthViewModel()
            {
                Token = GenerateJWTToken(user),
                Name = user.Name,
                Username = user.Username,
                Email = user.Email,
                UserRole = user.UserRole
            };
        }
    }
}
