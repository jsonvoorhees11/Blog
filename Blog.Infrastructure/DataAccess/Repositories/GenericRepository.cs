using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Blog.DataAccess.Repositories{
    public class GenericRepository<T> : IGenericRepository<T> where T:class
    {
        private BlogDbContext _context;
        private DbSet<T> table;
        public GenericRepository(BlogDbContext context)
        {
            _context = context;
            table = _context.Set<T>();

        }
        public IEnumerable<T> GetAll(){
            return table.ToList();
        }
        public T GetById(string id){
            return table.Find(id);
        }
        public T Insert(T entity){
            table.Add(entity);
            return entity;
            
        }
        public T Update(T entity){
            table.Update(entity);
            return entity;
        }
        public string Delete(string id){
            T entityToRemove = table.Find(id);
            table.Remove(entityToRemove);
            return id;
        }
        public void Save(){
            _context.SaveChanges();
        }
    }
}
