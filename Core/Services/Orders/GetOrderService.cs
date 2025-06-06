using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Core.Services.Products;
using Data.Repositories;

namespace Core.Services.Orders
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class GetOrderService : IGetOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public Order GetOrder(Guid id)
        {
            return _orderRepository.Get(id);
        }

        public IEnumerable<Order> GetOrders(Guid customerId)
        {
            var orders = _orderRepository.GetOrders(customerId);
            return orders ?? new List<Order>();
        }
    }
}