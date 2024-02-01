using product_service.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace product_service.Repository.Implementation
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;port=3306;database=bank_db;user=root;password=admin;");
        }
    }
}
