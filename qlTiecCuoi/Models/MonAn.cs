using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace qlTiecCuoi.Models
{
    public class MonAn
    {
        //public MonAn()
        //{
        //    this.dattiecs = new HashSet<DatTiec>();
        //}
        [Key]
        public int IDMonAn { get; set; }
        public string TenMon { get; set; }
        public string HinhAnh { get; set; }
        public double Gia { get; set; }
        public string GhiChu { get; set; }
        //public ICollection<DatTiec> dattiecs { get; set; }
    }
}