using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ForumSubjectModel
    {
      public int SubjectId { get; set; }
      public string SubjectName { get; set; }
      public List<ForumMessage> messages { get; set; }
      public string AuthorLogin { get; set; }
    }
}