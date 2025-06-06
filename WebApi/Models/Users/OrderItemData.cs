using BusinessEntities;
using System;

namespace WebApi.Models.Users
{
    public class OrderItemData : IdObjectData
    {
        public OrderItemData(OrderItem item) : base(item)
        {
            ProductId = item.Product.Id;
            Quantity = item.Quantity;
        }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}