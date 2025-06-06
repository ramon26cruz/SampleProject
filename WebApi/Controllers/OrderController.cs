using BusinessEntities;
using Core.Services.Orders;
using Core.Services.Products;
using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using WebApi.Mappers;
using WebApi.Models.Orders;
using WebApi.Models.Users;

namespace WebApi.Controllers
{
    [RoutePrefix("orders")]
    public class OrderController : BaseApiController
    {
        private readonly ICreateOrderService _createOrderService;
        private readonly IGetOrderService _getOrderService;
        private readonly IUpdateOrderService _updateOrderService;
        private readonly IDeleteOrderService _deleteOrderService;
        public OrderController(ICreateOrderService createOrderService, IGetOrderService getOrderService,
            IUpdateOrderService updateOrderService, IDeleteOrderService deleteOrderService)
        {
            _createOrderService = createOrderService;
            _getOrderService = getOrderService;
            _updateOrderService = updateOrderService;
            _deleteOrderService = deleteOrderService;
        }

        [Route("{orderId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateOrder(Guid orderId, [FromBody] OrderModel model)
        {
            if (model.OrderItems == null || !model.OrderItems.Any())
            {
                return DoesNotExist();
            }

            var orderItems = OrderItemMapper.ToDtoList(model.OrderItems);

            var order = _createOrderService.Create(orderId, model.CustomerId, model.OrderDate, orderItems);
            return Found(new OrderData(order));
        }

        [Route("{orderId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateOrder(Guid orderId, [FromBody] OrderModel model)
        {
            var order = _getOrderService.GetOrder(orderId);
            if (order == null)
            {
                return DoesNotExist();
            }

            var orderItems = OrderItemMapper.ToDtoList(model.OrderItems);
            _updateOrderService.Update(order, orderItems);

            return Found(new OrderData(order));
        }

        [Route("{orderId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteOrder(Guid orderId)
        {
            var order = _getOrderService.GetOrder(orderId);
            if (order == null)
            {
                return DoesNotExist();
            }
            _deleteOrderService.Delete(order);
            return Found();
        }

        [Route("{orderId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetOrder(Guid orderId)
        {
            var order = _getOrderService.GetOrder(orderId);
            if (order == null)
            {
                return DoesNotExist();
            }
            return Found(new OrderData(order));
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetOrders(int skip, int take, Guid customerId)
        {
            var orders = _getOrderService.GetOrders(customerId)
                                       .Skip(skip).Take(take)
                                       .Select(q => new OrderData(q))
                                       .ToList();
            return Found(orders);
        }
    }
}
