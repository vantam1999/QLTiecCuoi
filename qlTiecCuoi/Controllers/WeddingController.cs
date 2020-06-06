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
            return View();
        }

        public ActionResult Picture()
        {
            return View();
        }

        public ActionResult Book()
        {
            //DanhSanhMonAn ds = Session["DanhSanhMonAn"] as DanhSanhMonAn;
            ViewBag.monan = Session["monan"];
            //listMonAn = Session["monan"];
            return View();
        }
        //public ActionResult ThemMonAn(int id)
        //{
        //    var item = db.dbmonan.Where(m => m.IDMonAn == id).FirstOrDefault();
        //    if (item != null)
        //    {
        //        if (listMonAn == null)
        //        {
        //            listMonAn = new List<_MonAn>();
        //            listMonAn.Add(new _MonAn { monan = item, SoLuong = 1 });
        //        }
        //        else
        //        {
        //            var mon = listMonAn.FirstOrDefault(m => m.monan.IDMonAn == item.IDMonAn);
        //            if (mon != null)
        //            {
        //                mon.SoLuong++;
        //            }
        //            else
        //            {
        //                listMonAn.Add(new _MonAn { monan = item, SoLuong = 1 });
        //            }
        //        }
        //    }
        //    Session["monan"] = listMonAn;
        //    return RedirectToAction("Book");
        //}
        //public DanhSanhMonAn GetMonAn()
        //{
        //    DanhSanhMonAn ds = Session["DanhSanhMonAn"] as DanhSanhMonAn;
        //    if (ds == null || Session["DanhSanhMonAn"] == null)
        //    {
        //        ds = new DanhSanhMonAn();
        //        Session["DanhSanhMonAn"] = ds;
        //    }
        //    return ds;
        //}
        //public void AddtoList(int id)
        //{
        //    var item = db.dbmonan.SingleOrDefault(s => s.IDMonAn == id);
        //    if (item != null)
        //    {
        //        GetMonAn().add(item);
        //    }
        //}
    }
}