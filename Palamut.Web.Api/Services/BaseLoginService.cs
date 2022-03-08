using MyWebApi.Context;

namespace Palamut.Web.Api.Services
{
    public class BaseLoginService
    {
        public readonly PalamutContext _context;
        public BaseLoginService(PalamutContext context)
        {
            this._context = context;
        }
    }
}
