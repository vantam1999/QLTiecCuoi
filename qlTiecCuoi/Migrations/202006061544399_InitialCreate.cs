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
                        HinhAnh = c.String(),
                        DonGia = c.Double(nullable: false),
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
                c => new
                    {
                        IDMonAn = c.Int(nullable: false, identity: true),
                        TenMon = c.String(),
                        HinhAnh = c.String(),
                        Gia = c.Double(nullable: false),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.IDMonAn);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HoaDons", "IDDatTiec", "dbo.DatTiecs");
            DropForeignKey("dbo.DatTiecs", "IDUser", "dbo.Users");
            DropForeignKey("dbo.DatTiecs", "IDSanh", "dbo.SanhTiecs");
            DropIndex("dbo.HoaDons", new[] { "IDDatTiec" });
            DropIndex("dbo.DatTiecs", new[] { "IDSanh" });
            DropIndex("dbo.DatTiecs", new[] { "IDUser" });
            DropTable("dbo.MonAns");
            DropTable("dbo.HoaDons");
            DropTable("dbo.DIchVus");
            DropTable("dbo.Users");
            DropTable("dbo.SanhTiecs");
            DropTable("dbo.DatTiecs");
        }
    }
}
