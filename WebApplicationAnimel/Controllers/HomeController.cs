using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Model.Repository;

namespace WebApplicationAnimel.Controllers
{
    public class HomeController : Controller
    {
        private AnimalRepository animal;

        public HomeController(AnimalRepository repository) { animal = repository; }


        public IActionResult Index() => View(animal.ShowNumOfAnimalsWithTheMostComment(2));
    }
}
