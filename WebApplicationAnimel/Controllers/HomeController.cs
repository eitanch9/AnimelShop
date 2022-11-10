using Microsoft.AspNetCore.Mvc;
using WebApplicationAnimel.DAL;
using WebApplicationAnimel.Data;
using WebApplicationAnimel.Models;

namespace WebApplicationAnimel.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Animal> animal;

        public HomeController(IRepository<Animal> repository) => animal = repository;


        public IActionResult Index() => View(animal.Show2AnimalsWithTheMostComment());
    }
}
