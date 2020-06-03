using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace qlTiecCuoi.Models
{
    public class DIchVu
    {
        public DIchVu()
        {
            this.dattiecs = new HashSet<DatTiec>();
        }
        [Key]
        public int IDDichVu { get; set; }
        public string TenDichVu { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public string GhiChu { get; set; }
        public ICollection<DatTiec> dattiecs { get; set; }
    }
}