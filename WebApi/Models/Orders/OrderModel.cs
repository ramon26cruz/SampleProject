using System;
using System.Collections.Generic;
using WebApi.Models.Users;

namespace WebApi.Models.Orders
{
    public class OrderModel
    {
        public OrderModel()
        {
            OrderItems = new List<OrderItemModel>();    
        }
        public DateTimeOffset OrderDate { get; set; }
        public List<OrderItemModel> OrderItems { get; set; }
        public Guid CustomerId { get; set; }
    }
}