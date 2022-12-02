using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    // This class will be derived from an entity framework class, DbContext
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        //The Users method name is what is effectivly going to be our db name
        //The columns for the db are going to be the properties in the AppUser class (ID, UserName)
        //
        public DbSet<AppUser> Users { get; set; }
    }
}