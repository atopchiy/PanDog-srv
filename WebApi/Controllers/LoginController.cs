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
        private PanDogDBEntities1 dBEntities = new PanDogDBEntities1();
        [HttpPost]
        [Route("api/login")]
        public PanDogUser Login(LoginUser loginUser)
        {
            var checkUser = dBEntities.PanDogUser.Select(x => x).FirstOrDefault(x => x.UserInfo.email.Equals(loginUser.Email));
            if (checkUser != null)
            {
                if (checkUser.Password.Equals(loginUser.Password))
                {
                    checkUser.IsAuth = true;
                    return checkUser;
                }
                else return null;
            }
            else return  null;
                
        }
    }
}
