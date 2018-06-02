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
        private PanDogDBEntities1 dBEntities = new PanDogDBEntities1();
        [HttpGet]
        [Route("api/products")]
        public List<ProductModel> GetProducts()
        {
            List<ProductModel> productModels = new List<ProductModel>();
            var products = dBEntities.Product.Select(x => x).ToList();
            List<string> srcList = new List<string>();
            foreach (var product in products)
            {
                List<Photo> productPhotos = dBEntities.Photo.Select(x => x).Where(x => x.productId == product.ID).ToList();
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
                    reviews = product.reviews,
                    discount = product.discount,
                    photos = srcList
                });
            }
            return productModels;
        }
    }
}
