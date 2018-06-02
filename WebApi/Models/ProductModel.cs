using System.Collections.Generic;

namespace WebApi.Models
{
    public class ProductModel
    {
       
        public int id { get; set; }
        public string src { get; set; }
        public string type { get; set; }
        public string breed { get; set; }
        public int age { get; set; }
        public string desc{ get; set; }
        public double cost { get; set; }
        public bool available { get; set; }
        public string location { get; set; }
        public List<string> photos { get; set; }
        public int discount { get; set; }
        public string reviews { get; set; }
    }
}
