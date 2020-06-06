using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace qlTiecCuoi.Models
{
    public class MonAn_DatTiec
    {
        [Key]
        public int IDMonAn_DatTiec { get; set; }
        [ForeignKey("dattiec")]
        public int IDDatTiec { get; set; }
        public DatTiec dattiec { get; set; }
        [ForeignKey("monan")]
        public int IDMonAn { get; set; }
        public MonAn monan { get; set; }
    }
}