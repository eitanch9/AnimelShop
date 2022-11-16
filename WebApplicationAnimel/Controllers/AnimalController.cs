using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Model.Repository;

namespace WebApplicationAnimel.Controllers
{
    public class AnimalController : Controller
    {
        private AnimalRepository animals;
        private CategortyRepository category;

        private CommentRepoditory comments;


        public AnimalController(AnimalRepository RAnimals, CategortyRepository RCategorys, CommentRepoditory RComment)
        {
            category = RCategorys; animals = RAnimals; comments = RComment;
        }

        public IActionResult Animals(int Id)
        {
            var categories = category.GetItems();
            ViewBag.Categories = categories;
            var Animals = (animals.ShoeAnimalByCategory(Id));
            if (Animals == null)
            {
                Id = 0;
                Animals = animals.ShoeAnimalByCategory(Id);
            }
            return View(Animals);
        }
        public IActionResult Details(int Id)
        {
            ViewBag.AnimalComments = animals.GetCommentById(Id);
            ViewBag.CategoryName = category.FindById(animals.FindById(Id).CategoryId).Name;
            return View(animals.FindById(Id));
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(string CommentText, int AnimalId)
        {
            if (ModelState.IsValid)
            {
                var NewComment=new Comment { AnimalId= AnimalId, CommentText=CommentText };
                comments.Add(NewComment);
            }

            return RedirectToAction("Details", new {Id= AnimalId } ); 
        }

    }
}
