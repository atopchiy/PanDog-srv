using System.Collections.Generic;

namespace WebApi.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AgainPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Index { get; set; }
        public string Country { get; set; }
        public string Login { get; set; }
        public string Street { get; set; }
        public string Phone { get; set; }
     }
}