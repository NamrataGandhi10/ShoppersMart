using ShoppersMart.API.Data.Models;
using ShoppersMart.API.Services.Interface;
using ShoppersMart.API.Repository.Interface;
namespace ShoppersMart.API.Services.Service;

public class Order : IOrder
{
    private readonly IOrderService _order;
    public Order(IOrderService order) => _order = order;

    public Task<OperationResult> CreateOrder(OrderModel model) => _order.CreateOrder(model);

    public Task<OperationResult<List<OrderItemModel>>> GetOrderData(int id) => _order.GetOrderData(id);

    public Task<OperationResult<List<OrderModel>>> GetOrders(int userId) => _order.GetOrders(userId);
}
