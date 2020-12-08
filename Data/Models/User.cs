using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string  Username { get; set; }
        public string Password { get; set; }
        public string  Email { get; set; }
        public string UserRole { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string Class { get; set; }
        public string RollNumber { get; set; }
        public string Section { get; set; }
        public string Specification { get; set; }
    }
}
