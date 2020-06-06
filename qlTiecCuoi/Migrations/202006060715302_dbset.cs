namespace qlTiecCuoi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbset : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MonAn_DatTiec", "IDMonAn", "dbo.MonAns");
            DropForeignKey("dbo.MonAn_DatTiec", "IDDatTiec", "dbo.DatTiecs");
            DropForeignKey("dbo.DichVu_DatTiec", "IDDichVu", "dbo.DIchVus");
            DropForeignKey("dbo.DichVu_DatTiec", "IDDatTiec", "dbo.DatTiecs");
            DropIndex("dbo.MonAn_DatTiec", new[] { "IDMonAn" });
            DropIndex("dbo.MonAn_DatTiec", new[] { "IDDatTiec" });
            DropIndex("dbo.DichVu_DatTiec", new[] { "IDDatTiec" });
            DropIndex("dbo.DichVu_DatTiec", new[] { "IDDichVu" });
            DropTable("dbo.MonAn_DatTiec");
            DropTable("dbo.DichVu_DatTiec");
        }
    }
}
