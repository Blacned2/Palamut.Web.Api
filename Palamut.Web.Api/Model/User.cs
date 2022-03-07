using Palamut.Web.Api.Enums;
using System;

namespace Palamut.Web.Api.Model
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ProfileUpdatedDate { get; set; }
        public BackOfficeAccess UserAuthLevel { get; set; }
        public User()
        {
            CreatedDate = DateTime.Now;
            UserAuthLevel = BackOfficeAccess.Crook;
        }
    }
}
