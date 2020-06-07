using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using qlTiecCuoi.Models;
using qlTiecCuoi.DAL;
namespace qlTiecCuoi.Controllers
{
    public class ChonMonAnController : Controller
    {
        Context db = new Context();
        // GET: ChonMonAn
        public _MonAn Get_()
        {
            _MonAn monan = Session["monan"] as _MonAn;
            if (monan == null || Session["monan"] == null)
            {
                monan = new _MonAn();
                Session["monan"] = monan;
            }
            return monan;
        }
        public ActionResult AddtoList(int id)
        {
            var monan = db.dbmonan.SingleOrDefault(s => s.IDMonAn == id);
            if (monan != null)
            {
                Get_().add(monan);
            }
            return RedirectToAction("Book", "Wedding");
        }
        public ActionResult show()
        {
            if (Session["monan"] != null)
            {
                _MonAn monan = Session["monan"] as _MonAn;
                return PartialView(monan);
            }
            return PartialView();
        }
        public ActionResult delete(int id)
        {
            _MonAn monan = Session["monan"] as _MonAn;
            monan.delete(id);
            return RedirectToAction("Book", "Wedding");
        }
        
    }
}