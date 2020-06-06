using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace qlTiecCuoi.Models
{
    public class DichVu_DatTiec
    {
        [Key]
        public int IDDichVu_DatTiec { get; set; }
        [ForeignKey("dichvu")]
        public int IDDichVu { get; set; }
        public DIchVu dichvu { get; set; }
        [ForeignKey("dattiec")]
        public int IDDatTiec { get; set; }
        public DatTiec dattiec { get; set; }
    }
}