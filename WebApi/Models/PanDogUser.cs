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
    
    public partial class PanDogUser
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int UserInfoId { get; set; }
        public bool IsAuth { get; set; }
        public int CartID { get; set; }
    
        public virtual Cart Cart { get; set; }
        public virtual UserInfo UserInfo { get; set; }
    }
}
