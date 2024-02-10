using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Classes.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<UserDataModel> Users { get; set; }
    }
}
