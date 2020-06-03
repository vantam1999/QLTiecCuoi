using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace qlTiecCuoi.Models
{
    public class LoaiSanh
    {
        [Key]
        public int IDLoaiSanh { get; set; }
        public string TenLoaiSanh { get; set; }
        public ICollection<SanhTiec> sanhtiecs { get; set; }
    }
}