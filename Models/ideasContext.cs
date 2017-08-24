using Microsoft.EntityFrameworkCore;
 
namespace brightideas.Models
{
    public class ideasContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public ideasContext(DbContextOptions<ideasContext> options) : base(options) { }
        public DbSet<ideas> ideas { get; set; }
        public DbSet<users> users { get; set; }
    }
}