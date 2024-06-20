using ShoppersMart.API.Data.Models;

namespace ShoppersMart.API.Repository.Interface;
public interface IUserService
{
    public Task<OperationResult> RegisterUser(UserModel model);
    public Task<OperationResult<UserModel>> Login(LoginModel model);
}
