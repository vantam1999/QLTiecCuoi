using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using qlTiecCuoi.Models;
using qlTiecCuoi.DAL;

namespace qlTiecCuoi.Controllers
{
    public class WeddingController : Controller
    {
        //public static List<_MonAn> listMonAn;
        Context db = new Context();
        // GET: Wedding 
        // hall: sảnh tiệc
        public ActionResult Hall()
        {
            return View();
        }

        public ActionResult Food()
        {
            return View(db.dbmonan.ToList());
        }

        public ActionResult Service()
        {
            return View(db.dbdichvu.ToList());
        }

        public ActionResult Picture()
        {
            return View();
        }

        public ActionResult Book()
        {
            return View();
        }
        public ActionResult dattiec(DatTiec d)
        {
            if (ModelState.IsValid)
            {
                _MonAn monan = Session["monan"] as _MonAn;
                foreach (var item in monan.monans)
                {
                    OrderMonAn m = new OrderMonAn();
                    m.IDMonAn = item.IDMonAn;
                    m.IDUSer = int.Parse(Session["iduser"].ToString());
                    db.OrderMonAn.Add(m);
                }
                _DichVu dichvu = Session["dichvu"] as _DichVu;
                foreach (var item in dichvu.dichvus)
                {
                    OrderDichVu _d = new OrderDichVu();
                    _d.IDDichVu = item.IDDichVu;
                    _d.IDUser = int.Parse(Session["iduser"].ToString());
                    db.OrderDichVu.Add(_d);
                }
                d.IDUser = int.Parse(Session["iduser"].ToString());
                db.dbdattiec.Add(d);
                db.SaveChanges();
            }
            return RedirectToAction("Thongbao");
        }
        public ActionResult Thongbao()
        {
            return View();
        }
    }
}