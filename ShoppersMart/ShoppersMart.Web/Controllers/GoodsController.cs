using ShoppersMart.Web.Helper;
using ShoppersMart.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ShoppersMart.Web.Controllers;

[SessionValidation]
public class GoodsController : Controller
{
    private readonly IApiHelper _apiHelper;
    public GoodsController(IApiHelper apiHelper)
    {
        _apiHelper = apiHelper;
    }

    public IActionResult Index()
    {
        return View();
    }
    public async Task<IActionResult> AddProduct(int id)
    {
        ViewBag.Header = "Add New Product";
        if (id > 0)
        {
            var responseMessage = await _apiHelper.MakeApiCallAsync("products", HttpMethod.Get, HttpContext, null);
            var responseAsync = await CommonMethod.HandleApiResponseAsync<List<ProductModel>>(responseMessage);
            var product = responseAsync.Data.Find(o => o.Id == id);
            // Normally, you would get the data from a database
            if (product != null)
            {
                ViewBag.Header = "Edit Product";
                return View(product);
            }
        }
        return View(new ProductModel());
    }

    [HttpGet]
    public async Task<APIResponseResult<List<ProductModel>>> GetProducts()
    {
        var responseMessage = await _apiHelper.MakeApiCallAsync("products", HttpMethod.Get, HttpContext, null);
        var responseAsync = await CommonMethod.HandleApiResponseAsync<List<ProductModel>>(responseMessage);
        return responseAsync;
    }

    [HttpPost]
    public async Task<APIResponseResult<string>> CreateProduct([FromBody] ProductModel model)
    {
        model.UserId = HttpContext.Session.GetInt32("UserId");
        var responseMessage = await _apiHelper.MakeApiCallAsync("products", HttpMethod.Post, HttpContext, model);
        var responseAsync = await CommonMethod.HandleApiResponseAsync<string>(responseMessage);
        return responseAsync;
    }

    [HttpPost]
    public async Task<APIResponseResult<string>> EditProduct([FromBody] ProductModel model)
    {
        model.UserId = HttpContext.Session.GetInt32("UserId");
        var responseMessage = await _apiHelper.MakeApiCallAsync("products/" + model.Id, HttpMethod.Put, HttpContext, model);
        var responseAsync = await CommonMethod.HandleApiResponseAsync<string>(responseMessage);
        return responseAsync;
    }

    [HttpPost]
    public async Task<APIResponseResult<string>> DeleteProduct([FromBody] ProductModel model)
    {
        model.UserId = HttpContext.Session.GetInt32("UserId");
        var responseMessage = await _apiHelper.MakeApiCallAsync("products/" + model.Id + "?userId=" + model.UserId, HttpMethod.Delete, HttpContext, null);
        var responseAsync = await CommonMethod.HandleApiResponseAsync<string>(responseMessage);
        return responseAsync;
    }
}
