using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ILogger<UserRepository> logger;

        public UserRepository(DataContext context, ILogger<UserRepository> logger) : base(context, logger)
        {
        }

        public User GetByUsername(string username)
        {
            return context.Set<User>()
                .Where(u => u.Username.Equals(username))
                .FirstOrDefault();
        }
    }
}
