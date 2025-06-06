using System;
using System.Collections.Generic;
using BusinessEntities;
using Data.Dtos;

namespace Core.Services.Products
{
    public interface ICreateOrderService
    {
        Order Create(Guid id, Guid customer, DateTimeOffset orderDate, IEnumerable<OrderItemDto> orderItems);
    }
}
