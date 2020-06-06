using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using qlTiecCuoi.DAL;
using qlTiecCuoi.Models;

namespace qlTiecCuoi.Controllers
{
    public class DatTiecsController : Controller
    {
        private Context db = new Context();

        // GET: DatTiecs
        public ActionResult Index()
        {
            var dbdattiec = db.dbdattiec.Include(d => d.sanhtiec).Include(d => d.user);
            return View(dbdattiec.ToList());
        }

        // GET: DatTiecs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatTiec datTiec = db.dbdattiec.Find(id);
            if (datTiec == null)
            {
                return HttpNotFound();
            }
            return View(datTiec);
        }

        // GET: DatTiecs/Create
        public ActionResult Create()
        {
            ViewBag.IDSanh = new SelectList(db.dbsanhtiec, "IDSanh", "TenSanh");
            ViewBag.IDUser = new SelectList(db.dbuser, "IDUser", "FirstName");
            return View();
        }

        // POST: DatTiecs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDatTiec,IDUser,IDSanh,TenCoDau,TenChuRe,SDT,Ngay,Ca,SoLuongBan,SoBanDuTru")] DatTiec datTiec)
        {
            if (ModelState.IsValid)
            {
                db.dbdattiec.Add(datTiec);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDSanh = new SelectList(db.dbsanhtiec, "IDSanh", "TenSanh", datTiec.IDSanh);
            ViewBag.IDUser = new SelectList(db.dbuser, "IDUser", "FirstName", datTiec.IDUser);
            return View(datTiec);
        }

        // GET: DatTiecs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatTiec datTiec = db.dbdattiec.Find(id);
            if (datTiec == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDSanh = new SelectList(db.dbsanhtiec, "IDSanh", "TenSanh", datTiec.IDSanh);
            ViewBag.IDUser = new SelectList(db.dbuser, "IDUser", "FirstName", datTiec.IDUser);
            return View(datTiec);
        }

        // POST: DatTiecs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDatTiec,IDUser,IDSanh,TenCoDau,TenChuRe,SDT,Ngay,Ca,SoLuongBan,SoBanDuTru")] DatTiec datTiec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datTiec).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDSanh = new SelectList(db.dbsanhtiec, "IDSanh", "TenSanh", datTiec.IDSanh);
            ViewBag.IDUser = new SelectList(db.dbuser, "IDUser", "FirstName", datTiec.IDUser);
            return View(datTiec);
        }

        // GET: DatTiecs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatTiec datTiec = db.dbdattiec.Find(id);
            if (datTiec == null)
            {
                return HttpNotFound();
            }
            return View(datTiec);
        }

        // POST: DatTiecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatTiec datTiec = db.dbdattiec.Find(id);
            db.dbdattiec.Remove(datTiec);
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
