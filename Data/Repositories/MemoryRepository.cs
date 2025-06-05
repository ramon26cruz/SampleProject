using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;

namespace Data.Repositories
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class MemoryRepository<T> : IMemoryRepository<T> where T : IdObject
    {
        private readonly Dictionary<Guid, T> _storage = new Dictionary<Guid, T>();
        public void Save(T entity)
        {
            _storage[entity.Id] = entity;
        }
        public void Delete(T entity)
        {
            _storage.Remove(entity.Id);
        }
        public T Get(Guid id)
        {
            _storage.TryGetValue(id, out var entity);
            return entity;
        }
        public IEnumerable<T> GetAll()
        {
            return _storage.Values;
        }
        public void DeleteAll()
        {
            _storage.Clear(); 
        }
    }
}