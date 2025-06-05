using BusinessEntities;
using Common;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class ProductRepository : MemoryRepository<Product>, IProductRepository
    {
        public IEnumerable<Product> GetProducts(decimal minPrice, decimal maxPrice)
        {
            var products = GetAll().Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
            return products ?? new List<Product>();
        }
    }
}