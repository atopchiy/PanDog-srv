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
    
    public partial class ForumMessage
    {
        public int messageId { get; set; }
        public string messageContent { get; set; }
        public int subjectId { get; set; }
        public int userid { get; set; }
        public string date { get; set; }
    
        public virtual ForumSubject ForumSubject { get; set; }
        public virtual PanDogUser PanDogUser { get; set; }
    }
}