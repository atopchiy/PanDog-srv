using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ProductController : ApiController
    {
        private PanDogDBEntities dBEntities = new PanDogDBEntities();
        [HttpGet]
        [Route("api/products")]
        public List<ProductModel> GetProducts()
        {
            List<ProductModel> productModels = new List<ProductModel>();
            var products = dBEntities.Product.Select(x => x).ToList();
            List<ReviewModel> reviews = new List<ReviewModel>();
            List<string> srcList = new List<string>();
            foreach (var product in products)
            {
                var productPhotos = dBEntities.Photo.Select(x => x).Where(x => x.productId == product.ID).ToList();
                var productReviews = dBEntities.Review.Where(x => x.productId == product.ID).ToList();
                foreach(var review in productReviews)
                {
                    var prodReview = new ReviewModel()
                    {
                        Name = review.name,
                        Message = review.message,
                        Date = review.message
                    };
                    reviews.Add(prodReview);
                }
                foreach(var prodPhoto in productPhotos)
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
                    photos = srcList,
                    reviews = reviews
                });
            }
            return productModels;
        }
    }
}
