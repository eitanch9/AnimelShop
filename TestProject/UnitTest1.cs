using Model.Models;


namespace TestProject
{
    public class Tests
    {


        Category category1;
        Category category2;
        Category category3;
        Animal animal1;
        Animal animal2;
        Animal animal3;

        [SetUp]
        public void Setup()
        {
            category1 = new Category() { CategoryId = 1, Name = "theFirst" };
            category2 = new Category() { CategoryId = 1, Name = "theFirst" };
            category3 = new Category() { CategoryId = 2, Name = "theSecond" };

             animal1 = new Animal() { Age = 2, AnimalId = 1,Category=category1,Name="First" };
             animal2 = new Animal() { Age = 2, AnimalId = 1, Category = category1, Name = "First" };
             animal3 = new Animal() { Age = 4, AnimalId = 2, Category = category3, Name = "Secend" };
        }

        [Test]
        public void EqualsAnimaIsFalse()
        {
            Assert.IsFalse(animal1.Equals(animal3));
        }

        [Test]
        public void EqualsAnimalTrue()
        {
            Assert.IsTrue(animal1.Equals(animal2));
        }

        [Test]
        public void CategoryEqualsIsTrue()
        {
            Assert.IsTrue(category1.Equals(category2));
        }

        [Test]
        public void CategoryEqualsIsFalse()
        {
            Assert.IsFalse(category1.Equals(category3));
        }
    }
}