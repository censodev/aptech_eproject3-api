using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class AuthException : Exception
    {
        public AuthException(string message) : base(message)
        {
        }

        public const string USERNAME_EXISTS = "Username already exists";
        public const string USERNAME_DOES_NOT_EXIST = "Username doesn't exist";
        public const string WRONG_PASSWORD = "Wrong password";
        public const string INACTIVE_ACCOUNT = "The account is inactive";
        public const string UNDEFINED = "Something went wrong";
    }
}
