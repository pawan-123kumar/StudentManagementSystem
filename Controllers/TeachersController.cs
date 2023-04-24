using PagedList;
using PagedList.Mvc;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeachersController : Controller
    {
        UserContext context = new UserContext();
        // GET: Teachers
        public ActionResult Index(string search,int ? i)
        {
            var student = from stud in context.Students
                          where stud.Status == "Activated"
                          select stud;

            return View(student.Where(x=>x.Name.StartsWith(search) || search== null).ToList().ToPagedList(i ?? 1, 10));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                context.Students.Add(student);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            else
                ModelState.AddModelError("", "Error Occurs");
            return View();
        }

        public ActionResult Edit(Guid id)
        {
            var student = context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            if (student != null)
            {
                return View(student);
            }
            else
                ModelState.AddModelError("", "Error occurs");
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Student student) {
            if(ModelState.IsValid)
            {
                context.Entry(student).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
         }
            return View(student);
        }
       

        public ActionResult Delete(Guid id)
        {
            var delete = context.Students.Where(x => x.StudentId == id).FirstOrDefault();

            return View(delete);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(Guid id)
        {
            Student student = context.Students.Find(id);
            context.Students.Remove(student);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(Guid id)
        {
            var details = context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            if (details != null)
            {
                return View(details);
            }
            else
                return View();
        }

        public ActionResult Enable(Guid id)
        {
            Student stud = context.Students.Find(id);
            stud.Status = "Activated";
            context.Entry(stud).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("DisabledPosts", "Teachers");
        }

        public ActionResult Disable(Guid id)
        {
            Student stud = context.Students.Find(id);
            stud.Status = "Deactivated";
            context.Entry(stud).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DisabledPosts()
        {
            var stud = from b in context.Students
                        where b.Status == "Deactivated"
                       select b;

            return View(stud);
        }
    }
}