using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ViewModels
{
    public class AuthViewModel
    {
        public string Token { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; }
    }
}
