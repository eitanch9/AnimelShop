using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Model.Repository;

namespace WebApplicationAnimel.Controllers
{
    public class AnimalController : Controller
    {
        private AnimalRepository animals;
        private CategortyRepository category;

        public AnimalController(AnimalRepository RAnimals, CategortyRepository RCategorys)
        {
            category = RCategorys; animals = RAnimals;
        }

        public IActionResult Animals(int Id)
        {
            var categories = category.GetItems();
            ViewBag.Categories = categories;
            var Animals = (animals.ShoeAnimalByCategory(Id));
            if (Animals == null)
            {
                Id = 0;
                Animals = animals.ShoeAnimalByCategory(Id); }
            return View(Animals);
        }
        public IActionResult Details(int Id)
        {
            ViewBag.AnimalComments = animals.GetCommentById(Id);
            ViewBag.CategoryName= category.FindById(animals.FindById(Id).CategoryId).Name;
            return View(animals.FindById(Id));
        }

        public IActionResult addCommentPage(int Id) => View(animals.FindById(Id));


    }
}
