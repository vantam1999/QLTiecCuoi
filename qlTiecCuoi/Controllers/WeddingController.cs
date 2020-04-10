using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace qlTiecCuoi.Controllers
{
    public class WeddingController : Controller
    {
        // GET: Wedding 
        // hall: sảnh tiệc
        public ActionResult Hall()
        {
            return View();
        }

        public ActionResult Food()
        {
            return View();
        }

        public ActionResult Service()
        {
            return View();
        }

        public ActionResult Picture()
        {
            return View();
        }

        public ActionResult Book()
        {
            return View();
        }
    }
}