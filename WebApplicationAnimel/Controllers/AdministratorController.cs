using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Model.Repository;

namespace WebApplicationAnimel.Controllers
{
    public class AdministratorController : Controller
    {
        private AnimalRepository animal;

        public AdministratorController(AnimalRepository repository) => animal = repository;
        public IActionResult Administrator(string categoryName) => View(animal.ShoeAnimalByCategory(categoryName));
        public IActionResult AddAnimalPage() => View();


    }
}
