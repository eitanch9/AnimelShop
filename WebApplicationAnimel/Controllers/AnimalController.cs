using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Model.Repository;

namespace WebApplicationAnimel.Controllers
{
    public class AnimalController : Controller
    {
        private IRepository<Animal> animal;

        public AnimalController(IRepository<Animal> repository) => animal = repository;

        public IActionResult Animals() => View(animal.GetItems());


        public IActionResult Details(int Id) => View(animal.GetItemsById(Id));

     
    }
}
