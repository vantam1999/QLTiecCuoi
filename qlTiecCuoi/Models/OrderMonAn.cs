using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace qlTiecCuoi.Models
{
    public class OrderMonAn
    {
        [Key]
        public int IDOrderMonAn { get; set; }
        //[ForeignKey("user")]
        //public int IDUSer { get; set; }
        //public User user { get; set; }
        [ForeignKey("monan")]
        public int IDMonAn { get; set; }
        public MonAn monan { get; set; }
        [ForeignKey("DatTiec")]
        public int IDDatTiec { get; set; }
        public DatTiec DatTiec { get; set; }
    }
}