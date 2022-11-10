using WebApplicationAnimel.Data;
using WebApplicationAnimel.Models;

namespace WebApplicationAnimel.DAL
{
    public class AnimalRepository : IRepository<Animal>
    {
        private AnimalsContext _data;

        public AnimalRepository(AnimalsContext Data)
        {
            _data = Data;
        }

        public IEnumerable<Animal> Show2AnimalsWithTheMostComment()
        {
            return _data.Animals.OrderBy(a => a.Comments!.Count).Take(2);
        }

        public IEnumerable<Animal> ShowAnimalsByCategory(int CategoryId)
        {
            return _data.Animals.Where(a => a.Category!.CategoryId == CategoryId).AsQueryable();
        }

        public IEnumerable<Animal> ShowAnimalsByCategory(string categoryName)
        {
            return _data.Animals.Where(a => a.Category!.Name == categoryName).AsQueryable();
        }

        public void AddAnimal(Animal animal)
        {
            if (animal != null)
            {
                if (_data.Animals.Where(a => a.AnimalId == animal.AnimalId).FirstOrDefault() == null)
                {
                    _data.Animals.Add(animal);
                    _data.SaveChanges();
                }

            }
        }


        public void EditById(Animal animal)
        {
            var oldAnimal = _data.Animals.Where(a => a.AnimalId == animal.AnimalId).FirstOrDefault();
            if (oldAnimal != null && !oldAnimal.Equals(animal))
            {
                _data.Animals.Remove(oldAnimal);
                _data.Animals.Add(animal);
                _data.SaveChanges();
            }

        }

        public void AddComment(Comment comment, int AnimalId)
        {
            if (comment != null)
            {
                _data.Animals.Where(a => a.AnimalId == AnimalId).FirstOrDefault()?.Comments.Add(comment);
                _data.SaveChanges();
            }
        }

        public void RemoveAnimal(int animalId)
        {
            var animal = _data.Animals.Where(a => a.AnimalId == animalId).FirstOrDefault();
            if (animal != null)
            {
                _data.Animals.Remove(animal);
                _data.SaveChanges();
            }
        }

        public Animal GetAnimalsById(int animalid)
        {
            return _data.Animals.Where(a => a.AnimalId == animalid).SingleOrDefault()!;
        }

        public IEnumerable<Animal> ShowAnimals() => _data.Animals.AsQueryable();
    }
}
