using System;
using System.Collections.Generic;

namespace BusinessEntities
{
    public class Order : IdObject
    {
        public DateTimeOffset OrderDate { get; protected set; }
        public decimal TotalPrice => Product.Price * Quantity;  
        public Product Product { get; protected set; }
        public decimal Quantity { get; set; }

        public void SetOrderDate(DateTimeOffset orderDate)
        {
            if (orderDate == default)
            {
                throw new ArgumentNullException("Order date was not provided.");
            }
            OrderDate = orderDate;
        }

        public void SetProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Product was not provided.");
            }
            Product = product;
        }

        public void SetQuantity(decimal quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException("Quantity must be greater than zero.");
            }
            Quantity = quantity;
        }
    }
    
}
