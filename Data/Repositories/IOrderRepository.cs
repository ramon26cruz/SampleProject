using BusinessEntities;
using System;
using System.Collections.Generic;

namespace Data.Repositories
{
    public interface IOrderRepository : IMemoryRepository<Order>
    {
        IEnumerable<Order> GetOrders(Guid customerId);
        void DeleteAll();
    }
}