using Microsoft.EntityFrameworkCore;
using MyMvc.Model.Models;
using System.ComponentModel.DataAnnotations;

namespace MyMvc.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Action",
                    DisplayOrder = 1
                },
                new Category
                {
                    Id = 2,
                    Name = "Comedy",
                    DisplayOrder = 2
                },
                new Category
                {
                    Id = 3,
                    Name = "Drama",
                    DisplayOrder = 3
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title= "The Ayodhya Alliance",
                    Description= "An ancient secret.\r\n\r\nA forgotten science.\r\n\r\nA battle for the future of humanity.",
                    ISBN= "9369896449",
                    Auther= "Ashwin Sanghi",
                    ListPrice= 329.00,
                    Price=599.00,
                    Price50=300.00,
                    Price100=250.00
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
