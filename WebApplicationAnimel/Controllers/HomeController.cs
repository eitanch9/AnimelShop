using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Model.Repository;

namespace WebApplicationAnimel.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Animal> animal;

        public HomeController(IRepository<Animal> repository) => animal = repository;


        public IActionResult Index() => View(animal.Show2AnimalsWithTheMostComment());
    }
}
