using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace qlTiecCuoi.Models
{
    public class DIchVu
    {
        [Key]
        public int IDDichVu { get; set; }
        public string TenDichVu { get; set; }
        public string HinhAnh { get; set; }
        public double DonGia { get; set; }
    }
}