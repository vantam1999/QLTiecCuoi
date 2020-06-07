using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace qlTiecCuoi.Models
{
    public class SanhTiec
    {
        [Key]
        public int IDSanh { get; set; }
        [Required]
        public string TenSanh { get; set; }
        public string HinhAnh { get; set; }
        [Required]
        public int SoLuongBan { get; set; }
        [Required]
        public double DonGia { get; set; }
        public string GhiChu { get; set; }
        public List<SanhTiec> danhsachsanh { get; set; }
    }
}