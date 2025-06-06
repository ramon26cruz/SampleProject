using Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.Orders;

namespace WebApi.Mappers
{
    public static class OrderItemMapper
    {
        public static List<OrderItemDto> ToDtoList(IEnumerable<OrderItemModel> models)
        {
            if (models == null)
                return new List<OrderItemDto>();

            return models.Select(item => new OrderItemDto
            {
                Id = item.Id,
                ProductId = item.ProductId,
                Quantity = item.Quantity
            }).ToList();
        }
    }
}