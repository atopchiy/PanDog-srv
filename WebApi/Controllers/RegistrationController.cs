using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using System.Data.Entity.Validation;

namespace WebApi.Controllers
{
    public class RegistrationController : ApiController
    {
        private PanDogDBEntities2 dBEntities = new PanDogDBEntities2();
        [HttpPost]
        [Route("api/registration")]
        public UserInfo Register(UserModel model)
        {
            var cart = new Cart();
            var userInfo = new UserInfo()
            {
                city = model.City,
                country = model.Country,
                email = model.Email,
                firstName = model.FirstName,
                lastName = model.LastName,
                phone = model.Phone,
                street = "kek",
                index = model.Index,
                
            };
            var user = new PanDogUser() { Login = model.Login, Password = model.Password, UserInfo = userInfo, IsAuth = false, Cart = cart };
            dBEntities.UserInfo.Add(userInfo);
            dBEntities.PanDogUser.Add(user);
           
            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges

                dBEntities.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            return userInfo;
        }
                
     }
}
