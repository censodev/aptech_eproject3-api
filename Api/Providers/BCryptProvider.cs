using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Api.Providers
{
    public class BCryptProvider
    {
        public string Hash(string input)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            return BCrypt.Net.BCrypt.HashPassword(input, salt);
        }

        public bool Check(string input, string hash) => BCrypt.Net.BCrypt.Verify(input, hash);
    }
}
