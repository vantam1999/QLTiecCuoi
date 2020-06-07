using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace qlTiecCuoi.Models
{
    public class HoaDon
    {
        [Key]
        public int IDHoaDon { get; set; }
        [ForeignKey("dattiec")]
        public int IDDatTiec { get; set; }
        public DatTiec dattiec { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public double TongTienBan { get; set; }
        public double TongTienDichVu { get; set; }
        public double TongTienMonAn { get; set; }
        public double TienSanh { get; set; }
        public double TongTienHoaDon { get; set; }
        public double TienDatCoc { get; set; }
        public double ConLai { get; set; }
    }
}