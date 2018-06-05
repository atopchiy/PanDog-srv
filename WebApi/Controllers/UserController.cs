using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class UserController : ApiController
    {
        private PanDogDBEntities2 dBEntities = new PanDogDBEntities2();
        [HttpGet]
        [Route("api/getcurrentuser")]
        public UserModel GetUser()
        {
            var user = dBEntities.PanDogUser.Single(x => x.IsAuth == true);
            var subjects = dBEntities.ForumSubject.Where(x => x.userId == user.UserId).ToList();
            List<ForumSubjectModel> subjectModels = new List<ForumSubjectModel>();
            var orders = dBEntities.Cart.Where(x => x.userId == user.UserId).ToList();
            List<CartModel> cartModels = new List<CartModel>();

            foreach(var order in orders)
            {
                var products = dBEntities.Product.Where(x => x.cartId == order.CartID).ToList();
                var productModels = GetProducts(products);
                var cart = new CartModel()
                {
                    Amount = order.amount,
                    UserId = user.UserId,
                    products = productModels
                };
                cartModels.Add(cart);
            }
            foreach (var subject in subjects)
            {
                var messages = dBEntities.ForumMessage.Where(x => x.subjectId == subject.subjectId).ToList();
                var subj = new ForumSubjectModel()
                {
                    SubjectId = subject.subjectId,
                    SubjectName = subject.subjectName,
                    messages = messages,
                    AuthorLogin = user.Login
                };
                subjectModels.Add(subj);
            }
                var userModel = new UserModel()
            {
                FirstName = user.UserInfo.firstName,
                LastName = user.UserInfo.lastName,
                Email = user.UserInfo.email,
                Phone = user.UserInfo.phone,
                Country = user.UserInfo.country,
                City = user.UserInfo.city,
                Street = user.UserInfo.street,
                Index = user.UserInfo.index,
                Login = user.Login,
                Password = user.Password,
                AgainPassword = user.Password,
                Id = user.UserId,
                subjects = subjectModels,
                orders = cartModels
            };
            return userModel;
        }
        public List<ProductModel> GetProducts(List<Product> products)
        {
            List<ProductModel> productModels = new List<ProductModel>();
            List<string> srcList = new List<string>();
            foreach (var product in products)
            {
                List<Photo> productPhotos = dBEntities.Photo.Where(x => x.productId == product.ID).ToList();
                foreach (var prodPhoto in productPhotos)
                {
                    srcList.Add(prodPhoto.src);
                }
                productModels.Add(new ProductModel
                {
                    id = product.ID,
                    type = product.type,
                    breed = product.breed,
                    age = product.age,
                    desc = product.desc,
                    src = product.src,
                    available = product.available,
                    location = product.location,
                    cost = product.cost,
                    discount = product.discount,
                    photos = srcList
                });
            }
            return productModels;
        }
    }
}
