using System;

namespace WebApi.Models.Orders
{
    public class OrderItemModel 
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

    }
}