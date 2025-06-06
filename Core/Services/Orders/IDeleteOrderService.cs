using BusinessEntities;
using Core.Services.Products;

namespace Core.Services.Orders
{
    public interface IDeleteOrderService
    {
        void Delete(Order user);
    }
}