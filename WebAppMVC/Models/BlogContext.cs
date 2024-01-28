using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAppMVC.Models
{
    public class BlogContext : IdentityDbContext<ApplicationUser>
    {
        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public DbSet<Blog> Blog { get; set; }
        public DbSet<ApplicationUser> User { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // シーディング
            modelBuilder.Entity<Blog>().HasData(
                new Blog { Id = 1, Name = "First Blog" },
                new Blog { Id = 2, Name = "Second Blog" },
                new Blog { Id = 3, Name = "Third Blog" }                
            );

            // パスワードは実際には安全なハッシュを生成して使用する
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser { UserName = "testuser", PasswordHash = "123", FirstName = "Tom", LastName = "Smith" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
