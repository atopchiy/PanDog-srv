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
        private PanDogDBEntities dBEntities = new PanDogDBEntities();
        [HttpGet]
        [Route("api/getcurrentuser")]
        public UserModel GetUser()
        {
            var user = dBEntities.PanDogUser.Single(x => x.IsAuth == true);
                            
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
                Id = user.UserId
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
        [HttpGet]
        [Route("api/usersubjects")]
        public List<ForumSubjectModel> GetUserSubjects(string userLogin)
        {
            var user = dBEntities.PanDogUser.Single(x => x.Login.Equals(userLogin));
            var subjects = dBEntities.ForumSubject.Where(x => x.userId == user.UserId).ToList();
            List<ForumSubjectModel> subjectModels = new List<ForumSubjectModel>();
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
            return subjectModels;
        }
        [HttpGet]
        [Route("api/getorders")]
        public OrderModel formUserOrders(string userLogin)
        {
            
            List<CartModel> itemsModel = new List<CartModel>();
            var user = dBEntities.PanDogUser.Single(x => x.Login.Equals(userLogin));
            var items = dBEntities.Cart.Where(x => x.userId == user.UserId).ToList();
            foreach(var item in items)
            {
                var products = getProducts(item);
                var cartModel = new CartModel()
                {
                    products = products,
                    Quantity = products.Count
                };
                itemsModel.Add(cartModel);
            }
            return new OrderModel()
            {
                items = itemsModel,
                UserLogin = userLogin,
                GrossTotal = 0,
                DeviveryTotal = 0,
                ItemsTotal = 0
            };
        }
        public List<ProductModel> getProducts(Cart item)
        {
            List<ProductModel> productModels = new List<ProductModel>();
               var products = dBEntities.Product.Where(x => x.cartId == item.CartID).ToList();
                foreach (var product in products)
                {
                    var photos = getPhotos(product);
                    var reviews = getReviews(product);
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
                        photos = photos,
                        reviews = reviews
                    });
                }
                return productModels;
            
        }
        public List<ReviewModel> getReviews(Product product)
        {
            List<ReviewModel> reviews = new List<ReviewModel>();
                var productReviews = dBEntities.Review.Where(x => x.productId == product.ID).ToList();
                foreach (var review in productReviews)
                {
                    var prodReview = new ReviewModel()
                    {
                        Name = review.name,
                        Message = review.message,
                        Date = review.message
                    };
                    reviews.Add(prodReview);
                }
            
            return reviews;
        }
        public List<string> getPhotos(Product product)
        {
            List<string> srcList = new List<string>();
              var productPhotos = dBEntities.Photo.Select(x => x).Where(x => x.productId == product.ID).ToList();
                foreach (var prodPhoto in productPhotos)
                {
                    srcList.Add(prodPhoto.src);
                }
            
            return srcList;
        }
    }
}
