using System;
using System.Collections.Generic;


namespace Blog.DataAccess.Repositories{
    public interface IGenericRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T GetById(string Id);
        T Insert(T entity);
        T Update(T entity);
        string Delete(string Id);
        void Save();
    }
}
