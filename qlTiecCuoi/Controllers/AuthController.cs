using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using qlTiecCuoi.Models;
using qlTiecCuoi.DAL;

namespace qlTiecCuoi.Controllers
{
    public class AuthController : Controller
    {
        Context db = new Context();
        // GET: Auth
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User u)
        {
            var check = db.dbuser.Where(m => m.Email.Equals(u.Email) && m.Password.Equals(u.Password)).FirstOrDefault();
            if (check != null)
            {
                if (check.Email == "admin@gmail.com")
                {
                    return RedirectToAction("Index","Admins");
                }
                else
                {
                    Session["iduser"] = check.IDUser;
                    return RedirectToAction("Index","Home");
                }
            }
            else
            {
                ViewBag.login = "Thông tin đăng nhập không chính xác";
                return View();
            }
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User u)
        {
            if (ModelState.IsValid)
            {
                var check = db.dbuser.Where(m => m.Email == u.Email).FirstOrDefault();
                if (check == null)
                {
                    db.dbuser.Add(u);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Auth");
                }
                else
                {
                    ViewBag.error = "Email đã tồn tại";
                    return View();
                }
            }
            return View();
        }
    }
}