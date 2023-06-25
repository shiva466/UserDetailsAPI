using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserDetailsDesktop.Models;

namespace UserDetailsDesktop.DbConnection
{
    public class MyDbContext: DbContext
    {
        public DbSet<User> User { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
    }
}
