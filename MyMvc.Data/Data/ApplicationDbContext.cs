using Microsoft.EntityFrameworkCore;
using MyMvc.Model.Models;

namespace MyMvc.Data.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyMvc.Model.Models.Category>().HasData(
                new MyMvc.Model.Models.Category
                {
                    Id = 1,
                    Name = "Action",
                    DisplayOrder = 1
                },
                new MyMvc.Model.Models.Category
                {
                    Id = 2,
                    Name = "Comedy",
                    DisplayOrder = 2
                },
                new MyMvc.Model.Models.Category
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
