﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class CartModel
    {
        public List<ProductModel> products { get; set; }
        public int Quantity { get; set; }
        }
}