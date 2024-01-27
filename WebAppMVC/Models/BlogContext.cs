using Microsoft.EntityFrameworkCore;

namespace WebAppMVC.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public DbSet<Blog> Blog { get; set; }

        // シーディング
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasData(
                new Blog { Id = 1, Name = "First Blog" },
                new Blog { Id = 2, Name = "Second Blog" },
                new Blog { Id = 3, Name = "Third Blog" }                
            );
        }
    }
}
