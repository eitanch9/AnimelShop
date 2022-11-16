
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Model.DAL;
using Model.Models;

namespace Model.Repository
{
    public class AnimalRepository : MyRepository<Animal, AnimalsContext>
    {
        private AnimalsContext _data;

        public AnimalRepository(AnimalsContext Data) : base(Data) { _data = Data; }


        public IEnumerable<Animal> ShowNumOfAnimalsWithTheMostComment(int numofAnimalReturn)
        { return _data.Animals.OrderByDescending(animal => animal.Comments!.Count).Take(numofAnimalReturn); }

        public override bool Edit(Animal entity, int Id )
        {
            if (entity == null) { return false; }

            var oldAnimal = _data.Set<Animal>().Where(animal => animal.AnimalId == Id).SingleOrDefault();
            if (oldAnimal != null && !oldAnimal.Equals(entity))
            {
                oldAnimal.Age = entity.Age;
                oldAnimal.PictureLink = entity.PictureLink;
                oldAnimal.Name= entity.Name;
                oldAnimal.CategoryId = entity.CategoryId;
                oldAnimal.Category= entity.Category;
                oldAnimal.Description = entity.Description;
                Save();
                return true;
            }
            return false;
        }
        
        public IEnumerable<Animal>? ShoeAnimalByCategory(int Id)
        {
           
            if (Id == 0) { return GetItems(); }
            var category = _data.Categories!.SingleOrDefault(c => c.CategoryId == Id);
            if (category == null) { return null; }
            return _data.Animals.Where(a => a.Category!.CategoryId == category.CategoryId).AsQueryable();
        }

        public IEnumerable<Comment>? GetCommentById(int Id)
        {
            if (Id == 0) { return null; }
            return FindById(Id)?.Comments?.AsQueryable();
        }


        public override Animal? FindById(int Id)
        {
            return _data.Animals.Include(c => c.Comments).FirstOrDefault(x => x.AnimalId == Id);
        }


        public async void SaveAsync()
        {
            await _data.SaveChangesAsync();
        }
    }

}
