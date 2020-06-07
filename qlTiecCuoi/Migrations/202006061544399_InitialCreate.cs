namespace qlTiecCuoi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DatTiecs",
                c => new
                    {
                        IDDatTiec = c.Int(nullable: false, identity: true),
                        IDUser = c.Int(nullable: false),
                        IDSanh = c.Int(nullable: false),
                        TenCoDau = c.String(),
                        TenChuRe = c.String(),
                        SDT = c.String(),
                        Ngay = c.DateTime(nullable: false),
                        Ca = c.String(),
                        SoLuongBan = c.Int(nullable: false),
                        SoBanDuTru = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDDatTiec)
                .ForeignKey("dbo.SanhTiecs", t => t.IDSanh, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.IDUser, cascadeDelete: true)
                .Index(t => t.IDUser)
                .Index(t => t.IDSanh);
            
            CreateTable(
                "dbo.SanhTiecs",
                c => new
                    {
                        IDSanh = c.Int(nullable: false, identity: true),
                        TenSanh = c.String(nullable: false),
                        HinhAnh = c.String(),
                        SoLuongBan = c.Int(nullable: false),
                        DonGia = c.Double(nullable: false),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.IDSanh);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IDUser = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IDUser);
            
            CreateTable(
                "dbo.DIchVus",
                c => new
                    {
                        IDDichVu = c.Int(nullable: false, identity: true),
                        TenDichVu = c.String(),
<<<<<<< HEAD:qlTiecCuoi/Migrations/202006061156579_initData.cs
                        DonGia = c.Double(nullable: false),
                        GhiChu = c.String(),
=======
                        HinhAnh = c.String(),
                        DonGia = c.Double(nullable: false),
>>>>>>> 7bc1d0c923584e6fbc290cc4f40f5de1faaad08f:qlTiecCuoi/Migrations/202006061544399_InitialCreate.cs
                    })
                .PrimaryKey(t => t.IDDichVu);
            
            CreateTable(
                "dbo.HoaDons",
                c => new
                    {
                        IDHoaDon = c.Int(nullable: false, identity: true),
                        IDDatTiec = c.Int(nullable: false),
                        NgayThanhToan = c.DateTime(nullable: false),
                        TongTienBan = c.Double(nullable: false),
                        TongTienDichVu = c.Double(nullable: false),
                        TongTienMonAn = c.Double(nullable: false),
                        TienSanh = c.Double(nullable: false),
                        TongTienHoaDon = c.Double(nullable: false),
                        TienDatCoc = c.Double(nullable: false),
                        ConLai = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IDHoaDon)
                .ForeignKey("dbo.DatTiecs", t => t.IDDatTiec, cascadeDelete: true)
                .Index(t => t.IDDatTiec);
            
            CreateTable(
                "dbo.MonAns",
<<<<<<< HEAD:qlTiecCuoi/Migrations/202006061156579_initData.cs
                c => new
                    {
                        IDMonAn = c.Int(nullable: false, identity: true),
                        TenMon = c.String(),
                        HinhAnh = c.String(),
                        Gia = c.Double(nullable: false),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.IDMonAn);
            
            CreateTable(
                "dbo.DichVu_DatTiec",
                c => new
                    {
                        IDDichVu_DatTiec = c.Int(nullable: false, identity: true),
                        IDDichVu = c.Int(nullable: false),
                        IDDatTiec = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDDichVu_DatTiec)
                .ForeignKey("dbo.DatTiecs", t => t.IDDatTiec, cascadeDelete: true)
                .ForeignKey("dbo.DIchVus", t => t.IDDichVu, cascadeDelete: true)
                .Index(t => t.IDDichVu)
                .Index(t => t.IDDatTiec);
            
            CreateTable(
                "dbo.MonAn_DatTiec",
                c => new
                    {
                        IDMonAn_DatTiec = c.Int(nullable: false, identity: true),
                        IDDatTiec = c.Int(nullable: false),
                        IDMonAn = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDMonAn_DatTiec)
                .ForeignKey("dbo.DatTiecs", t => t.IDDatTiec, cascadeDelete: true)
                .ForeignKey("dbo.MonAns", t => t.IDMonAn, cascadeDelete: true)
                .Index(t => t.IDDatTiec)
                .Index(t => t.IDMonAn);
=======
                c => new
                    {
                        IDMonAn = c.Int(nullable: false, identity: true),
                        TenMon = c.String(),
                        HinhAnh = c.String(),
                        Gia = c.Double(nullable: false),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.IDMonAn);
>>>>>>> 7bc1d0c923584e6fbc290cc4f40f5de1faaad08f:qlTiecCuoi/Migrations/202006061544399_InitialCreate.cs
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MonAn_DatTiec", "IDMonAn", "dbo.MonAns");
            DropForeignKey("dbo.MonAn_DatTiec", "IDDatTiec", "dbo.DatTiecs");
            DropForeignKey("dbo.DichVu_DatTiec", "IDDichVu", "dbo.DIchVus");
            DropForeignKey("dbo.DichVu_DatTiec", "IDDatTiec", "dbo.DatTiecs");
            DropForeignKey("dbo.HoaDons", "IDDatTiec", "dbo.DatTiecs");
            DropForeignKey("dbo.DatTiecs", "IDUser", "dbo.Users");
            DropForeignKey("dbo.DatTiecs", "IDSanh", "dbo.SanhTiecs");
<<<<<<< HEAD:qlTiecCuoi/Migrations/202006061156579_initData.cs
            DropForeignKey("dbo.SanhTiecs", "IDLoaiSanh", "dbo.LoaiSanhs");
            DropIndex("dbo.MonAn_DatTiec", new[] { "IDMonAn" });
            DropIndex("dbo.MonAn_DatTiec", new[] { "IDDatTiec" });
            DropIndex("dbo.DichVu_DatTiec", new[] { "IDDatTiec" });
            DropIndex("dbo.DichVu_DatTiec", new[] { "IDDichVu" });
=======
>>>>>>> 7bc1d0c923584e6fbc290cc4f40f5de1faaad08f:qlTiecCuoi/Migrations/202006061544399_InitialCreate.cs
            DropIndex("dbo.HoaDons", new[] { "IDDatTiec" });
            DropIndex("dbo.DatTiecs", new[] { "IDSanh" });
            DropIndex("dbo.DatTiecs", new[] { "IDUser" });
<<<<<<< HEAD:qlTiecCuoi/Migrations/202006061156579_initData.cs
            DropTable("dbo.MonAn_DatTiec");
            DropTable("dbo.DichVu_DatTiec");
=======
>>>>>>> 7bc1d0c923584e6fbc290cc4f40f5de1faaad08f:qlTiecCuoi/Migrations/202006061544399_InitialCreate.cs
            DropTable("dbo.MonAns");
            DropTable("dbo.HoaDons");
            DropTable("dbo.DIchVus");
            DropTable("dbo.Users");
            DropTable("dbo.SanhTiecs");
            DropTable("dbo.DatTiecs");
        }
    }
}
