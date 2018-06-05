using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ForumController : ApiController
    {
        private PanDogDBEntities2 dBEntities = new PanDogDBEntities2();
        [HttpGet]
        [Route("api/forum")]
        public List<ForumSubjectModel> GetSubjects()
        {
            var subjects = dBEntities.ForumSubject.Select(x => x).ToList();
            List<ForumSubjectModel> subjectModels = new List<ForumSubjectModel>();
            foreach(var subject in subjects)
            {

                var messages = dBEntities.ForumMessage.Where(x => x.subjectId == subject.subjectId).ToList();
                var userLogin = dBEntities.PanDogUser.Single(x => x.UserId == subject.userId).Login;
                var subj = new ForumSubjectModel()
                {
                    SubjectId = subject.subjectId,
                    SubjectName = subject.subjectName,
                    messages = messages,
                    AuthorLogin = userLogin
                };
                subjectModels.Add(subj);
            }
            return subjectModels;
        }
        [HttpPost]
        [Route("api/forum")]
        public void AddSubject(ForumSubjectModel model)
        {
            var userId = dBEntities.PanDogUser.Single(x => x.Login.Equals(model.AuthorLogin)).UserId;
            var subj = new ForumSubject()
            {
                subjectName = model.SubjectName,
                userId = userId
            };
            dBEntities.ForumSubject.Add(subj);
            dBEntities.SaveChanges();
        }
        [HttpPost]
        [Route("api/forum")]
        public void AddMessage(ForumMessageModel model)
        {
            var subjId = dBEntities.ForumSubject.Single(x => x.subjectName.Equals(model.SubjectName)).subjectId;
            var subj = new ForumMessage()
            {
                userid = model.AuthorId,
                messageContent = model.Content,
                subjectId = subjId,
                date = model.Date
            };
            dBEntities.ForumMessage.Add(subj);
            dBEntities.SaveChanges();
        }
    }
}
