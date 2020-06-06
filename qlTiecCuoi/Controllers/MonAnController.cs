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
    public class MonAnController : Controller
    {
        private Context db = new Context();

        // GET: MonAn
        public ActionResult Index()
        {
            return View(db.dbmonan.ToList());
        }
        

        // GET: MonAn/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MonAn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDMonAn,TenMon,HinhAnh,Gia,GhiChu")] MonAn monAn, HttpPostedFileBase HinhAnh)
        {
            if (ModelState.IsValid)
            {
                if (HinhAnh != null)
                {
                    var filename = Path.GetFileName(HinhAnh.FileName);
                    monAn.HinhAnh = filename;
                    string path = Path.Combine(Server.MapPath("~/Content/Myfolder/images/food/"), filename);
                    HinhAnh.SaveAs(path);
                }
                else
                    monAn.HinhAnh = "1.jpg";
                db.dbmonan.Add(monAn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monAn);
        }

        // GET: MonAn/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonAn monAn = db.dbmonan.Find(id);
            if (monAn == null)
            {
                return HttpNotFound();
            }
            return View(monAn);
        }

        // POST: MonAn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDMonAn,TenMon,HinhAnh,Gia,GhiChu")] MonAn monAn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monAn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monAn);
        }
        public ActionResult Delete(int id)
        {
            MonAn monAn = db.dbmonan.Find(id);
            db.dbmonan.Remove(monAn);
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
