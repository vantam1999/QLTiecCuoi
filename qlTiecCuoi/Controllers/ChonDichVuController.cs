using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using qlTiecCuoi.Models;
using qlTiecCuoi.DAL;
namespace qlTiecCuoi.Controllers
{
    public class ChonDichVuController : Controller
    {
        Context db = new Context();
        // GET: ChonDichVu
        public _DichVu get_()
        {
            _DichVu dichvu = Session["dichvu"] as _DichVu;
            if (dichvu == null || Session["dichvu"] == null)
            {
                dichvu = new _DichVu();
                Session["dichvu"] = dichvu;
            }
            return dichvu;
        }
        public ActionResult AddtoList(int id)
        {
            var dichvu = db.dbdichvu.SingleOrDefault(s => s.IDDichVu == id);
            if (dichvu != null)
            {
                get_().add(dichvu);
            }
            return RedirectToAction("Book", "Wedding");
        }
        public ActionResult show()
        {
            if (Session["dichvu"] != null)
            {
                _DichVu dichvu = Session["dichvu"] as _DichVu;
                return PartialView(dichvu);
            }
            return PartialView();
        }
        public ActionResult delete(int id)
        {
            _DichVu dichvu = Session["dichvu"] as _DichVu;
            dichvu.delete(id);
            return RedirectToAction("Book", "Wedding");
        }
    }
}