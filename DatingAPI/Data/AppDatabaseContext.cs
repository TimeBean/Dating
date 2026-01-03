using Microsoft.EntityFrameworkCore;
using DatingAPI.Models;

namespace DatingAPI.Data
{
    public class AppDatabaseContext : DbContext
    {
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}