using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataContexts
{
    public class EProject3DataContext : DbContext
    {
        public EProject3DataContext(DbContextOptions<EProject3DataContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
    }
}
