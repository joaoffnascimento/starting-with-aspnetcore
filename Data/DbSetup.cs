using Microsoft.EntityFrameworkCore;

namespace starting_with_aspnetcore.Data
{
    public class DbSetup : DbContext
    {
        public DbSetup(DbContextOptions<DbSetup> options) : base(options)
        {
        }
    }
}