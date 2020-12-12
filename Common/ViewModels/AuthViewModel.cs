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
        public DateTime DateOfJoining { get; set; }
        public string Class { get; set; }
        public string RollNumber { get; set; }
        public string Section { get; set; }
        public string Specification { get; set; }
    }
}
