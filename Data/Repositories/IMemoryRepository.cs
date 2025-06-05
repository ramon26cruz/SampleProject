using BusinessEntities;
using System;
using System.Collections.Generic;

namespace Data.Repositories
{
    public interface IMemoryRepository<T> where T : IdObject
    {
        void Save(T entity);
        void Delete(T entity);
        T Get(Guid id);
        IEnumerable<T> GetAll();
    }
}