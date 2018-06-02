//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Photo = new HashSet<Photo>();
            this.Review = new HashSet<Review>();
        }
    
        public int ID { get; set; }
        public string src { get; set; }
        public string type { get; set; }
        public string breed { get; set; }
        public int age { get; set; }
        public string desc { get; set; }
        public double cost { get; set; }
        public bool available { get; set; }
        public string location { get; set; }
        public int discount { get; set; }
        public Nullable<int> cartId { get; set; }
    
        public virtual Cart Cart { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Photo> Photo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Review { get; set; }
    }
}
