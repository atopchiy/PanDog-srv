using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccessLibrary;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Web.ViewModels;
using Web.Helpers;

namespace Web.Controllers
{
    [Route("api/registration")]
    public class RegistrationController : Controller
    {
        private readonly PanDogDBEntities _appDbContext;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public RegistrationController(UserManager<User> userManager, IMapper mapper, PanDogDBEntities appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        // POST api/accounts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<User>(model);

            var result = await _userManager.CreateAsync(userIdentity,model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

             _appDbContext.UserInfo.Add(new UserInfo { UID = userIdentity.UID, firstName = model.FirstName,lastName = model.LastName, city = model.City,
            country = model.Country, email = model.Email, index = model.Index, phone = model.Phone, street = model.Street});
             _appDbContext.SaveChanges();

            return new OkObjectResult("Account created");
        }
    }

}