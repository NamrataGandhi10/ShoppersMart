using ShoppersMart.API.Data.Models;
using ShoppersMart.API.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShoppersMart.API.Controllers;

[Route("api/")]
[ApiController]
[Authorize]
public class ProductController : ControllerBase
{
    private readonly IProduct _product;
    public ProductController(IProduct productDto) => _product = productDto;

    [HttpGet]
    [Route("products")]
    public async Task<OperationResult<List<ProductModel>>> GetProducts() => await _product.GetProducts();


    [HttpPost]
    [Route("products")]
    public async Task<OperationResult> CreateProduct(ProductModel model) => await _product.CreateProduct(model);


    [HttpPut]
    [Route("products/{id}")]
    public async Task<OperationResult> UpdateProduct(ProductModel model, int id) => await _product.UpdateProduct(model, id);


    [HttpDelete]
    [Route("products/{id}")]
    public async Task<OperationResult> DeleteProduct(int id, int userId) => await _product.DeleteProduct(id, userId);
}
