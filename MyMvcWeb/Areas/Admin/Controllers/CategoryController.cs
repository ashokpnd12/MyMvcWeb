using Microsoft.AspNetCore.Mvc;
using MyMvc.Data.Data;
using MyMvc.Data.Repository.IRepository;
using MyMvc.Model.Models;

namespace MyMvcWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            // Fetching categories from the database
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
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
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            Category cat1 = _unitOfWork.Category.Get(i => i.Id == id);
            //Category cat2 = _db.Categories.FirstOrDefault(i => i.Id == id);
            //Category cat3 = _db.Categories.Where(j => j.Id == id).FirstOrDefault();
            return View(cat1);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (ModelState.IsValid)
            {
                Category obj = _unitOfWork.Category.Get(i => i.Id == id);
                _unitOfWork.Category.Remove(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category deleted successfully";
            }
            return RedirectToAction("Index");
        }
    }
}
