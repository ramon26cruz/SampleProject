using System;

namespace BusinessEntities
{
    public class OrderItem : IdObject
    {
        public Product Product { get; protected set; }
        public int Quantity { get; protected set; }  
        public decimal TotalPrice => Product.Price * Quantity;
        public void SetProduct(Product product)
        {
            Product = product ?? throw new ArgumentNullException(nameof(product), "Product cannot be null.");
        }
        public void SetQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
            }
            Quantity = quantity;
        }

    }
    
}
