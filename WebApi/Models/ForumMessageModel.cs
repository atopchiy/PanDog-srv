using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ForumMessageModel
    {
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public string SubjectName { get; set; }
        public string Date { get; set; }
    }
}