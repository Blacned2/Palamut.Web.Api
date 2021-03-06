using Microsoft.AspNetCore.Mvc;
using Palamut.Web.Api.Services.Interface;
using Palamut.Web.Api.Services.Model;

namespace Palamut.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserLoginService _userLoginService;
        public UserController(IUserLoginService userLoginService)
        {
            this._userLoginService = userLoginService;
        }

        [HttpPost,Route("Register")]
        public ActionResult<UserServiceModel> RegisterRequest(UserServiceModel user)
        {
            var result = _userLoginService.Register(user);
            
            return result.ResultObject;
        }

        [HttpPost,Route("Login")]
        public ActionResult<UserServiceModel> LoginRequest(UserServiceModel user)
        {
            var result = _userLoginService.Login(user);
            
            return result.ResultObject;
        }

    }
}
