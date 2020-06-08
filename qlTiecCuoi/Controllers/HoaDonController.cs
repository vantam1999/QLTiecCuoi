using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using qlTiecCuoi.Models;
using qlTiecCuoi.DAL;

namespace qlTiecCuoi.Controllers
{
    public class HoaDonController : Controller
    {
        Context db = new Context();
        // GET: HoaDon
        public ActionResult ThanhToan50(int id)
        {
            HoaDon h = new HoaDon();
            h.IDDatTiec = id;
            h.NgayThanhToan = DateTime.Now;
            double tienmonan = 0;
            foreach(var monan in db.OrderMonAn.ToList())
            {
                if (monan.IDDatTiec == id)
                {
                    var mon = db.dbmonan.Where(m => m.IDMonAn == monan.IDMonAn).FirstOrDefault();
                    tienmonan += mon.Gia;
                }
            }
            var dt = db.dbdattiec.Where(m => m.IDDatTiec == id).FirstOrDefault();
            var sanh = db.dbsanhtiec.Where(m => m.IDSanh == dt.IDSanh).FirstOrDefault();
            double tongtienban = dt.SoLuongBan * sanh.DonGia;
            h.TongTienBan = tongtienban;
            h.TongTienMonAn = tienmonan * dt.SoLuongBan;
            double tiendichvu = 0;
            foreach (var dichvu in db.OrderDichVu.ToList())
            {
                if (dichvu.IDDatTiec == id)
                {
                    var dv = db.dbdichvu.Where(m => m.IDDichVu == dichvu.IDDichVu).FirstOrDefault();
                    tiendichvu += dv.DonGia;
                }
            }
            h.TongTienDichVu = tiendichvu;
            h.TienSanh = sanh.DonGia;
            h.TongTienHoaDon = tongtienban + tiendichvu + tienmonan * dt.SoLuongBan;
            h.TienDatCoc = (tongtienban + tiendichvu + tienmonan * dt.SoLuongBan) / 2;
            h.ConLai = (tongtienban + tiendichvu + tienmonan * dt.SoLuongBan) / 2;
            db.dbhoadon.Add(h);
            dt.TinhTrang = true;
            db.Entry(dt).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("danhsachdattiec", "Wedding");
        }
        public ActionResult ThanhToan100(int id)
        {
            HoaDon h = new HoaDon();
            h.IDDatTiec = id;
            h.NgayThanhToan = DateTime.Now;
            double tienmonan = 0;
            foreach (var monan in db.OrderMonAn.ToList())
            {
                if (monan.IDDatTiec == id)
                {
                    var mon = db.dbmonan.Where(m => m.IDMonAn == monan.IDMonAn).FirstOrDefault();
                    tienmonan += mon.Gia;
                }
            }
            var dt = db.dbdattiec.Where(m => m.IDDatTiec == id).FirstOrDefault();
            var sanh = db.dbsanhtiec.Where(m => m.IDSanh == dt.IDSanh).FirstOrDefault();
            double tongtienban = dt.SoLuongBan * sanh.DonGia;
            h.TongTienBan = tongtienban;
            h.TongTienMonAn = tienmonan * dt.SoLuongBan;
            double tiendichvu = 0;
            foreach (var dichvu in db.OrderDichVu.ToList())
            {
                if (dichvu.IDDatTiec == id)
                {
                    var dv = db.dbdichvu.Where(m => m.IDDichVu == dichvu.IDDichVu).FirstOrDefault();
                    tiendichvu += dv.DonGia;
                }
            }
            h.TongTienDichVu = tiendichvu;
            h.TienSanh = sanh.DonGia;
            h.TongTienHoaDon = tongtienban + tiendichvu + tienmonan * dt.SoLuongBan;
            h.TienDatCoc = tongtienban + tiendichvu + tienmonan * dt.SoLuongBan;
            h.ConLai = 0;
            db.dbhoadon.Add(h);
            dt.TinhTrang = true;
            db.Entry(dt).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("danhsachdattiec", "Wedding");
        }
        public ActionResult XemChiTietHoaDon(int id)
        {
            var dattiec = db.dbdattiec.Where(m => m.IDDatTiec == id).FirstOrDefault();
            return View(dattiec);
        }
        public ActionResult ChiTietMonAn(int id)
        {
            List<MonAn> listmonan = new List<MonAn>();
            foreach (var monan in db.OrderMonAn.ToList())
            {
                if (monan.IDDatTiec == id)
                {
                    var mon = db.dbmonan.Where(m => m.IDMonAn == monan.IDMonAn).FirstOrDefault();
                    listmonan.Add(mon);
                }
            }
            return PartialView(listmonan);
        }
        public ActionResult ChiTietDichVu(int id)
        {
            List<DIchVu> listdichvu = new List<DIchVu>();
            foreach (var dichvu in db.OrderDichVu.ToList())
            {
                if (dichvu.IDDatTiec == id)
                {
                    var dichv = db.dbdichvu.Where(m => m.IDDichVu == dichvu.IDDichVu).FirstOrDefault();
                    listdichvu.Add(dichv);
                }
            }
            return PartialView(listdichvu);
        }
        public ActionResult ChiTietHoaDon(int id)
        {
            var dattiec = db.dbdattiec.Where(m => m.IDDatTiec == id).FirstOrDefault();
            ViewBag.soban = dattiec.SoLuongBan;
            var hoadon = db.dbhoadon.Where(m => m.IDDatTiec == id).FirstOrDefault();
            return PartialView(hoadon);
        }
    }
}