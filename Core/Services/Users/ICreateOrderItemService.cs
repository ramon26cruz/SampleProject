using System;
using BusinessEntities;

namespace Core.Services.Users
{
    public interface ICreateOrderItemService
    {
        OrderItem Create(Guid id, Product product, int quantity, decimal totalPrice);
    }
}
