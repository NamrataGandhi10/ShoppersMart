using ShoppersMart.API.Data.Models;
using ShoppersMart.API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ShoppersMart.API.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUser _user;

    public UserController(IUser user) => _user = user;

    [HttpPost]
    [Route("Register")]
    public async Task<OperationResult> Register([FromBody] UserModel model) => await _user.RegisterUser(model);

    [HttpPost]
    [Route("Login")]
    public async Task<OperationResult<UserModel>> LoginUser([FromBody] LoginModel model) => await _user.Login(model);
}
