using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Model.Repository;

namespace WebApplicationAnimel.Controllers
{
    public class AdministratorController : Controller
    {
        private AnimalRepository animals;

        public AdministratorController(AnimalRepository repository) => animals = repository;
        public IActionResult Administrator(string categoryName) => View(animals.ShoeAnimalByCategory(categoryName));
        public IActionResult AddAnimalPage() => View();

        public IActionResult EditAnimalPage(int Id) => View(animals.FindById(Id));


    }
}
