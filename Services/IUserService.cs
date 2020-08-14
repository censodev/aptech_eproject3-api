using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IUserService
    {
        User FindById(long id);
        IEnumerable<User> FindAll();
        bool Add(User user);
        bool Update(User user);
        bool Remove(long id);
        User FindByUsername(string username);
        User FindByEmail(string email);
    }
}
