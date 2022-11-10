using WebApplicationAnimel.Models;

namespace WebApplicationAnimel.Data
{
    public interface IRepository<T>
    {
        IEnumerable<Animal> ShowAnimalsByCategory(int CategoryId);

        IEnumerable<Animal> ShowAnimalsByCategory(string categoryName);

        IEnumerable<Animal> Show2AnimalsWithTheMostComment();

        IEnumerable<Animal> ShowAnimals();

        void AddAnimal(Animal animal);

        void RemoveAnimal(int animalId);

        Animal GetAnimalsById(int animalid);

        void EditById(Animal animal);

        void AddComment(Comment comment,int AnimalId);


    }
}
