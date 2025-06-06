using BusinessEntities;
using Common;
using Data.Repositories;

namespace Core.Services.Products
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateProductService : IUpdateProductService
    {
        public void Update(Product product, string name, decimal price, string description)
        {
            product.SetName(name);
            product.SetPrice(price);
            product.SetDescription(description);
        }
    }
}