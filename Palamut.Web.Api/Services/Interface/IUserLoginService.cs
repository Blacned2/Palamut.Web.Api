using MyWebApi.Model;
using Palamut.Web.Api.Services.Model;

namespace Palamut.Web.Api.Services.Interface
{
    public interface IUserLoginService
    {
        SearchResult<UserServiceModel> Login(UserServiceModel userServiceModel);
        SearchResult<UserServiceModel> Register(UserServiceModel userServiceModel);
        SearchResult<UserServiceModel> PasswordReset();
    }
}
