using Common.Extensions;
using System;
using System.Collections.Generic;

namespace BusinessEntities
{
   
    public class Order : IdObject
    {
        public Order()
        {
            OrderItems =new List<OrderItem>();
        }
        public DateTimeOffset OrderDate { get; protected set; }
        public List<OrderItem> OrderItems { get; protected set; }
        public Guid Customer { get; protected set; }

        public void SetOrderDate(DateTimeOffset orderDate)
        {
            if (orderDate == default)
            {
                throw new ArgumentNullException("Order date was not provided.");
            }
            OrderDate = orderDate;
        }

        public void SetOrderItems(IEnumerable<OrderItem> orderItems)
        {
            if (orderItems == null)
            {
                throw new ArgumentNullException("OrderItem was not provided.");
            }
            OrderItems.Initialize(orderItems);
        }
        public void SetCustomer(Guid customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("Customer was not provided.");
            }
            Customer = customer;
        }
    }
    
}
