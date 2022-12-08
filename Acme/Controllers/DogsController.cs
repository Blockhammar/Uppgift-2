using Microsoft.AspNetCore.Mvc;
using Uppgift2.Models;

namespace Uppgift2.Controllers
{
    public class DogsController : Controller
    {
        DataService service;
        public DogsController()
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

        [HttpGet("dogs/edit/{dogID}")]
        public IActionResult Edit(int dogID)
        {
            return View(service.GetDogById(dogID));
        }

        [HttpPost("dogs/edit/{dogID}")]
        public IActionResult Edit(Dog dog, int dogID)
        {
            dog.Id = dogID;
            service.Edit(dog);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost("dogs/delete/{dogID}")]
        public IActionResult Delete(Dog dog, int dogID)
        {
            dog.Id = dogID;
            service.Delete(dog);
            return RedirectToAction(nameof(Index));
        }
    }
}
