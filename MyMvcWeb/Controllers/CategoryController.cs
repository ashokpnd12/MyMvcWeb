using Microsoft.AspNetCore.Mvc;
using MyMvcWeb.Data;
using MyMvcWeb.Models;

namespace MyMvcWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            // Fetching categories from the database
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
    }
}
