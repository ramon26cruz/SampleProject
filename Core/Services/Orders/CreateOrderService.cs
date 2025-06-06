using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Core.Factories;
using Core.Services.Products;
using Data.Dtos;
using Data.Repositories;

namespace Core.Services.Orders
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class CreateOrderService : ICreateOrderService
    {
        private readonly IIdObjectFactory<Order> _orderFactory;
        private readonly IIdObjectFactory<OrderItem> _orderItemFactory;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        public CreateOrderService(IIdObjectFactory<Order> orderFactory, IOrderRepository orderRepository, IIdObjectFactory<OrderItem> orderItemFactory, IProductRepository productRepository)
        {
            _orderFactory = orderFactory;
            _orderRepository = orderRepository;
            _orderItemFactory = orderItemFactory;
            _productRepository = productRepository;
        }
        public Order Create(Guid id, Guid customer, DateTimeOffset orderDate, IEnumerable<OrderItemDto> orderItems)
        {
            var order = _orderFactory.Create(id);
            order.SetCustomer(customer);
            order.SetOrderDate(orderDate);

            var orderItemList = new List<OrderItem>();
            if (orderItems != null)
            {
                foreach (var o in orderItems)
                {
                    var orderItem = _orderItemFactory.Create(o.Id);
                    var product = _productRepository.Get(o.ProductId);  
                    if (product == null)
                    {
                        throw new ArgumentException($"Product with ID {o.ProductId} does not exist.");
                    }
                    orderItem.SetProduct(product);
                    orderItem.SetQuantity(o.Quantity);
                    orderItemList.Add(orderItem);
                }
            }
            order.SetOrderItems(orderItemList);
            _orderRepository.Save(order);
            return order;
        }
    }
}