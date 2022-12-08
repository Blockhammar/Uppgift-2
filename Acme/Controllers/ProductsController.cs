using Uppgift2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Uppgift2.Controllers
{
    public class ProductsController : Controller
    {
        DataService service;
        public ProductsController()
        {
            service = new DataService();
        }

        [HttpGet("")]
        [HttpGet("dogs/index")]
        public IActionResult Index()
        {
            var model = service.GetAllDogs();
            return View(model);
        }

        [HttpGet("dogs/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("dogs/create")]
        public IActionResult Create(Dog dog)
        {
            service.Add(dog);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("test/{categoryId}/{productId}")]
        public IActionResult Test(int categoryId, int productId)
        {
            return Content($"Du är nu i test, kategori:{categoryId}, produkt:{productId}");
        }
    }
}
