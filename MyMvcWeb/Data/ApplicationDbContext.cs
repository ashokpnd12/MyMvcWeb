using Microsoft.EntityFrameworkCore;
using MyMvcWeb.Models;

namespace MyMvcWeb.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<CategoryModel> Categories { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<MyMvcWeb.Models.CategoryModel>().HasData(
        //        new MyMvcWeb.Models.CategoryModel
        //        {
        //            Id = 1,
        //            Name = "Action",
        //            DisplayOrder = 1
        //        },
        //        new MyMvcWeb.Models.CategoryModel
        //        {
        //            Id = 2,
        //            Name = "Comedy",
        //            DisplayOrder = 2
        //        }
        //    );
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
