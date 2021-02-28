using Microsoft.EntityFrameworkCore;
using starting_with_aspnetcore.Models;

namespace starting_with_aspnetcore.Data
{
    public class DbSetup : DbContext
    {
        public DbSet<Tech> Tech { get; set; }
        public DbSet<Repository> Repository { get; set; }
        public DbSetup(DbContextOptions<DbSetup> options) : base(options)
        {
        }
    }
}