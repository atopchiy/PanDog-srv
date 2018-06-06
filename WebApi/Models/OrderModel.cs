using System.Collections.Generic;

namespace WebApi.Models
{
    public class OrderModel
    {

        public List<CartModel> items { get; set; }
        public int GrossTotal { get; set; }
        public int ItemsTotal { get; set; }
        public int DeviveryTotal { get; set; }
        public string UserLogin { get; set; }
    }
}
