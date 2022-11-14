
using Microsoft.EntityFrameworkCore;
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

        public override bool Edit(Animal entity)
        {
            if (entity == null) { return false; }

            var oldAnimal = _data.Set<Animal>().Where(animal => animal.AnimalId == entity.AnimalId).SingleOrDefault();
            if (oldAnimal != null && !oldAnimal.Equals(entity))
            {
                _data.Set<Animal>().Remove(oldAnimal);
                _data.Set<Animal>().Add(entity);
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
            return FindById(Id).Comments.AsQueryable();
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
