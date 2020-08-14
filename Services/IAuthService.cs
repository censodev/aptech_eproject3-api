using Common.Requests;
using Common.ViewModels;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IAuthService
    {
        string HashPassword(string input);
        bool CheckPassword(string input, string hash);
        string GenerateJWTToken(User userInfo);
        string Register(AuthRequest authRequest);
        AuthViewModel Login(AuthRequest login);
    }
}
