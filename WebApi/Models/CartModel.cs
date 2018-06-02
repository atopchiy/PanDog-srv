using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class CartModel
    {
        public int id { get; set; }
        public List<ProductModel> products;

    }
}