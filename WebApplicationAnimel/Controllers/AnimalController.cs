using Microsoft.AspNetCore.Mvc;
using WebApplicationAnimel.Data;
using WebApplicationAnimel.Models;

namespace WebApplicationAnimel.Controllers
{
    public class AnimalController : Controller
    {
        private IRepository<Animal> animal;

        public AnimalController(IRepository<Animal> repository) => animal = repository;

        public IActionResult Animals() => View(animal.ShowAnimals());


        public IActionResult Details(int Id) => View(animal.GetAnimalsById(Id));

     
    }
}
