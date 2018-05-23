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
        public int Login(LoginUser loginUser)
        {
            var checkUser = dBEntities.PanDogUser.Select(x => x).FirstOrDefault(x => x.Login.Equals(loginUser.Login));
            if (checkUser != null)
            {
                if (checkUser.Password.Equals(loginUser.Password))
                    return checkUser.UserId;
                else return 0;
            }
            else return -1;
                
        }
    }
}
