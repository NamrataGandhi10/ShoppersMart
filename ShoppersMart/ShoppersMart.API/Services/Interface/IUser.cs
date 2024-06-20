using ShoppersMart.API.Data.Models;

namespace ShoppersMart.API.Services.Interface;

public interface IUser
{
    public Task<OperationResult> RegisterUser(UserModel model);
    public Task<OperationResult<UserModel>> Login(LoginModel model);
}
