using System;
using System.Collections.Generic;

namespace Nova.dao
{
    public interface IRepository<T, K>
    {
        public void Add(T item);
        public T GetById(K id);
        public List<T> GetAll();
        public void Update(T item);
        public void Delete(T item);
    }
}
