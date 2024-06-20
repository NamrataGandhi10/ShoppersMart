using ShoppersMart.API.Data.Models;
using ShoppersMart.API.Services.Interface;
using ShoppersMart.API.Repository.Interface;

namespace ShoppersMart.API.Services.Service;
public class Product : IProduct
{
    private readonly IProductService _product;
    public Product(IProductService productService)
    {
        _product = productService;
    }
    public Task<OperationResult> CreateProduct(ProductModel model) => _product.CreateProduct(model);

    public Task<OperationResult> DeleteProduct(int id, int userId) => _product.DeleteProduct(id, userId);

    public Task<OperationResult<List<ProductModel>>> GetProducts() => _product.GetProducts();

    public Task<OperationResult> UpdateProduct(ProductModel model, int id) => _product.UpdateProduct(model, id);
}