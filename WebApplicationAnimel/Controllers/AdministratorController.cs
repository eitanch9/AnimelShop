using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Model.Models;
using Model.Repository;
using System.Diagnostics.Metrics;
using static Microsoft.VisualStudio.Services.Graph.GraphResourceIds;

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
        public IActionResult AddAnimalPage()
        {
            var categories = category.GetItems();
            ViewBag.Categories = categories;
            return View();
        }
        public IActionResult EditAnimalPage(int Id)
        {
            var categories = category.GetItems();
            ViewBag.Categories = categories;
            return View(animals.FindById(Id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAnimal(int Id)
        {
            return RedirectToAction("EditAnimalPage");
        }


        public IActionResult RemoveAnimal(int Id)
        {
            var Animal = animals.FindById(Id);
            animals.Remove(Animal);
            return RedirectToAction("Administrator");
        }


      


#if (njsnd)
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMember(AnimalViewModel model, IFormFile photo)
        {
            if (photo == null)  { return Content("File not selected");}
            var path = Path.Combine(_environments.WebRootPath, "Assets\\", photo.FileName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
                stream.Close();
            }

            model.Animal.PictureLink = "Assets\\"+photo.FileName;

            if (model != null)
            {
                var animal = new Animal
                {
                    Name = model.Animal.Name,
                    Age = model.Animal.Age,
                    Description = model.Animal.Description,
                    PictureLink = model.Animal.PictureLink,
                  
                };
               animals.Add(animal);
               animals.SaveAsync();
            }
            return RedirectToAction("MemberList");

        }
#endif


    }
}
