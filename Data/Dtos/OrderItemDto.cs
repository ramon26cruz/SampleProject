using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Dtos
{
    public class OrderItemDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
