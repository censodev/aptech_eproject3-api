using Data.DataContexts;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(EProject3DataContext context) : base(context)
        {
        }
    }
}
