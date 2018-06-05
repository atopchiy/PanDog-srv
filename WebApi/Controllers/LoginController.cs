using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class LoginController : ApiController
    {
        private PanDogDBEntities2 dBEntities = new PanDogDBEntities2();
        [HttpPost]
        [Route("api/login")]
        public UserModel Login(LoginUser loginUser)
        {
            var checkUser = dBEntities.PanDogUser.SingleOrDefault(x => x.UserInfo.email.Equals(loginUser.Email));
            
            if (checkUser != null)
            {
                if (checkUser.Password.Equals(loginUser.Password))
                {
                    checkUser.IsAuth = true;
                    dBEntities.SaveChanges();
                    var userModel = new UserModel
                    {
                        FirstName = checkUser.UserInfo.firstName,
                        LastName = checkUser.UserInfo.lastName,
                        Email = checkUser.UserInfo.email,
                        Phone = checkUser.UserInfo.phone,
                        Country = checkUser.UserInfo.country,
                        City = checkUser.UserInfo.city,
                        Street = checkUser.UserInfo.street,
                        Index = checkUser.UserInfo.index,
                        Login = checkUser.Login,
                        Password = checkUser.Password,
                        AgainPassword = checkUser.Password,
                        Id = checkUser.UserId
                    };
                    return userModel;
                }
                else return null;
            }
            else return  null;
        }
    }
}
