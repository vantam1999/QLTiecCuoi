using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace qlTiecCuoi.Models
{
    public class User
    {
        [Key]
        public int IDUser { get; set; }
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        [Required]
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("PassWord", ErrorMessage ="Mật khẩu nhập lại không khớp")]
        public string ConFirmPassWord { get; set; }
        [Required]
        public string SDT { get; set; }
        public string DiaChi { get; set; }
    }
}