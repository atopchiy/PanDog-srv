using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;


namespace WebApi.Controllers
{
    public class RegistrationController : ApiController
    {
        private PanDogDBEntities2 dBEntities = new PanDogDBEntities2();
        [HttpPost]
        [Route("api/registration")]
        public UserInfo Register(UserModel model)
        {
            
            var userInfo = new UserInfo()
            {
                city = model.City,
                country = model.Country,
                email = model.Email,
                firstName = model.FirstName,
                lastName = model.LastName,
                phone = model.Phone,
                street = model.Street,
                index = model.Index,
                
            };
            var user = new PanDogUser() { Login = model.Login, Password = model.Password, UserInfo = userInfo };
            dBEntities.UserInfo.Add(userInfo);
            dBEntities.PanDogUser.Add(user);
            dBEntities.SaveChanges();
            return userInfo;
        }
                
     }
}
