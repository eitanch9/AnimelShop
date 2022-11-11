﻿
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
        { return _data.Animals.OrderBy(animal => animal.Comments!.Count).Take(numofAnimalReturn);  }

        public Animal GetAnimalsById(int animalid)
        { return _data.Animals.Where(a => a.AnimalId == animalid).SingleOrDefault()!; }

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
    }
    
}