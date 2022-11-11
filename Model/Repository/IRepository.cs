
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

        T FindById(int Id);





    }
}
