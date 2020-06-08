using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace qlTiecCuoi.Models
{
    public class DatTiec
    {
        [Key]
        public int IDDatTiec { get; set; }
        [ForeignKey("user")]
        public int IDUser { get; set; }
        public User user { get; set; }
        [ForeignKey("sanhtiec")]
        public int IDSanh { get; set; }
        public SanhTiec sanhtiec { get; set; }
        public string TenCoDau { get; set; }
        public string TenChuRe { get; set; }
        public string SDT { get; set; }
        public DateTime Ngay { get; set; }
        public string Ca { get; set; }
        public int SoLuongBan { get; set; }
        public int SoBanDuTru { get; set; }
        public bool TinhTrang { get; set; }
    }
}