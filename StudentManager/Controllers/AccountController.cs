using StudentManager.DAL.Repository;
using StudentManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudentManager.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserRepository userRep = new UserRepository();
                UserViewModel uvm = userRep.Validate(model);
                if (uvm != null)
                {
                    string userData = string.Format("{0}|{1}|{2}|{3}", uvm.Username, uvm.Name, uvm.Email, uvm.RoleName);
                    //Create FormAuthentication Ticket. We are using this approach because we
                    //want to store other details of the user and not just the username.
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, uvm.Name, DateTime.Now, DateTime.Now.AddMinutes(10), false, userData);

                    //Now we encrypt the ticket
                    string encryptedTicket = FormsAuthentication.Encrypt(ticket);

                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    Response.Cookies.Add(cookie);

                    return RedirectToAction("Index", "Students");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Credentials");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid Credentials");
            }
            return View();
        }
        public ActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserRepository repo = new UserRepository();

                repo.AddUser(model);
            }

            return RedirectToAction("Login");
        }
    }
}