﻿using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Products
{
    public interface IGetProductService
    {
        Product GetProduct(Guid id);
        IEnumerable<Product> GetProducts(decimal? minPrice = null, decimal? maxPrice = null);

    }
}