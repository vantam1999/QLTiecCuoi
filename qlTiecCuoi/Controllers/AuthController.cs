﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace qlTiecCuoi.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }
        
        public ActionResult Register()
        {
            return View();
        }
    }
}