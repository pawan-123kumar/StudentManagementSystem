using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudentManagementSystem.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            using (var context = new UserContext())
            {
                var user1 = context.Users.Where(model => model.UserName == user.UserName && model.Password == user.Password).FirstOrDefault();
                if(user1!=null)
                {
                    if (user1.Role == "Teacher") {
                        Session["username"] = user1.UserName;
                        FormsAuthentication.SetAuthCookie(user1.UserName, false);
                        return RedirectToAction("Index", "Teachers");
                    }
                    else if (user1.Role == "Student")
                    {
                        Session["ID"] = user1.UserId;
                        Session["username"] = user1.UserName;
                        FormsAuthentication.SetAuthCookie(user1.UserName, false);
                        return RedirectToAction("Index", "Students");
                    }
                    ModelState.AddModelError("", "Invalid UserName or Password");
                    return View();

                }
               
                else
                    ModelState.AddModelError("", "Invalid UserName or Password");
                return View();
            }
              
           
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User user)
        {
            using (var context = new UserContext())
            {
                user.Role = "Student";
                context.Users.Add(user);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["username"] = null;
            return RedirectToAction("Login");
        }

    }
    
}
