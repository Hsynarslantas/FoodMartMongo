using FoodMartMongo.Dtos.ProductDtos;
using FoodMartMongo.Services.CategoryServices;
using FoodMartMongo.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMartMongo.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly ICategoryService _categoryService;

        public AdminController(IProductsService productsService, ICategoryService categoryService)
        {
            _productsService = productsService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error = "Kullanıcı adı ve şifre boş olamaz.";
                return View();
            }

            // Sabit admin bilgisi
            if (username == "admin" && password == "12345")
            {
                HttpContext.Session.SetString("AdminUsername", username);
                return RedirectToAction("Index", "Admin");
            }

            ViewBag.Error = "Kullanıcı adı veya şifre yanlış.";
            return View();
        }

        public IActionResult Index()
        {
            var adminUser = HttpContext.Session.GetString("AdminUsername");
            if (string.IsNullOrEmpty(adminUser))
            {
                return RedirectToAction("Login");
            }
            return View();
        }
}

        
    }

