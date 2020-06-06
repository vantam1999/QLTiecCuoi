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
                        Ngay = c.DateTime(nullable: false),
                        Ca = c.String(),
                        SoLuongBan = c.Int(nullable: false),
                        SoBanDuTru = c.Int(nullable: false),
                        TienCoc = c.Double(nullable: false),
                        GhiChu = c.String(),
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
                        DatTiec_IDDatTiec = c.Int(),
                    })
                .PrimaryKey(t => t.IDDichVu)
                .ForeignKey("dbo.DatTiecs", t => t.DatTiec_IDDatTiec)
                .Index(t => t.DatTiec_IDDatTiec);
            
            CreateTable(
                "dbo.MonAns",
                c => new
                    {
                        IDMonAn = c.Int(nullable: false, identity: true),
                        TenMon = c.String(),
                        Gia = c.Double(nullable: false),
                        GhiChu = c.String(),
                        DatTiec_IDDatTiec = c.Int(),
                    })
                .PrimaryKey(t => t.IDMonAn)
                .ForeignKey("dbo.DatTiecs", t => t.DatTiec_IDDatTiec)
                .Index(t => t.DatTiec_IDDatTiec);
            
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
                        UserName = c.String(),
                        Email = c.String(nullable: false),
                        PassWord = c.String(nullable: false),
                        SDT = c.String(nullable: false),
                        DiaChi = c.String(),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HoaDons", "IDDatTiec", "dbo.DatTiecs");
            DropForeignKey("dbo.DatTiecs", "IDUser", "dbo.Users");
            DropForeignKey("dbo.DatTiecs", "IDSanh", "dbo.SanhTiecs");
            DropForeignKey("dbo.SanhTiecs", "IDLoaiSanh", "dbo.LoaiSanhs");
            DropForeignKey("dbo.MonAns", "DatTiec_IDDatTiec", "dbo.DatTiecs");
            DropForeignKey("dbo.DIchVus", "DatTiec_IDDatTiec", "dbo.DatTiecs");
            DropIndex("dbo.HoaDons", new[] { "IDDatTiec" });
            DropIndex("dbo.SanhTiecs", new[] { "IDLoaiSanh" });
            DropIndex("dbo.MonAns", new[] { "DatTiec_IDDatTiec" });
            DropIndex("dbo.DIchVus", new[] { "DatTiec_IDDatTiec" });
            DropIndex("dbo.DatTiecs", new[] { "IDSanh" });
            DropIndex("dbo.DatTiecs", new[] { "IDUser" });
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
