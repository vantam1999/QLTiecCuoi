using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace qlTiecCuoi.Models
{
    public class OrderDichVu
    {
        [Key]
        public int IDOrderDichVu { get; set; }
        [ForeignKey("dichvu")]
        public int IDDichVu { get; set; }
        public DIchVu dichvu { get; set; }
        //[ForeignKey("user")]
        //public int IDUser { get; set; }
        //public User user { get; set; }
        [ForeignKey("DatTiec")]
        public int IDDatTiec { get; set; }
        public DatTiec DatTiec { get; set; }
    }
}