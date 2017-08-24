using Microsoft.EntityFrameworkCore;
 
namespace brightideas.Models
{
    public class usersContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public usersContext(DbContextOptions<usersContext> options) : base(options) { }
        public DbSet<users> users { get; set; }
    }
}