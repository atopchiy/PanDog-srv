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
        private PanDogDBEntities dBEntities = new PanDogDBEntities();
        [HttpPost]
        [Route("api/registration")]
        public UserModel Register(RegisterModel model)
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
            var user = new PanDogUser() { Login = model.Login, Password = model.Password, UserInfo = userInfo, IsAuth = false};
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
            user = dBEntities.PanDogUser.SingleOrDefault(x => x.Login.Equals(model.Login));
            var userModel = new UserModel()
            {
                FirstName = userInfo.firstName,
                LastName = userInfo.lastName,
                Email = userInfo.email,
                Phone = userInfo.phone,
                Country = userInfo.country,
                City = userInfo.city,
                Street = userInfo.street,
                Index = userInfo.index,
                Login = user.Login,
                Password = user.Password,
                AgainPassword = user.Password,
                Id = user.UserId
            };
            return userModel;
        }
                
     }
}
