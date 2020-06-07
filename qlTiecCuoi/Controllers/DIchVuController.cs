using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using qlTiecCuoi.DAL;
using qlTiecCuoi.Models;

namespace qlTiecCuoi.Controllers
{
    public class DIchVuController : Controller
    {
        private Context db = new Context();

        // GET: DIchVu
        public ActionResult Index()
        {
            return View(db.dbdichvu.ToList());
        }

        // GET: DIchVu/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    DIchVu dIchVu = db.dbdichvu.Find(id);
        //    if (dIchVu == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(dIchVu);
        //}

        // GET: DIchVu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DIchVu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDichVu,TenDichVu,DonGia,HinhAnh")] DIchVu dIchVu, HttpPostedFileBase HinhAnh)
        {
            if (ModelState.IsValid)
            {
                if (HinhAnh != null)
                {
                    var filename = Path.GetFileName(HinhAnh.FileName);
                    dIchVu.HinhAnh = filename;
                    string path = Path.Combine(Server.MapPath("~/Content/assets/images/trang-tri/"), filename);
                    HinhAnh.SaveAs(path);
                }
                else
                    dIchVu.HinhAnh = "backdrop.jpg";
                db.dbdichvu.Add(dIchVu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dIchVu);
        }

        // GET: DIchVu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIchVu dIchVu = db.dbdichvu.Find(id);
            if (dIchVu == null)
            {
                return HttpNotFound();
            }
            return View(dIchVu);
        }

        // POST: DIchVu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDichVu,TenDichVu,DonGia,GhiChu")] DIchVu dIchVu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dIchVu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dIchVu);
        }

        // GET: DIchVu/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    DIchVu dIchVu = db.dbdichvu.Find(id);
        //    if (dIchVu == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(dIchVu);
        //}

        //// POST: DIchVu/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            DIchVu dIchVu = db.dbdichvu.Find(id);
            db.dbdichvu.Remove(dIchVu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
