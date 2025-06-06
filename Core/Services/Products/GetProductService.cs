using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Data.Repositories;

namespace Core.Services.Products
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class GetProductService : IGetProductService
    {
        private readonly IProductRepository _productRepository;

        public GetProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Product GetProduct(Guid id)
        {
           return _productRepository.Get(id); 
        }

        public IEnumerable<Product> GetProducts(decimal? minPrice = null, decimal? maxPrice = null)
        {
            var products = _productRepository.GetProducts(minPrice ?? 0, maxPrice ?? 0);
            return products ?? new List<Product>();
        }
    }
}