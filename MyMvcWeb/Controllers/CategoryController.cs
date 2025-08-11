using Microsoft.AspNetCore.Mvc;
using MyMvc.Data.Data;
using MyMvc.Model.Models;

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

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name != null && obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name and Display Order are same");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            Category cat1 = _db.Categories.Find(id);
            //Category cat2 = _db.Categories.FirstOrDefault(i => i.Id == id);
            //Category cat3 = _db.Categories.Where(j => j.Id == id).FirstOrDefault();
            return View(cat1);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if(ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (ModelState.IsValid)
            {
                Category obj=_db.Categories.Find(id);
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                TempData["success"] = "Category deleted successfully";
            }
            return RedirectToAction("Index");
        }
    }
}
