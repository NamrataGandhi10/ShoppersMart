using ShoppersMart.Web.Helper;
using Microsoft.AspNetCore.Mvc;

namespace ShoppersMart.Web.Controllers;

[SessionValidation]
public class CartController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
