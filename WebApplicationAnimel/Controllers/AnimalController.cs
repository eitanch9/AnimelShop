using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Model.Repository;

namespace WebApplicationAnimel.Controllers
{
    public class AnimalController : Controller
    {
        private AnimalRepository animals;
        private CategortyRepository categortys;

        public AnimalController(AnimalRepository RAnimals, CategortyRepository RCategorys)
        {
            categortys = RCategorys; animals = RAnimals;
        }

        public IActionResult Animals(string categoryName)
        {var categories=categortys.GetItems();
            ViewBag.Categories = categories;
         return   View(animals.ShoeAnimalByCategory(categoryName));
        }
        public IActionResult Details(int Id) => View(animals.FindById(Id));

        //public IActionResult Create(Animal animal)
        //{
        //   var added=animals.Add(animal);
        //    if (added) { }


        //}


    }
}
