
using Model.Models;

namespace Model.Repository
{
    public interface IRepository<T>

    {
        IEnumerable<T> GetItems();

        bool Add(T entity);

        bool Remove(T entity);


        bool Edit(T t);

       
        T FindByReference(T entity);



        //T GetItemsById(int Id);

        //IEnumerable<T> ShowAnimalsByCategory(int Id);

        //IEnumerable<T> Show2AnimalsWithTheMostComment();

        //void AddComment(Comment comment,int Id);


    }
}
