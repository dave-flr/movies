using Microsoft.EntityFrameworkCore;

namespace movies.Models
{
    public class movies_db_Context : DbContext
    {
        public movies_db_Context(DbContextOptions<movies_db_Context> options) :
        base(options)
        { }
        public DbSet<User> Users {get; set;}
    }
}