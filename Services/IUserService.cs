using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IUserService
    {
        User GetUserById(long id);
        IEnumerable<User> GetAllUsers();
        bool AddUser(User user);
        bool UpdateUser(User user);
        bool RemoveUser(long id);
        User GetByUsername(string username);
    }
}
