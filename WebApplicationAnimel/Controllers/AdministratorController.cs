using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Model.Repository;

namespace WebApplicationAnimel.Controllers
{
    public class AdministratorController : Controller
    {
        private AnimalRepository animals;

        private CategortyRepository category;

        public AdministratorController(AnimalRepository RAnimals, CategortyRepository RCategorys)
        {
            category = RCategorys; animals = RAnimals;
        }
        public IActionResult Administrator(int Id)
        {
            var categories = category.GetItems();
            ViewBag.Categories = categories;
            return View(animals.ShoeAnimalByCategory(Id));
        }
        public IActionResult AddAnimalPage() => View();

        public IActionResult EditAnimalPage(int Id) => View(animals.FindById(Id));


    }
}
