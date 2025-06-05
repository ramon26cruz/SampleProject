using System;
using BusinessEntities;

namespace Core.Services.Users
{
    public interface ICreateProductService
    {
        Product Create(Guid id, string name, decimal price, string description);
    }
}
