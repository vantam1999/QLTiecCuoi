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
    public class SanhTiecsController : Controller
    {
        private Context db = new Context();

        // GET: SanhTiecs
        public ActionResult Index()
        {
            return View(db.dbsanhtiec.ToList());
        }

        // GET: SanhTiecs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanhTiec sanhTiec = db.dbsanhtiec.Find(id);
            if (sanhTiec == null)
            {
                return HttpNotFound();
            }
            return View(sanhTiec);
        }

        // GET: SanhTiecs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SanhTiecs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDSanh,TenSanh,HinhAnh,SoLuongBan,DonGia,GhiChu")] SanhTiec sanhTiec, HttpPostedFileBase HinhAnh)
        {
            if (ModelState.IsValid)
            {
                if (HinhAnh != null)
                {
                    var filename = Path.GetFileName(HinhAnh.FileName);
                    sanhTiec.HinhAnh = filename;
                    string path = Path.Combine(Server.MapPath("~/Content/assets/images/sanh/"), filename);
                    HinhAnh.SaveAs(path);
                }
                else
                    sanhTiec.HinhAnh = "amethyst-1.jpg";
                db.dbsanhtiec.Add(sanhTiec);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sanhTiec);
        }

        // GET: SanhTiecs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanhTiec sanhTiec = db.dbsanhtiec.Find(id);
            if (sanhTiec == null)
            {
                return HttpNotFound();
            }
            return View(sanhTiec);
        }

        // POST: SanhTiecs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDSanh,TenSanh,HinhAnh,SoLuongBan,DonGia,GhiChu")] SanhTiec sanhTiec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanhTiec).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sanhTiec);
        }

        // GET: SanhTiecs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanhTiec sanhTiec = db.dbsanhtiec.Find(id);
            if (sanhTiec == null)
            {
                return HttpNotFound();
            }
            return View(sanhTiec);
        }

        // POST: SanhTiecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanhTiec sanhTiec = db.dbsanhtiec.Find(id);
            db.dbsanhtiec.Remove(sanhTiec);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult chonsanh()
        {
            SanhTiec s = new SanhTiec();
            s.danhsachsanh = db.dbsanhtiec.ToList();
            return PartialView(s);
        }
        public ActionResult thongtinsanh(int id)
        {
            var sanh = db.dbsanhtiec.Where(m => m.IDSanh == id).FirstOrDefault();
            if (sanh!= null)
            {
                ViewBag.sanh = sanh;
                return PartialView(sanh);
            }
            else
                return PartialView();
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
