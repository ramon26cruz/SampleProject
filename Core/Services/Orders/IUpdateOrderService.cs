using BusinessEntities;
using Core.Services.Users;
using Data.Dtos;
using System;
using System.Collections.Generic;

namespace Core.Services.Orders
{
    public interface IUpdateOrderService
    {
        void Update(Order order, IEnumerable<OrderItemDto> orderItems);
    }
}
