using qlTiecCuoi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace qlTiecCuoi.DAL
{
    public class Context:DbContext
    {
        public Context():base("name = QLTiecCuoi")
        {

        }
        public DbSet<User> dbuser { get; set; }
        public DbSet<MonAn> dbmonan { get; set; }
        public DbSet<DIchVu> dbdichvu { get; set; }
        public DbSet<SanhTiec> dbsanhtiec { get; set; }
        public DbSet<DatTiec> dbdattiec { get; set; }
        public DbSet<HoaDon> dbhoadon { get; set; }
        public DbSet<LoaiSanh> dbloaisanh { get; set; }
        public DbSet<MonAn_DatTiec> monan_dattiec { get; set; }
        public DbSet<DichVu_DatTiec> dichvu_dattiec { get; set; }
    }
}