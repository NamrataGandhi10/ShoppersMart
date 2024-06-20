using ShoppersMart.API.Data.Models;
namespace ShoppersMart.API.Repository.Interface;
public interface IOrderService
{
    public Task<OperationResult> CreateOrder(OrderModel model);
    public Task<OperationResult<List<OrderModel>>> GetOrders(int userId);
    public Task<OperationResult<List<OrderItemModel>>> GetOrderData(int id);
}
