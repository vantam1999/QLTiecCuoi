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
        public ActionResult danhsachdattiec(string tinhtrang)
        {
            if (tinhtrang == "true")
            {
                ViewBag.tinhtrang = 1;
                return View(db.dbdattiec.Where(m => m.TinhTrang == true).ToList());
            }
            ViewBag.tinhtrang = 0;
            return View(db.dbdattiec.Where(m => m.TinhTrang == false).ToList());
        }
        public ActionResult dattiec(DatTiec d)
        {
            if (ModelState.IsValid)
            {
                d.TinhTrang = false;
                d.IDUser = int.Parse(Session["iduser"].ToString());
                db.dbdattiec.Add(d);
                _MonAn monan = Session["monan"] as _MonAn;
                foreach (var item in monan.monans)
                {
                    OrderMonAn m = new OrderMonAn();
                    m.IDMonAn = item.IDMonAn;
                    m.IDDatTiec = d.IDDatTiec;
                    db.OrderMonAn.Add(m);
                }
                _DichVu dichvu = Session["dichvu"] as _DichVu;
                foreach (var item in dichvu.dichvus)
                {
                    OrderDichVu _d = new OrderDichVu();
                    _d.IDDichVu = item.IDDichVu;
                    _d.IDDatTiec = d.IDDatTiec;
                    db.OrderDichVu.Add(_d);
                }
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