using Microsoft.AspNetCore.Mvc;
using MyMvc.Data.Data;
using MyMvc.Data.Repository.IRepository;
using MyMvc.Model.Models;

namespace MyMvcWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            // Fetching categories from the database
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
            return View(objProductList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            Product cat1 = _unitOfWork.Product.Get(i => i.Id == id);
            //Product cat2 = _db.Categories.FirstOrDefault(i => i.Id == id);
            //Product cat3 = _db.Categories.Where(j => j.Id == id).FirstOrDefault();
            return View(cat1);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (ModelState.IsValid)
            {
                Product obj = _unitOfWork.Product.Get(i => i.Id == id);
                _unitOfWork.Product.Remove(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product deleted successfully";
            }
            return RedirectToAction("Index");
        }
    }
}
