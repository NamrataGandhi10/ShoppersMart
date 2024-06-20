using ShoppersMart.API.Data.Models;
using ShoppersMart.API.Services.Interface;
using ShoppersMart.API.Repository.Interface;

namespace ShoppersMart.API.Services.Service;

public class User : IUser
{
    private readonly IUserService _user;
 
    public User(IUserService userService)
    {
        this._user = userService;
    }

    public Task<OperationResult<UserModel>> Login(LoginModel model)
    {
        return _user.Login(model);
    }

    public Task<OperationResult> RegisterUser(UserModel model)
    {
        return _user.RegisterUser(model);
    }
}
