using Palamut.Web.Api.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyWebApi.Model
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Hashkey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ProfileUpdatedDate { get; set; }
        public BackOfficeAccess? UserAuthLevel { get; set; }
        public User()
        {
            CreatedDate = DateTime.Now;
            UserAuthLevel = BackOfficeAccess.Crook;
        }
    }
}

