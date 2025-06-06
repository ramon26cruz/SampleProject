using BusinessEntities;
using Common;
using Core.Factories;
using Data.Dtos;
using Data.Repositories;
using System;
using System.Collections.Generic;

namespace Core.Services.Orders
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateOrderService : IUpdateOrderService
    {
        private readonly IIdObjectFactory<OrderItem> _orderItemFactory;
        private readonly IProductRepository _productRepository;
        public UpdateOrderService(IIdObjectFactory<OrderItem> orderItemFactory, IProductRepository productRepository)
        {
            _orderItemFactory = orderItemFactory;
            _productRepository = productRepository;
        }

        public void Update(Order order, IEnumerable<OrderItemDto> orderItems)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));
            if (orderItems == null)
                throw new ArgumentNullException(nameof(orderItems));

            var orderItemList = new List<OrderItem>();
            foreach (var dto in orderItems)
            {
                var orderItem = _orderItemFactory.Create(dto.Id);
                var product = _productRepository.Get(dto.ProductId);
                if (product == null)
                    throw new ArgumentException($"Product with ID {dto.ProductId} does not exist.");

                orderItem.SetProduct(product);
                orderItem.SetQuantity(dto.Quantity);
                orderItemList.Add(orderItem);
            }

            order.SetOrderItems(orderItemList);
        }
    }
}
