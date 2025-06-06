using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class OrderRepository : MemoryRepository<Order>, IOrderRepository
    {
        public IEnumerable<Order> GetOrders(Guid customerId)
        {
            var customers = GetAll().Where(p => p.Customer == customerId).ToList();
            return customers ?? new List<Order>();
        }
    }
}