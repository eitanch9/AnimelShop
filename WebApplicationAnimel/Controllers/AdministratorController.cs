using Microsoft.AspNetCore.Mvc;
using WebApplicationAnimel.Data;
using WebApplicationAnimel.Models;

namespace WebApplicationAnimel.Controllers
{
    public class AdministratorController : Controller
    {
        private IRepository<Animal> animal;

        public AdministratorController(IRepository<Animal> repository) => animal = repository;
        public IActionResult Administrator() => View(animal.ShowAnimals());
        public IActionResult AddAnimalPage() => View();
    }
}
