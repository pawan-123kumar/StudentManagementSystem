using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    [Authorize(Roles ="Student")]
    public class StudentsController : Controller
    {
        UserContext context = new UserContext();
        UserContext db = new UserContext();
        // GET: Students
        public ActionResult Index()
        {
            var teacher = db.Teachers.ToList();
            return View(teacher);
        }

        public ActionResult Feedback(Guid id)
        {
            Session["TeacherId"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult Feedback(Guid id, StudentFeedback studentFeedback)
        {
            var teacher = context.Teachers.Where(x => x.TeacherId == id).First();
            studentFeedback.TeacherName = teacher.TeacherName;
            studentFeedback.TeacherId = (Guid)Session["TeacherId"];
            studentFeedback.StudenId = (Guid)Session["ID"];
            studentFeedback.StudentName = (string)Session["username"];

            context.feedbacks.Add(studentFeedback);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ShowFeedback()
        {
            
            return View(context.feedbacks.ToList());
        }
    }
}