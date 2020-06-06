namespace qlTiecCuoi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                "dbo.DIchVus",
                c => new
                    {
                        IDDichVu = c.Int(nullable: false, identity: true),
                        TenDichVu = c.String(),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Double(nullable: false),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.IDDichVu);
            
            CreateTable(
                "dbo.MonAns",
                c => new
                    {
                        IDMonAn = c.Int(nullable: false, identity: true),
                        TenMon = c.String(),
                        Gia = c.Double(nullable: false),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.IDMonAn);
            
            CreateTable(
                "dbo.SanhTiecs",
                c => new
                    {
                        IDSanh = c.Int(nullable: false, identity: true),
                        TenSanh = c.String(nullable: false),
                        IDLoaiSanh = c.Int(nullable: false),
                        SoLuongBan = c.Int(nullable: false),
                        DonGia = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IDSanh)
                .ForeignKey("dbo.LoaiSanhs", t => t.IDLoaiSanh, cascadeDelete: true)
                .Index(t => t.IDLoaiSanh);
            
            CreateTable(
                "dbo.LoaiSanhs",
                c => new
                    {
                        IDLoaiSanh = c.Int(nullable: false, identity: true),
                        TenLoaiSanh = c.String(),
                    })
                .PrimaryKey(t => t.IDLoaiSanh);
            
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
                "dbo.HoaDons",
                c => new
                    {
                        IDHoaDon = c.Int(nullable: false, identity: true),
                        IDDatTiec = c.Int(nullable: false),
                        TongTienBan = c.Double(nullable: false),
                        TongTienDichVu = c.Double(nullable: false),
                        TongTien = c.Double(nullable: false),
                        ConLai = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IDHoaDon)
                .ForeignKey("dbo.DatTiecs", t => t.IDDatTiec, cascadeDelete: true)
                .Index(t => t.IDDatTiec);
            
            CreateTable(
                "dbo.DIchVuDatTiecs",
                c => new
                    {
                        DIchVu_IDDichVu = c.Int(nullable: false),
                        DatTiec_IDDatTiec = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DIchVu_IDDichVu, t.DatTiec_IDDatTiec })
                .ForeignKey("dbo.DIchVus", t => t.DIchVu_IDDichVu, cascadeDelete: true)
                .ForeignKey("dbo.DatTiecs", t => t.DatTiec_IDDatTiec, cascadeDelete: true)
                .Index(t => t.DIchVu_IDDichVu)
                .Index(t => t.DatTiec_IDDatTiec);
            
            CreateTable(
                "dbo.MonAnDatTiecs",
                c => new
                    {
                        MonAn_IDMonAn = c.Int(nullable: false),
                        DatTiec_IDDatTiec = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MonAn_IDMonAn, t.DatTiec_IDDatTiec })
                .ForeignKey("dbo.MonAns", t => t.MonAn_IDMonAn, cascadeDelete: true)
                .ForeignKey("dbo.DatTiecs", t => t.DatTiec_IDDatTiec, cascadeDelete: true)
                .Index(t => t.MonAn_IDMonAn)
                .Index(t => t.DatTiec_IDDatTiec);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HoaDons", "IDDatTiec", "dbo.DatTiecs");
            DropForeignKey("dbo.DatTiecs", "IDUser", "dbo.Users");
            DropForeignKey("dbo.DatTiecs", "IDSanh", "dbo.SanhTiecs");
            DropForeignKey("dbo.SanhTiecs", "IDLoaiSanh", "dbo.LoaiSanhs");
            DropForeignKey("dbo.MonAnDatTiecs", "DatTiec_IDDatTiec", "dbo.DatTiecs");
            DropForeignKey("dbo.MonAnDatTiecs", "MonAn_IDMonAn", "dbo.MonAns");
            DropForeignKey("dbo.DIchVuDatTiecs", "DatTiec_IDDatTiec", "dbo.DatTiecs");
            DropForeignKey("dbo.DIchVuDatTiecs", "DIchVu_IDDichVu", "dbo.DIchVus");
            DropIndex("dbo.MonAnDatTiecs", new[] { "DatTiec_IDDatTiec" });
            DropIndex("dbo.MonAnDatTiecs", new[] { "MonAn_IDMonAn" });
            DropIndex("dbo.DIchVuDatTiecs", new[] { "DatTiec_IDDatTiec" });
            DropIndex("dbo.DIchVuDatTiecs", new[] { "DIchVu_IDDichVu" });
            DropIndex("dbo.HoaDons", new[] { "IDDatTiec" });
            DropIndex("dbo.SanhTiecs", new[] { "IDLoaiSanh" });
            DropIndex("dbo.DatTiecs", new[] { "IDSanh" });
            DropIndex("dbo.DatTiecs", new[] { "IDUser" });
            DropTable("dbo.MonAnDatTiecs");
            DropTable("dbo.DIchVuDatTiecs");
            DropTable("dbo.HoaDons");
            DropTable("dbo.Users");
            DropTable("dbo.LoaiSanhs");
            DropTable("dbo.SanhTiecs");
            DropTable("dbo.MonAns");
            DropTable("dbo.DIchVus");
            DropTable("dbo.DatTiecs");
        }
    }
}
