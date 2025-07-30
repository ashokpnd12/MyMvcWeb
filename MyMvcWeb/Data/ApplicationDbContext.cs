using Microsoft.EntityFrameworkCore;
using MyMvcWeb.Models;

namespace MyMvcWeb.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyMvcWeb.Models.Category>().HasData(
                new MyMvcWeb.Models.Category
                {
                    Id = 1,
                    Name = "Action",
                    DisplayOrder = 1
                },
                new MyMvcWeb.Models.Category
                {
                    Id = 2,
                    Name = "Comedy",
                    DisplayOrder = 2
                },
                new MyMvcWeb.Models.Category
                {
                    Id = 3,
                    Name = "Drama",
                    DisplayOrder = 3
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
