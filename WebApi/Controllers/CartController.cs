using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CartController : ApiController
    {
        private PanDogDBEntities dBEntities = new PanDogDBEntities();
        [HttpPost]
        [Route("api/savecart")]
        public void SaveCart(CartModel cartModel)
        {
           var user = dBEntities.PanDogUser.SingleOrDefault(x => x.IsAuth == true);
           
             var cart = new Cart()
            {
                userId = user.UserId,
                quantity = cartModel.Quantity,
               
            };
           
            dBEntities.Cart.Add(cart);
            cart = dBEntities.Cart.Single(x => x.userId == user.UserId);
            foreach (var product in cartModel.products)
            {
                var dbProduct = dBEntities.Product.Find(product.id);
                dbProduct.cartId = cart.CartID;

            }
            dBEntities.SaveChanges();
        }
    }
}
