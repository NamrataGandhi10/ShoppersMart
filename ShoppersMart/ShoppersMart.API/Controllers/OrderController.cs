using ShoppersMart.API.Data.Models;
using ShoppersMart.API.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShoppersMart.API.Controllers
{
    [Route("api/")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _order;

        public OrderController(IOrder orderDto) => _order = orderDto;

        [HttpPost]
        [Route("orders")]
        public async Task<OperationResult> CreateOrder(OrderModel model) => await _order.CreateOrder(model);

        [HttpGet]
        [Route("orders")]
        public async Task<OperationResult<List<OrderModel>>> GetOrders(int userId) => await _order.GetOrders(userId);

        [HttpGet]
        [Route("orders/{id}")]
        public async Task<OperationResult<List<OrderItemModel>>> GetOrderData(int id) => await _order.GetOrderData(id);
    }

}
