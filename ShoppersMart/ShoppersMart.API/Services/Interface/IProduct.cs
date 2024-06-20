using ShoppersMart.API.Data.Models;

namespace ShoppersMart.API.Services.Interface;

public interface IProduct
{
    public Task<OperationResult<List<ProductModel>>> GetProducts();
    public Task<OperationResult> CreateProduct(ProductModel model);
    public Task<OperationResult> UpdateProduct(ProductModel model, int id);
    public Task<OperationResult> DeleteProduct(int id, int userId);
}
