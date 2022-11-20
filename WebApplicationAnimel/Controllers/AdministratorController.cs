using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Graph;
using Model.Models;
using Model.Repository;
//using NuGet.Protocol.Core.Types;
using System;
using System.Diagnostics.Metrics;
using System.Xml;
using static Microsoft.VisualStudio.Services.Graph.GraphResourceIds;

namespace WebApplicationAnimel.Controllers
{
    public class AdministratorController : Controller
    {
        private AnimalRepository animals;

        private CategortyRepository category;

        private readonly IWebHostEnvironment _webHost;

        public AdministratorController(AnimalRepository RAnimals, CategortyRepository RCategorys, IWebHostEnvironment webHost)
        {
            category = RCategorys; animals = RAnimals;
            _webHost = webHost;
        }

        public IActionResult connect()
        {
            return View();
        }
        public IActionResult tryConnect(string name, int password)
        {
            if (name == "eitan" && password == 1234)
            {
                var v = RedirectToAction("Administrator");
                return v;

            }
            return RedirectToAction("connect");
        }

        public IActionResult Administrator(int Id)
        {
            var categories = category.GetItems();
            ViewBag.Categories = categories;
            var v = View(animals.ShoeAnimalByCategory(Id));
            return v;
        }


        public IActionResult RemoveAnimal(int Id)
        {
            var Animal = animals.FindById(Id);
            animals.Remove(Animal);
            return RedirectToAction("Administrator");
        }

        public IActionResult AddAnimalPage()
        {
            var categories = category.GetItems();
            ViewBag.Categories = categories;
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> AddAnimal(string Name, int Age, IFormFile Image, string Description, int CategoryId)
        {
            if (ModelState.IsValid)
            {
                var SaveImg = Path.Combine(_webHost.WebRootPath, "Assets", Image.FileName);
                string ImgText = Path.GetExtension(Image.FileName);
                if (ImgText == ".jpg" || ImgText == ".jfif")
                {
                    using (var uplaoding = new FileStream(SaveImg, FileMode.Create))
                    {
                        await Image.CopyToAsync(uplaoding);
                    }
                    var animal = new Animal { Name = Name, Age = Age, CategoryId = CategoryId, Description = Description, PictureLink = "Assets/" + Image.FileName };
                    animals.Add(animal);

                    return RedirectToAction("Administrator", "Administrator");
                }
                else
                {
                    ViewData["FileMessage"] = "only Images with extension .jpg or .jfif can be uploaded";
                    return View();
                }

            }
            return RedirectToAction($"AddAnimalPage", "Administrator");
        }

        public IActionResult EditAnimalPage(int Id)
        {
            var categories = category.GetItems();
            ViewBag.Categories = categories;
            return View(animals.FindById(Id));
        }

        [HttpPost]
        public async Task<IActionResult> EditAnimal(int Id, string Name, int Age, IFormFile Image, string Description, int CategoryId)
        {
            if (Image == null)
            {

            }

            if (ModelState.IsValid)
            {
                var SaveImg = Path.Combine(_webHost.WebRootPath, "Assets", Image.FileName);
                string ImgText = Path.GetExtension(Image.FileName);
                if (ImgText == ".jpg" || ImgText == ".jfif")
                {
                    using (var uplaoding = new FileStream(SaveImg, FileMode.Create))
                    {
                        await Image.CopyToAsync(uplaoding);
                    }
                    var animal = new Animal { Name = Name, Age = Age, CategoryId = CategoryId, Description = Description, PictureLink = "Assets/" + Image.FileName };
                    var edit = animals.Edit(animal, Id);

                    return RedirectToAction("Details", "Animal", new { Id = Id });
                }
                else
                {
                    ViewData["FileMessage"] = "only Images with extension .jpg or .jfif can be uploaded";
                    return View();
                }

            }
            return RedirectToAction($"EditAnimalPage", "Administrator", new { Id = Id });
        }

    }

}