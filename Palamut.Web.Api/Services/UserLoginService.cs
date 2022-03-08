using MyWebApi.Context;
using MyWebApi.Model;
using Palamut.Web.Api.Encryption;
using Palamut.Web.Api.Services.Interface;
using Palamut.Web.Api.Services.Model;
using System;
using System.Linq;

namespace Palamut.Web.Api.Services
{
    public class UserLoginService : BaseLoginService, IUserLoginService
    {

        public UserLoginService(PalamutContext context) : base(context)
        {
        }

        public SearchResult<UserServiceModel> Login(UserServiceModel userServiceModel)
        {
            SearchResult<UserServiceModel> searchResult = new SearchResult<UserServiceModel>();

            try
            {
                searchResult.ResultObject = (from u in _context.Users
                                             where u.UserName == userServiceModel.UserName
                                             && u.Hashkey == EncryptPlainTextToCipherText.Encrypt(userServiceModel.Password)
                                             || u.Email == userServiceModel.Email
                                             && u.Hashkey == EncryptPlainTextToCipherText.Encrypt(userServiceModel.Password)
                                             select new UserServiceModel
                                             {
                                                 UserName = u.UserName,
                                                 Email = u.Email,
                                                 Password = EncryptPlainTextToCipherText.Decrypt(u.Hashkey)
                                             }).FirstOrDefault();

                if (searchResult.ResultObject != null)
                {
                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultType = ResultType.Error;
                    searchResult.ResultMessage = "Kullanici bulunamadi";
                }
            }
            catch (Exception exp)
            {
                searchResult.ResultType = ResultType.Error;
                searchResult.ResultMessage = exp.Message;
            }

            return searchResult;

        }

        public SearchResult<UserServiceModel> Register(UserServiceModel userServiceModel)
        {
            SearchResult<UserServiceModel> searchResult = new SearchResult<UserServiceModel>();

            try
            {
                var user = (from u in _context.Users
                            where u.Email == userServiceModel.Email
                            select u).FirstOrDefault();

                if (user != null)
                {
                    searchResult.ResultMessage = "Kullanici zaten var";
                    searchResult.ResultType = ResultType.Error;
                }
                else
                {
                    User created = new User()
                    {
                        UserName = userServiceModel.UserName,
                        Email = userServiceModel.Email,
                        Hashkey = EncryptPlainTextToCipherText.Encrypt(userServiceModel.Password)
                    };

                    _context.Add(created);
                    _context.SaveChanges();

                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultType = ResultType.Success;
                    searchResult.ResultObject = userServiceModel;
                }

            }
            catch (Exception exp)
            {
                searchResult.ResultMessage = exp.Message;
                searchResult.ResultType = ResultType.Error;
            }

            return searchResult;
        }

        public SearchResult<UserServiceModel> PasswordReset()
        {
            throw new System.NotImplementedException();
        }
    }
}
