using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByUsername(string username);
        User FindByEmail(string email);
    }
}
