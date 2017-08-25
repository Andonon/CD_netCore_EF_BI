using Microsoft.EntityFrameworkCore;
 
namespace brightideas.Models
{
    public class IdeaContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public IdeaContext(DbContextOptions<IdeaContext> options) : base(options) { }
        public DbSet<Idea> Ideas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}