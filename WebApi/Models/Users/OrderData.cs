using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Models.Users
{
    public class OrderData : IdObjectData
    {
        public OrderData(Order order) : base(order)
        {
            CustomerId = order.Customer;
            OrderDate = order.OrderDate;
            OrderItems = order.OrderItems.Select(item => new OrderItemData(item)).ToList();
        }
        public Guid CustomerId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public List<OrderItemData> OrderItems { get; set; }
    }
}