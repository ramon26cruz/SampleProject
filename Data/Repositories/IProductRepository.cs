using BusinessEntities;
using System.Collections.Generic;

namespace Data.Repositories
{
    public interface IProductRepository : IMemoryRepository<Product>
    {
        IEnumerable<Product> GetProducts(decimal minPrice, decimal maxPrice);
        void DeleteAll();
    }
}