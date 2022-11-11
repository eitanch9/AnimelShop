using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Model.Repository;

namespace WebApplicationAnimel.Controllers
{
    public class AdministratorController : Controller
    {
        private IRepository<Animal> animal;

        public AdministratorController(IRepository<Animal> repository) => animal = repository;
        public IActionResult Administrator() => View(animal.GetItems());
        public IActionResult AddAnimalPage() => View();
    }
}
