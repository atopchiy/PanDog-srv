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
        private PanDogDBEntities2 dBEntities = new PanDogDBEntities2();
        [HttpPost]
        [Route("api/savecart")]
        public void SaveCart(CartModel cartModel)
        {
            var products = dBEntities.Product.Select(x => x).ToList();
            var cart = new Cart()
            {
                userId = cartModel.UserId,
                amount = cartModel.Amount
            };
             foreach(var product in products)
            {
                product.cartId = cart.CartID;
            }
            dBEntities.Cart.Add(cart);
            dBEntities.SaveChanges();
        }
    }
}
