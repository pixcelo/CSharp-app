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
    }
}
