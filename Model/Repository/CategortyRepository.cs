using Model.DAL;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Model.Repository
{
    public class CategortyRepository : MyRepository<Category, AnimalsContext>
    {
        public CategortyRepository(AnimalsContext Data) : base(Data){ }

        public override bool Edit(Category entity, int Id)
        {
            if (entity == null) { return false; }

            var oldCategory = _data.Set<Category>().Where(category => category.CategoryId == Id).SingleOrDefault();
            if (oldCategory != null && !oldCategory.Equals(entity))
            {
                _data.Set<Category>().Remove(oldCategory);
                _data.Set<Category>().Add(entity);
                Save();
                return true;
            }
            return false;
        }

        public override Category? FindById(int Id)
        {
            return _data.Categories!.FirstOrDefault(c => c.CategoryId == Id);
        }

        
    }
}
