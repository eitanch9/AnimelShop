﻿
using Microsoft.EntityFrameworkCore;
using Model.DAL;
using Model.Models;

namespace Model.Repository
{
    public abstract class MyRepository<T, TDBContext> : IRepository<T> where T : class  where TDBContext : DbContext
    {
        private TDBContext _data { get; set; }

        public MyRepository(TDBContext Data)
        {
            _data = Data;
        }

        public bool Add(T entity)
        {
            if (entity == null) { return false; }
            if (FindByReference(entity) != null) { return false; }

            _data.Set<T>().Add(entity);
            Save();
            return true;

        }

        protected void Save()
        {
            _data.SaveChanges();
        }

        public bool Remove(T entity)
        {
            if (entity == null) { return false; }
            if (FindByReference(entity) == null) { return false; }
      
           _data.Set<T>().Remove(entity);
            Save();
            return true;      
        
        }

        public T FindByReference(T entity) => GetItems().SingleOrDefault(entity);           
        
        public IEnumerable<T> GetItems()=> _data.Set<T>().AsNoTracking();


        public abstract bool Edit(T entity);
       

      
    }
}