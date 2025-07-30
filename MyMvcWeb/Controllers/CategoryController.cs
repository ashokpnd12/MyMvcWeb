using Microsoft.AspNetCore.Mvc;

namespace MyMvcWeb.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
